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
    public partial class FormBatchRasterImport : Form
    {
        TaskbarManager taskbarManager = TaskbarManager.Instance;
        private string defTitle = string.Empty;
        DataTable dt = new DataTable();
        GSODataManager dataManager = new GSODataManager();
        string saveDir = "";//保存目录
        Thread workThread = null; //执行
        Thread uithread = null;   //定时更新进度条
        GSOBatchRasterImporter rasterImporter = null;
        int subCurrentValue = 0;//当前文件的进度
        int totalProgressValue = 0;//总文件进度
        int indexFile = 1;
        DateTime dtStart = DateTime.Now;//开始执行的时间
        DateTime dtStartSub = DateTime.Now;//当前文件开始执行的时间

        public FormBatchRasterImport()
        {
            InitializeComponent();
            defTitle = this.Text;
        }

        private void button_AddData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "支持格式（*.tif,*.tiff,*.image,*.asc,*.raw,*.dem,*.adf,*.idr,*.sid,*.ecw,*.e00,*.ers,*.hdr,*.grd)|" +
                "*.tif;*.tiff;*.image;*.asc;*.raw;*.dem;*.adf;*.idr;*.sid;*.ecw;*.e00;*.ers;*.hdr;*.grd|其他格式(*.*)|*.*";

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    string fileName = dlg.FileNames[i];
                    FileInfo info = new FileInfo(fileName);
                    string lrpName = Path.ChangeExtension(fileName, ".lrp");
                    string savePath;
                    if (saveDir == "")
                    {
                        savePath = lrpName;
                    }
                    else
                    {
                        savePath = saveDir + Path.ChangeExtension(info.Name, ".lrp");
                    }

                    GSODataset set = dataManager.AddFileDataset(fileName);
                    GeoScene.Data.EnumGeoReferenceType m = set.GeoReferenceType;

                    if (m == GeoScene.Data.EnumGeoReferenceType.LatLon)
                    {
                        DataRow row = dt.Rows.Add();
                        row[0] = fileName;
                        row[1] = "经纬度数据";
                        row[2] = savePath;
                        dataGridView1.DataSource = dt;
                    }
                    else if (m == EnumGeoReferenceType.Project)
                    {
                        DataRow row = dt.Rows.Add();
                        row[0] = fileName;
                        row[1] = set.ExportProjectionRefToWkt();
                        row[2] = savePath;
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        DataRow row = dt.Rows.Add();
                        row[0] = fileName;
                        row[1] = "无投影信息";
                        row[2] = savePath;
                        dataGridView1.DataSource = dt;
                        //XtraMessageBox.Show("数据投影信息不符合要求，请先转换为经纬度数据");
                    }
                }
                dataGridView1.Refresh();
            }
        }

        private void FormBatchRasterImport_Load(object sender, EventArgs e)
        {
            panel_PolygonRestric.Enabled = false;
            panel_NoValue.Enabled = false;
            comboBox_Model.SelectedIndex = 0;
            dataGridView1.Columns.Clear();
            dt.Columns.Add("文件路径");
            dt.Columns.Add("投影信息");
            dt.Columns.Add("存储路径");
            dataGridView1.DataSource = dt;
            try
            {
                //根据cpu个数计算合适的线程数
                int nWorkThreadNum = System.Environment.ProcessorCount * 4 + 4;
                int m_nMaxThreadNumAllow = System.Environment.ProcessorCount * 8 + 8;

                if (m_nMaxThreadNumAllow < 8)
                {
                    m_nMaxThreadNumAllow = 8;
                }
                textBox_threadNum.Text = "" + nWorkThreadNum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel_PolygonRestric.Enabled = !panel_PolygonRestric.Enabled;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            panel_thread.Enabled = !panel_thread.Enabled;
        }

        private void checkBoxNoValue_CheckedChanged(object sender, EventArgs e)
        {
            panel_NoValue.Enabled = !panel_NoValue.Enabled;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_R.Text = dlg.Color.R.ToString();
                textBox_G.Text = dlg.Color.G.ToString();
                textBox_B.Text = dlg.Color.B.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.kml,*.shp,*.lgd)|*.kml;*.shp;*.lgd|All Files(*.*)|*.*";
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_polygonPath.Text = dlg.FileName;
            }

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            string savePath = Path.ChangeExtension(fileName, ".lrp");
                            GSODataset set = dataManager.AddFileDataset(fileName);
                            GeoScene.Data.EnumGeoReferenceType m = set.GeoReferenceType;
                            if (m == GeoScene.Data.EnumGeoReferenceType.LatLon)
                            {
                                DataRow row = dt.Rows.Add();
                                row[0] = fileName;
                                row[1] = "经纬度数据";
                                row[2] = savePath;
                            }
                            else if (m == EnumGeoReferenceType.Project)
                            {
                                DataRow row = dt.Rows.Add();
                                row[0] = fileName;
                                row[1] = set.ExportProjectionRefToWkt();
                                row[2] = savePath;
                            }
                            else
                            {
                                DataRow row = dt.Rows.Add();
                                row[0] = fileName;
                                row[1] = "无投影信息";
                                row[2] = savePath;
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

        private void button_SavaPath_Click(object sender, EventArgs e)
        {
            Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog dlg = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            dlg.IsFolderPicker = true;
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                this.Cursor = Cursors.WaitCursor;
                DirectoryInfo dirInfo = new DirectoryInfo(dlg.FileName);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FileInfo infoSave = new FileInfo(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                        string name = infoSave.Name;
                        saveDir = dlg.FileName + "\\";
                        dataGridView1.Rows[i].Cells[2].Value = dirInfo + "\\" + Path.ChangeExtension(name, ".lrp");
                    }
                }
                else
                {
                    saveDir = dlg.FileName + "\\";
                }
            }
            dataGridView1.Refresh();
            this.Cursor = Cursors.Default;
        }

        private void FormBatchRasterImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workThread != null)
            {
                workThread.Abort();
            }
            if (uithread != null)
            {
                uithread.Abort();
            }
            if (rasterImporter != null)
            {
                rasterImporter.Escape = true;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("请先添加数据！", "提示");
                return;
            }

            panel_NoValue.Enabled = false;
            panel_PolygonRestric.Enabled = false;
            panel_thread.Enabled = false;
            checkBoxNoValue.Enabled = false;
            checkBox_MulThread.Enabled = false;
            checkBox_polygonRestricted.Enabled = false;

            rasterImporter = new GSOBatchRasterImporter();
            //0：处理影像   1：处理地形
            rasterImporter.ImportType(Enum_ImportType.IT_Image);
            //无效值过滤
            bool useNoValueFilter = checkBoxNoValue.Checked;
            int R = 0, G = 0, B = 0;
            int valueYuZhi = 0;
            if (useNoValueFilter == true)
            {
                valueYuZhi = int.Parse(textBox_ThresholdValue.Text);
                try
                {
                    R = int.Parse(textBox_R.Text);
                    G = int.Parse(textBox_G.Text);
                    B = int.Parse(textBox_B.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无效值输入有误，请重新输入！", "提示");
                    return;
                }
                rasterImporter.NoValueFilterUsed = true;
                rasterImporter.SetFilterParament(Color.FromArgb(R, G, B), 0, valueYuZhi);
            }

            //多边形过滤

            bool polygonRes = checkBox_polygonRestricted.Checked;
            if (polygonRes == true)
            {
                if (comboBox_Model.SelectedIndex == 1)
                {
                    rasterImporter.RestricMode(Enum_RestricMode.RM_RougnFilter);
                }
                else
                {
                    rasterImporter.RestricMode(Enum_RestricMode.RM_PrecisionFilter);
                }
                string polygonPath = textBox_polygonPath.Text;
                GSODataManager dManager = new GSODataManager();
                GSOFeatureDataset dataset = dManager.AddFileDataset(polygonPath) as GSOFeatureDataset;
                GSOFeatures feature = dataset.GetAllFeatures();
                rasterImporter.SetRestrictedRegions(feature);//多边形范围
            }
            else
            {
                rasterImporter.RestricMode(Enum_RestricMode.RM_NoFilter);
            }

            //多线程
            bool useMulThread = checkBox_MulThread.Checked;
            int maxThreadNum = 30;  //线程的个数
            int maxCacheSize = 100; //单个文件的缓存，单位M
            if (useMulThread == true)
            {
                maxThreadNum = int.Parse(textBox_threadNum.Text);
                maxCacheSize = int.Parse(textBox_maxCacheSize.Text);
                rasterImporter.MutiThread = true;//多线程
                rasterImporter.MaxThreadNum = maxThreadNum;//最大线程数
                rasterImporter.ThreadCacheSize = maxCacheSize;//最大缓存
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strSrcDataPath = dt.Rows[i][0].ToString();
                string strDestDataPath = dt.Rows[i][2].ToString();
                rasterImporter.AddProcessData(strSrcDataPath, strDestDataPath, "", null);//添加数据
            }

            //单个进度条
            rasterImporter.BIDGetSubProgressInfoEvent -= rasterImporter_BIDGetSubProgressInfoEvent;
            rasterImporter.BIDGetSubProgressInfoEvent += rasterImporter_BIDGetSubProgressInfoEvent;
            //总进度条
            rasterImporter.BIDGetProgressInfoEvent -= rasterImporter_BIDGetProgressInfoEvent;
            rasterImporter.BIDGetProgressInfoEvent += rasterImporter_BIDGetProgressInfoEvent;

            subCurrentValue = 0;
            indexFile = 1;
            dtStart = DateTime.Now;
            dtStartSub = dtStart;
            label_AllProcess.Text = "总进度(" + 0 + "s)";
            label_CurrentProcess.Text = "当前进度(" + 1 + "/" + dt.Rows.Count + ")";
            this.progressBar_All.Value = 0;
            this.progressBar_Current.Value = 0;
            this.Cursor = Cursors.WaitCursor;
            button_OK.Enabled = false;

            //在单独的线程中执行操作
            workThread = new Thread(this.ProcessDataThreadFunc);
            workThread.Start();

            //更新进度条
            uithread = new Thread(new ThreadStart(this.UpdateProgressThreadFunc));
            uithread.Start();
        }

        //单个进度
        void rasterImporter_BIDGetSubProgressInfoEvent(object sender, BIDGetSubProgressInfoEventArgs e)
        {
            int currentValue = (int)(e.ProgressRadio * 100);
            subCurrentValue = currentValue;
        }
        //总进度
        void rasterImporter_BIDGetProgressInfoEvent(object sender, BIDGetProgressInfoEventArgs e)
        {
            int totalValue = (int)(e.ProgressRadio * 100);
            totalProgressValue = totalValue;
        }

        void ProcessDataThreadFunc()
        {
            if (rasterImporter != null)
            {
                rasterImporter.Import();
                this.Invoke(new Action<int>(this.OnFinished), 0);
            }
        }

        private void OnFinished(int v)
        {
            if (workThread != null)
            {
                workThread.Abort();
            }
            if (uithread != null)
            {
                uithread.Abort();
            }
            if (rasterImporter != null)
            {
                rasterImporter.Escape = true;
            }
            this.Cursor = Cursors.Default;

            progressBar_All.Value = 100;
            label_totalProgress.Text = "100%";
            button_OK.Enabled = true;
            checkBoxNoValue.Enabled = true;
            checkBox_MulThread.Enabled = true;
            checkBox_polygonRestricted.Enabled = true;
            if (checkBoxNoValue.Checked)
            {
                panel_NoValue.Enabled = true;
            }
            if (checkBox_MulThread.Checked)
            {
                panel_thread.Enabled = true;
            }
            if (checkBox_polygonRestricted.Checked)
            {
                panel_PolygonRestric.Enabled = true;
            }
            MessageBox.Show("处理完成!", "提示");
            this.Text = defTitle;
        }

        private void UpdateProgressThreadFunc()
        {
            while (true)
            {
                this.Invoke(new Action<int>(this.UpdateProgress), 0);
                Thread.Sleep(100);
            }
        }

        private void UpdateProgress(int v)
        {
            double timeUsed = (DateTime.Now - dtStart).TotalSeconds;
            label_AllProcess.Text = "总进度(" + timeUsed.ToString("F1") + "s)：";

            if (totalProgressValue > progressBar_All.Value)
            {
                if (indexFile < dt.Rows.Count)
                {
                    indexFile++;
                }
            }

            label_CurrentProcess.Text = "当前进度(" + indexFile + "/" + dt.Rows.Count + ")：";
            progressBar_Current.Value = subCurrentValue;
            label_subProgress.Text = progressBar_Current.Value + "%";
            progressBar_All.Value = totalProgressValue;
            label_totalProgress.Text = progressBar_All.Value + "%";
            //改变任务栏进度条
            taskbarManager.SetProgressValue(subCurrentValue, 100, this.Handle);
            //改变标题
            this.Text = $"{subCurrentValue}% ({indexFile / dt.Rows.Count})- {defTitle}";
        }
    }
}