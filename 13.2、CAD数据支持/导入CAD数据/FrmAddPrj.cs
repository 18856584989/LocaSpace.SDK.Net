using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImportCAD
{
    public partial class FrmAddPrj : Form
    {
        private int _EPSG = 32630;//默认EPSG_ID号
        private string _WKTLocal; //读取到的坐标系统WKT字符串
        private string _filePath = null;  //图层文件地址
        private string prjPath = null;  //投影文件地址
        //临时投影文件地址
        private string TempPath = Application.StartupPath + "/Temp/Temp.prj";
        //坐标系统属性
        private DataTable table;

        public FrmAddPrj(string filepath)
        {
            InitializeComponent();
            this._filePath = filepath;
            //获取.prj文件地址
            var ext = Path.GetExtension(filepath);
            this.prjPath = _filePath.Replace(ext, ".prj");
        }

        private void FrmAddCad_Load(object sender, EventArgs e)
        {
            CheckDir();
            initTable();
        }

        /// <summary>
        /// 创建临时文件夹_Temp
        /// </summary>
        void CheckDir()
        {
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(TempPath)))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(TempPath));
            }
        }

        /// <summary>
        /// 初始化坐标系统属性表
        /// </summary>
        void initTable()
        {
            table = new DataTable("dataTable");
            table.Columns.Add("属性");
            table.Columns.Add("值");
            this.dataGridView1.DataSource = table;
            ShowContent();
        }

        /// <summary>
        /// 获取坐标系统信息
        /// </summary>
        private void ShowContent()
        {
            //如果没有投影文件，则给一个默认的EPSG代码
            if (!File.Exists(prjPath))
            {
                if (!ExporPrj(_EPSG))
                {
                    MessageBox.Show(this, "生成默认Prj文件失败！");
                    return;
                }
                this.textBox1.Text = _EPSG.ToString();
            }
            //显示投影文件中的内容
            ReadProjcsInfo();
        }

        /// <summary>
        /// 根据EPSG的ID导出投影信息
        /// </summary>
        /// <param name="id">EPSG的ID</param>
        /// <returns></returns>
        Boolean ExporPrj(int id)
        {
            bool isTrue = false;
            _WKTLocal = null;
            if (!File.Exists(Path.Combine(Application.StartupPath, SRIDReader.filename)))
            {
                if (MessageBox.Show("未找到\"SRID.csv\"文件，是否指定SRID文件？", "文件丢失", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    OpenFileDialog file = new OpenFileDialog()
                    {
                        Filter = "支持文件(*.csv)|*.csv",
                        Multiselect = false
                    };
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        //复制投影文件到目标文件夹，便于后续查询
                        File.Copy(file.FileName, Path.Combine(Application.StartupPath, SRIDReader.filename), true);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            //根据输入的ID值获取到相应的坐标系统WKT字符串
            _WKTLocal = SRIDReader.GetCSbyID(id);
            //如果获取到对应的信息不为空则将该字符串写入临时.prj文件
            if (_WKTLocal != null)
            {
                isTrue = true;
                //写入prj文件
                FileStream fs = new FileStream(TempPath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.Write(_WKTLocal);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            return isTrue;
        }

        void ReadProjcsInfo()
        {
            StreamReader sr = new StreamReader(TempPath, Encoding.Default);
            string line = sr.ReadToEnd();

            string[] strLine = line.Split(',');

            //Projcs
            string strProjcs = strLine[0].Replace("PROJCS[", "").Replace("\"", "");
            comboBox1.Items.Clear();
            comboBox1.Items.Add(strProjcs);
            comboBox1.SelectedIndex = 0;

            //基准面
            string strDatum = strLine[2].Replace("DATUM[", "").Replace("\"", "");
            comboBox2.Items.Clear();
            comboBox2.Items.Add(strDatum);
            comboBox2.SelectedIndex = 0;

            //参数信息
            string latitude = strLine[22].Replace("]", "");
            string meridian = strLine[24].Replace("]", "");
            string factor = strLine[26].Replace("]", "");
            string easting = strLine[28].Replace("]", "");
            string northing = strLine[30].Replace("]", "");
            table.Rows.Clear();
            DataRow item1 = table.NewRow();
            item1[0] = "latitude_of_origin";
            item1[1] = latitude;
            table.Rows.Add(item1);

            DataRow item2 = table.NewRow();
            item2[0] = "central_meridian";
            item2[1] = meridian;
            table.Rows.Add(item2);

            DataRow item3 = table.NewRow();
            item3[0] = "scale_factor";
            item3[1] = factor;
            table.Rows.Add(item3);

            DataRow item4 = table.NewRow();
            item4[0] = "false_easting";
            item4[1] = easting;
            table.Rows.Add(item4);

            DataRow item5 = table.NewRow();
            item5[0] = "false_northing";
            item5[1] = northing;
            table.Rows.Add(item5);

            sr.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //将临时.prj文件复制到CAD文件所在目录
            File.Copy(TempPath, prjPath, true);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnInPrj_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = false;
            openfile.Filter = "支持格式(*.prj)|*.prj";
            if (openfile.ShowDialog(this) == DialogResult.OK)
            {
                //将指定的.prj文件复制到CAD文件所在目录
                File.Copy(openfile.FileName, TempPath, true);
                //读取.prj文件信息
                ReadProjcsInfo();
                this.textBox1.Text = string.Empty;
            }
            else
            {
                ShowContent();
            }
        }

        private void btnEPSG_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out _EPSG))
            {
                MessageBox.Show(this, "输入的代码不合法！请输入正确的代码！", "代码不合法");
                return;
            }
            if(!ExporPrj(_EPSG))
            {
                MessageBox.Show(this, "获取prj文件失败，请确认EPSG代码：" + textBox1.Text + " 是否有误", "获取失败");
                return;
            }
            ReadProjcsInfo();
        }
    }
}
