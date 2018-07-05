using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoScene.Builder;
using GeoScene.Data;
using System.IO;
using GeoScene.Engine;
using System.Threading;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace WorldGIS
{
    public partial class FormBatchMergeRaster : Form
    {
        private TaskbarManager taskbarManager = null;
        private string defTitle = string.Empty;
        DataTable dt = new DataTable();
        GSODataManager dataManager = new GSODataManager();
        Thread workThread = null; //执行
        Thread uithread = null;   //定时更新进度条
        GSOBatchMergeRaster BatchMergeRaster = new GSOBatchMergeRaster();
        int totalProgressValue = 0;//总文件进度
        DateTime dtStart; //开始执行的时间
        DateTime dtStartSub = DateTime.Now;//当前文件开始执行的时间

        public FormBatchMergeRaster()
        {
            InitializeComponent();
            taskbarManager = TaskbarManager.Instance;
            this.defTitle = this.Text;
        }

        private void FormBatchMergeRaster_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dt.Columns.Add("数据路径");
            dt.Columns.Add("投影信息");
            dataGridView1.DataSource = dt;
            comboBox_FilterPolygon.SelectedIndex = 0;
            textBox_R.Enabled = false;
            textBox_G.Enabled = false;
            textBox_B.Enabled = false;
            button_setColor.Enabled = false;
            comboBox_FilterPolygon.Enabled = false;
            textBox_ThresholdValue.Enabled = false;
        }

        private void button_AddData_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = true;
                dlg.Filter = "支持格式（*.tif,*.tiff,*.image,*.asc,*.raw,*.dem,*.adf,*.idr,*.sid,*.ecw,*.e00,*.ers,*.hdr,*.grd)|*.tif;*.tiff;*.image;*.asc;*.raw;*.dem;*.adf;*.idr;*.sid;*.ecw;*.e00;*.ers;*.hdr;*.grd|其他格式(*.*)|*.*";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    for (int i = 0; i < dlg.FileNames.Length; i++)
                    {
                        string fileName = dlg.FileNames[i];
                        FileInfo info = new FileInfo(fileName);
                        string lrpName = Path.ChangeExtension(fileName, ".lrp");
                        GSODataset set = dataManager.AddFileDataset(fileName);
                        EnumGeoReferenceType m = set.GeoReferenceType;

                        if (m == EnumGeoReferenceType.LatLon)
                        {
                            DataRow row = dt.Rows.Add();
                            row[0] = fileName;
                            row[1] = "经纬度数据";
                            dataGridView1.DataSource = dt;
                        }
                        else if (m == EnumGeoReferenceType.Project)
                        {
                            DataRow row = dt.Rows.Add();
                            row[0] = fileName;
                            row[1] = set.ExportProjectionRefToWkt();
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            DataRow row = dt.Rows.Add();
                            row[0] = fileName;
                            row[1] = "无投影信息";
                            dataGridView1.DataSource = dt;
                            //XtraMessageBox.Show("数据投影信息不符合要求，请先转换为经纬度数据");
                        }
                    }
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void button_AddDir_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog dlg = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            dlg.IsFolderPicker = true;
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                this.Cursor = Cursors.WaitCursor;
                DirectoryInfo dirInfo = new DirectoryInfo(dlg.FileName);
                FileInfo[] fileInfo = dirInfo.GetFiles();
                if (fileInfo != null && fileInfo.Length > 0)
                {
                    for (int i = 0; i < fileInfo.Length; i++)
                    {
                        FileInfo info = fileInfo[i];
                        if (info.Extension.ToLower() == ".img" || info.Extension.ToLower() == ".tif")
                        {
                            string fileName = info.FullName;
                            GSODataset set = dataManager.AddFileDataset(fileName);
                            GeoScene.Data.EnumGeoReferenceType m = set.GeoReferenceType;
                            if (m == GeoScene.Data.EnumGeoReferenceType.LatLon)
                            {
                                DataRow row = dt.Rows.Add();
                                row[0] = fileName;
                                row[1] = "经纬度数据";
                            }
                            else if (m == EnumGeoReferenceType.Project)
                            {
                                DataRow row = dt.Rows.Add();
                                row[0] = fileName;
                                row[1] = set.ExportProjectionRefToWkt();
                            }
                            else
                            {
                                DataRow row = dt.Rows.Add();
                                row[0] = fileName;
                                row[1] = "无投影信息";
                                //XtraMessageBox.Show("数据投影信息不符合要求，请先转换为经纬度数据");
                            }
                        }
                    }
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void button_removeSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }

        private void button_removeAll_Click(object sender, EventArgs e)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                dt.Rows.RemoveAt(i);
            }
            dataGridView1.Refresh();
        }

        private void button_SavePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.lrp|.lrp";
            if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_SavePath.Text = sfd.FileName;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox_R.Enabled = true;
                textBox_G.Enabled = true;
                textBox_B.Enabled = true;
                button_setColor.Enabled = true;
                comboBox_FilterPolygon.Enabled = true;
                textBox_ThresholdValue.Enabled = true;
            }
            else
            {
                textBox_R.Enabled = false;
                textBox_G.Enabled = false;
                textBox_B.Enabled = false;
                button_setColor.Enabled = false;
                comboBox_FilterPolygon.Enabled = false;
                textBox_ThresholdValue.Enabled = false;
            }
        }

        private void button_setColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_R.Text = dlg.Color.R.ToString();
                textBox_G.Text = dlg.Color.G.ToString();
                textBox_B.Text = dlg.Color.B.ToString();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            List<String> listPath = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listPath.Add(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                }
            }
            else
            {
                MessageBox.Show("请先添加数据！", "提示");
                return;
            }
            BatchMergeRaster.AddProcessMergeData(listPath, "");


            if (textBox_SavePath.Text.Trim() != "")
            {
                BatchMergeRaster.SaveFilePath = textBox_SavePath.Text.Trim();
            }
            else
            {
                MessageBox.Show("请选择保存路径！", "提示");
                return;
            }

            if (checkBox1.Checked)
            {
                if (comboBox_FilterPolygon.SelectedIndex == 0)
                {
                    BatchMergeRaster.NoValueFilterMode(Enum_NoValueFilterMode.NVFM_Allregion);
                }
                else
                {
                    BatchMergeRaster.NoValueFilterMode(Enum_NoValueFilterMode.NVFM_OverlapRegion);
                }

                int R = Convert.ToInt32(textBox_R.Text);
                int G = Convert.ToInt32(textBox_G.Text);
                int B = Convert.ToInt32(textBox_B.Text);
                double Threshold = Convert.ToDouble(textBox_ThresholdValue.Text);
                BatchMergeRaster.SetFilterParament(Color.FromArgb(R, G, B));
                BatchMergeRaster.Threshold = Threshold;
            }
            button_OK.Enabled = false;
            button_AddData.Enabled = false;
            button_AddDir.Enabled = false;
            button_removeSelect.Enabled = false;
            button_removeAll.Enabled = false;
            panel_SvaPath.Enabled = false;
            panel_NoValue.Enabled = false;
            dtStart = DateTime.Now;

            BatchMergeRaster.BIDGetProgressInfoEvent -= BatchMergeRaster_BIDGetProgressInfoEvent;
            BatchMergeRaster.BIDGetProgressInfoEvent += BatchMergeRaster_BIDGetProgressInfoEvent;

            workThread = new Thread(this.ProcessDataThreadFunc);
            workThread.Start();

            //更新进度条
            uithread = new Thread(new ThreadStart(this.UpdateProgressThreadFunc));
            uithread.Start();
        }

        private void BatchMergeRaster_BIDGetProgressInfoEvent(object sender, BIDGetProgressInfoEventArgs e)
        {
            int currentValue = (int)(e.ProgressRadio * 100);
            totalProgressValue = currentValue > 99 ? currentValue : currentValue + 1;
        }

        private void ProcessDataThreadFunc(object obj)
        {
            if (BatchMergeRaster != null)
            {
                BatchMergeRaster.MergeToLRPImage();
                this.Invoke(new Action<int>(this.OnFinished), 0);
            }
        }

        private void UpdateProgressThreadFunc()
        {
            while (true)
            {
                this.Invoke(new Action<int>(this.UpdateProgress), totalProgressValue);
                Thread.Sleep(100);
            }
        }

        private void UpdateProgress(int obj)
        {

            double timeUsed = (DateTime.Now - dtStart).TotalSeconds;
            label_AllProcess.Text = "总进度(" + timeUsed.ToString("F1") + "s)：";

            progressBar_All.Value = obj;
            label_totalProgress.Text = obj + "%";
            taskbarManager.SetProgressValue(obj, 100, this.Handle);
            this.Text = $"{obj}% - {defTitle}";
        }

        private void OnFinished(int obj)
        {
            if (workThread != null)
            {
                workThread.Abort();
            }
            if (uithread != null)
            {
                uithread.Abort();
            }
            this.Cursor = Cursors.Default;
            button_OK.Enabled = true;
            button_AddData.Enabled = true;
            button_AddDir.Enabled = true;
            button_removeSelect.Enabled = true;
            button_removeAll.Enabled = true;
            panel_SvaPath.Enabled = true;
            panel_NoValue.Enabled = true;
            MessageBox.Show("处理完成!", "提示");
            this.Text = defTitle;
        }

        private void FormBatchMergeRaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workThread != null)
            {
                workThread.Abort();
            }
            if (uithread != null)
            {
                uithread.Abort();
            }
        }
    }
}
