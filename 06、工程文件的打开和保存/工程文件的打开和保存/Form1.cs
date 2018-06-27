using System.Windows.Forms;
using GeoScene.Globe;

namespace 工程文件的打开和保存
{
    public partial class Form1 : Form
    {
        //创建球对象
        readonly GSOGlobeControl globeControl1;

        public Form1()
        {
            InitializeComponent();

            //添加球
            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 打开工程一
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            //获得文件地址
            string path = Application.StartupPath + "/Resource/GWS/1.gws";
            //先关闭当前工程
            if (!CloseWorkSpace()) return;
            //打开工程文件
            globeControl1.Globe.OpenWorkSpace(path);
            //刷新球
            globeControl1.Refresh();
            //将图层写入list中，方便查看不同
            AddLayerToComobBox();
        }

        /// <summary>
        /// 打开工程二
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, System.EventArgs e)
        {
            //获得文件地址
            string path = Application.StartupPath + "/Resource/GWS/2.gws";
            //先关闭当前工程
            if (!CloseWorkSpace()) return;

            //打开工程文件
            globeControl1.Globe.OpenWorkSpace(path);
            //刷新球
            globeControl1.Refresh();
            //将图层写入list中，方便查看不同
            AddLayerToComobBox();
        }

        /// <summary>
        /// 关闭工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, System.EventArgs e)
        {
            CloseWorkSpace();
            listBox1.Items.Clear();
        }


        /// <summary>
        /// 关闭工程
        /// </summary>
        /// <returns>执行成功返回真否则返回假</returns>
        private bool CloseWorkSpace()
        {
            if (globeControl1.Globe.Layers.Count <= 0 && globeControl1.Globe.Terrains.Count <= 0) return true;
            var result = MessageBox.Show("是否保存数据?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question); 
            if (result != DialogResult.Yes) return false;
            SaveAllData();
            ClearWorkSpace();
            return true;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveAllData()
        {
            //遍历图层，保存数据
            for (var i = 0; i < globeControl1.Globe.Layers.Count; i++)
            {
                var layer = globeControl1.Globe.Layers[i];
                if (layer != null)
                {
                    //保存图层数据
                    layer.Save();
                }
            }
        }

        /// <summary>
        /// 清空工作空间
        /// </summary>
        private void ClearWorkSpace()
        {
            //移除所有图层
            globeControl1.Globe.Layers.RemoveAll();
            //移除所有地形
            globeControl1.Globe.Terrains.RemoveAll();
            //移除所有数据源
            globeControl1.Globe.DataManager.RemoveAllDataSources();
            //刷新三维球
            globeControl1.Refresh();
        }

        /// <summary>
        /// 将工程文件中的图层添加到下拉列表中
        /// </summary>
        private void AddLayerToComobBox()
        {
            listBox1.Items.Clear();
            for (var i = 0; i < globeControl1.Globe.Layers.Count; i ++)
            {
                var layer = globeControl1.Globe.Layers[i];
                var layerName = System.IO.Path.GetFileNameWithoutExtension(layer.Name);
                listBox1.Items.Add(layerName);
            }
        }
    }
}
