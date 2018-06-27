using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;

namespace WorldGIS
{
    public partial class FrmDataJoinDom : Form
    {
        GSOGlobeControl globeControl1;
        public FrmDataJoinDom(GSOGlobeControl _globeControl1)
        {
            InitializeComponent();
            globeControl1 = _globeControl1;
        }

        private void FrmDataBatchDom_Load(object sender, EventArgs e)
        {
            if (comboBoxFilterRegion.Items.Count > 0)
            {
                comboBoxFilterRegion.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 添加数据事件
        /// </summary>
        /// <param name="strDataPath">文件路径</param>
        private void AddSrcData(string strDataPath)
        {
            string strExt = Path.GetExtension(strDataPath);
            for (int i = 0; i < dataGridViewDomList.Rows.Count; i++)
            {
               object value = dataGridViewDomList.Rows[i].Cells[1].Value;
               if (strDataPath.Equals(value.ToString()) == true)
               {
                   MessageBox.Show("文件已添加，不能重复添加同一份数据！","提示");
                   return;
               }
            }

            int rowIndex = dataGridViewDomList.Rows.Add();
            dataGridViewDomList.Rows[rowIndex].Cells[0].Value = rowIndex + 1;
            dataGridViewDomList.Rows[rowIndex].Cells[1].Value = strDataPath;
            if (strExt.ToLower().Trim() == ".lrp")
            {
                dataGridViewDomList.Rows[rowIndex].Cells[2].Value = "经纬度数据";
            }
            else
            {
                string proj4 = GSODataEngineUtility.GetProj4FromDataFile(strDataPath);
                if (proj4 != "")
                {
                    dataGridViewDomList.Rows[rowIndex].Cells[2].Value = "经纬度数据";
                }
                else if (proj4 == "")
                {
                    dataGridViewDomList.Rows[rowIndex].Cells[2].Value = "无投影信息数据";
                }
            }
        }
        /// <summary>
        /// "添加数据"按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "支持格式(*.lrp,*.tif,*.tiff,*.img,*.asc,*.raw,*.dem,*.adf,*.idr,*.sid,*.ecw,*.e00,*.ers,*.hdr,*.grd)|" +
                         "*.lrp;*.tif;*.tiff;*.img;*.asc;*.raw;*.dem;*.adf;*.idr;*.sid;*.ecw;*.e00;*.ers;*.hdr;*.grd|*.tif,*.tiff|*.tif;*.tiff|*.img|*.img|其它格式(*.*)|*.*";
            dlg.Multiselect = true;
            dlg.Title = "添加拼接数据";
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    AddSrcData(dlg.FileNames[i]);
                }
            }
        }
        /// <summary>
        /// 添加文件夹按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddDataByDirectory_Click(object sender, EventArgs e)
        {
            //调用DLL的新控件
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog dlg = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            dlg.IsFolderPicker = true;
            dlg.Multiselect = false;
            dlg.Title = "选择目录";
            if (dlg.ShowDialog(this.Handle) == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                string directoryPath = dlg.FileName;
                string[] fileNames = Directory.GetFiles(directoryPath);
                for (int i = 0; i < fileNames.Length; i++)
                {
                    AddSrcData(fileNames[i]);
                }
            }
        }

        private void buttonRemoveSelect_Click(object sender, EventArgs e)
        {
            if (dataGridViewDomList.SelectedRows != null)
            {
                for (int i = dataGridViewDomList.SelectedRows.Count - 1; i >= 0; i--)
                {
                    dataGridViewDomList.Rows.Remove(dataGridViewDomList.SelectedRows[i]);
                }
            }
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            dataGridViewDomList.Rows.Clear();
        }


        bool isFormclosing = false;
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (dataGridViewDomList.Rows.Count == 0)
            {
                MessageBox.Show("请先添加数据！", "提示");
                return;
            }
            //输出路径
            string dataPatho_new = textBoxOutputPath.Text.Trim();
            if (dataPatho_new == "")
            {
                MessageBox.Show("请选择输出路径！","提示");
                return;
            }
            int r = 0;
            int g = 0;
            int b = 0;
            int a = 0;
            if (checkBoxUsingFilter.Checked)
            {
                string imageNoValue = textBoxImageNoValue.Text.Trim();
                string[] array = imageNoValue.Split(',');
                if (array.Length != 4)
                {
                    MessageBox.Show("无效值不符合要求！", "提示");
                    return;
                }
                else
                {
                    if (int.TryParse(array[0], out r) == false
                        || int.TryParse(array[1], out g) == false
                        || int.TryParse(array[2], out b) == false
                        || int.TryParse(array[3], out a) == false)
                    {
                        MessageBox.Show("无效值不符合要求！", "提示");
                        return;
                    }
                }
            }
            
            this.buttonOK.Enabled = false;
            this.buttonCancel.Enabled = false;
            this.panel1.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            GSORasterMerge rasterMerge = new GSORasterMerge();
            //无效值过滤选择按钮可用
            if (checkBoxUsingFilter.Checked == true)
            {
                //无效值过滤模式
                rasterMerge.SetUseNoValueFilterMode(comboBoxFilterRegion.SelectedIndex + 1);                
            }
            if (checkBoxUsingFilter.Checked)
            {
                //无效值
                rasterMerge.SetImageNoValue(r, g, b, a);
            }
            //拼接进程
            rasterMerge.Stepped  += new SteppedEventHandler(rasterMerge_Stepped);
            for (int i = 0; i < dataGridViewDomList.Rows.Count; i++)
            {
                string dataPatho_old = dataGridViewDomList.Rows[i].Cells[1].Value.ToString();                
                rasterMerge.AddSrcData(dataPatho_old);
            }
            //保存生成文件
            rasterMerge.SetSavePath(dataPatho_new);
            bool isSaveSuccess = rasterMerge.MergeToLRPImage();            
            this.Cursor = Cursors.Default;
            if (isFormclosing == false)
            {
                MessageBox.Show("数据拼接成功！");
            }
            
            this.panel1.Enabled = true;
            this.Close();
        }


        int i = 0;
        void rasterMerge_Stepped(object sender, SteppedEventArgs e)
        {
            double percent = e.Percent * 100;
            if (percent > i)
            {
                i++;
                if (percent >= 99)
                {
                    percent = 100;
                }
                labelProcess.Text = "总进度[" + percent.ToString("0.00") + "%]";
                progressBarAll.Value = (int)percent;
                Application.DoEvents();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panelFilterSetting.Enabled = checkBoxUsingFilter.Checked;
        }

        private void buttonOutputPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.lrp|*.lrp";
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBoxOutputPath.Text = dlg.FileName;
            }
        }

        private void FrmDataJoinDom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.panel1.Enabled == false)
            {
                if (MessageBox.Show("有数据正在拼接，是否确定要关闭？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    isFormclosing = true;
                }
            }
        }
    }
}
