using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace _3D可视域分析
{
    public partial class Form1 : Form
    {
        private GSOGlobeControl globeControl1;
        //3D可视域分析
        //第一个分析
        GSOViewshed3DAnalysis curViewshed3DAnalysis;
        //其他分析
        GSOViewshed3DAnalysis curViewshed3DAnalysisOther;
        //其他判断
        Boolean bViewshed3DAnalysisCheck = false;
        Boolean bViewshed3DAnalysising = false;
        GSOPoint3d pntDistDirPoint;
        GSOPoint3d pntViewerPos;


        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            globeControl1.MouseDown += GlobeControl1OnMouseDown;
            globeControl1.MouseMove += GlobeControl1OnMouseMove;
        }

        /// <summary>
        /// 鼠标移动的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobeControl1OnMouseMove(object sender, MouseEventArgs e)
        {
            //3D可视域分析
            {
                if (bViewshed3DAnalysisCheck && bViewshed3DAnalysising)
                {
                    //如果是第一次分析
                    if (curViewshed3DAnalysisOther == null)
                    {
                        GSOLayer resLayer = null;
                        GSOPoint3d resIntersectPoint;
                        globeControl1.Globe.HitTest(e.X, e.Y, out resLayer, out resIntersectPoint, false, true, 0);
                        pntDistDirPoint = resIntersectPoint;
                        curViewshed3DAnalysis.SetDistDirByPoint(resIntersectPoint);
                    }
                        //如果是其他分析
                    else
                    {
                        GSOLayer resLayer = null;
                        GSOPoint3d resIntersectPoint;
                        globeControl1.Globe.HitTest(e.X, e.Y, out resLayer, out resIntersectPoint, false, true, 0);
                        pntDistDirPoint = resIntersectPoint;
                        curViewshed3DAnalysisOther.SetDistDirByPoint(resIntersectPoint);
                    }
                }
            }
        }

        /// <summary>
        /// 可视域分析，当鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mouseEventArgs"></param>
        private void GlobeControl1OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //如果进入可视域分析状态
                if (bViewshed3DAnalysisCheck)
                {
                    GSOLayer resLayer = null;
                    GSOPoint3d resIntersectPoint;
                    //测试点击，返回点击图层和点位置信息
                    globeControl1.Globe.HitTest(e.X, e.Y, out resLayer, out resIntersectPoint, false, true, 0);

                    //如果为第一次分析，并且为设置视点（第一次点击）
                    if (curViewshed3DAnalysis != null && !bViewshed3DAnalysising &&
                        curViewshed3DAnalysisOther == null)
                    {
                        //设置可视域分析视点
                        curViewshed3DAnalysis.ViewerPosition = resIntersectPoint;
                        pntViewerPos = resIntersectPoint;
                        bViewshed3DAnalysising = true;
                    }
                    //如果为第二次分析，设置第二次分析视点（第一次点击）
                    else if (curViewshed3DAnalysisOther != null && !bViewshed3DAnalysising)
                    {
                        curViewshed3DAnalysisOther.ViewerPosition = resIntersectPoint;
                        pntViewerPos = resIntersectPoint;
                        bViewshed3DAnalysising = true;
                    }
                    //如果不是第一次点击
                    else
                    {
                        //如果其他分析为空，则为第一次分析，设置视线点（第二次点击）
                        if (curViewshed3DAnalysisOther == null)
                        {
                            curViewshed3DAnalysis.SetDistDirByPoint(resIntersectPoint);
                        }
                        //如果其他分析不为空，为第二次分析，设置视线点并且与第一次分析的关联（第二次点击)
                        if (curViewshed3DAnalysisOther != null)
                        {
                            curViewshed3DAnalysisOther.SetDistDirByPoint(resIntersectPoint);
                            //curViewshed3DAnalysisOther.VisibleAreaColor = Color.FromArgb(128, 255, 255, 0);
                            //curViewshed3DAnalysisOther.HiddenAreaColor = Color.FromArgb(128, 0, 0, 255);

                            //用第一个分析关联其他可视域分析
                            //如果有三个可视域分析，只能A关联B，A关联C。！！不能A关联B，B关联C！！
                            curViewshed3DAnalysis.AttachViewshed3DAnalysis(curViewshed3DAnalysisOther);
                        }
                        //关闭可视域分析状态
                        bViewshed3DAnalysisCheck = false;
                        bViewshed3DAnalysising = false;
                    }
                }
            }
        }

        /// <summary>
        /// 可视域分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //如果第一个分析为空，则为第一个分析
            if (curViewshed3DAnalysis == null)
            {
                curViewshed3DAnalysis = new GSOViewshed3DAnalysis(globeControl1.Globe);
            }
            //否则为其他分析
            else
            {
                curViewshed3DAnalysisOther = new GSOViewshed3DAnalysis(globeControl1.Globe);
            }
            bViewshed3DAnalysisCheck = true;
            globeControl1.Refresh();
        }

        /// <summary>
        /// 清除分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ClearAnalysis();
            //清空可视域分析
            curViewshed3DAnalysis = curViewshed3DAnalysisOther = null;
        }

        #region 添加倾斜摄影图层

        /// <summary>
        /// 添加倾斜摄影图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "支持格式(*.lfp)|*.lfp|所有文件(*.*)|*.*";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    string strDataPath = dlg.FileNames[i];
                    GSOLayer layer = globeControl1.Globe.Layers.Add(strDataPath);
                    if (layer != null)
                    {
                        flyToLFPLayer(layer);
                    }
                }
            }
        }

        /// <summary>
        /// 飞行到lfp的中心点
        /// </summary>
        /// <param name="layer"></param>
        private void flyToLFPLayer(GSOLayer layer)
        {
            try
            {
                if (layer == null)
                {
                    return;
                }
                string lfpString = "";
                using (StreamReader reader = new StreamReader(layer.Name))
                {
                    lfpString = reader.ReadToEnd();
                }

                int indexPosition = lfpString.IndexOf("<Position>");
                int indexPositionEnd = lfpString.IndexOf("</Position>");
                string position = lfpString.Substring(indexPosition + 10, indexPositionEnd - indexPosition - 10);
                double x = 0.0;
                double y = 0.0;
                double z = 0.0;
                string[] positionArray = position.Split(',');
                for (int i = 0; i < positionArray.Length; i++)
                {
                    if (i == 0)
                    {
                        if (double.TryParse(positionArray[i], out x))
                        {

                        }
                    }
                    else if (i == 1)
                    {
                        if (double.TryParse(positionArray[i], out y))
                        {

                        }
                    }
                    else if (i == 2)
                    {
                        if (double.TryParse(positionArray[i], out z))
                        {

                        }
                    }
                }
                GSOCameraState camestate = new GSOCameraState();
                camestate.Longitude = x;
                camestate.Latitude = y;
                camestate.Distance = 1500;
                globeControl1.Globe.JumpToCameraState(camestate);
            }
            catch (Exception e)
            {

            }
        }

        #endregion
    }
}
