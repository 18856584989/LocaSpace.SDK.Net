using System;
using System.Drawing;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
using 剖面分析.剖面分析;

namespace 剖面分析
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        string trackPolygonType = String.Empty;
        string mouseClickInfo = String.Empty;
        Point mouseDown = new Point();

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;


            //添加分析分为线画完事件
            globeControl1.TrackPolylineEndEvent += new TrackPolylineEndEventHandler(globeControl1_TrackPolylineEndEvent);

            SetMouse();
        }

        #region 无关代码

        private void Form1_Load(object sender, EventArgs e)
        {
            globeControl1.Globe.LatLonGrid.Visible = false; //关闭经纬网

            //添加地形，方便分析
            GSOTerrain terrain = globeControl1.Globe.Terrains.Add(Application.StartupPath + "/Resource/dem/TestDem.tif");
            //添加影像，方便分析
            globeControl1.Globe.Layers.Add(Application.StartupPath + "/Resource/gisdata/tianditudata/天地图影像.lrc");

            //移动视角，方便分析
            flyToLayerOrTerrain(globeControl1, terrain.LatLonBounds);
        }

        #region 图层定位
        /// <summary>
        /// 图层定位
        /// </summary>
        /// <param name="globeControl1"></param>
        /// <param name="latLonBounds"></param>
        public static void flyToLayerOrTerrain(GSOGlobeControl globeControl1, GSORect2d latLonBounds)
        {
            if ((latLonBounds.Left.Equals(0.0) == false)
                                                    && (latLonBounds.Bottom.Equals(0.0) == false)
                                                    && (latLonBounds.Top.Equals(0.0) == false)
                                                    && (latLonBounds.Right.Equals(0.0) == false))
            {
                GSOPoint2d pntCenter = latLonBounds.Center;
                GSOPoint3d pntPostion = new GSOPoint3d();
                pntPostion.X = pntCenter.X;
                pntPostion.Y = pntCenter.Y;
                double dMaxGeoLen = Math.Max(latLonBounds.Width, latLonBounds.Height);
                double dSize = dMaxGeoLen * Math.PI * 6378137 / 90;
                pntPostion.Z = dSize > 20000000 ? dSize / 4 : dSize;
                globeControl1.Globe.FlyToPosition(pntPostion, EnumAltitudeMode.RelativeToGround);
            }
        }

        /// <summary>
        /// 绘制线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.DrawPolyline;
        }

        #endregion

        #endregion

        /// <summary>
        /// 分析范围面画完事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void globeControl1_TrackPolylineEndEvent(object sender, TrackPolylineEndEventArgs e)
        {
            if (e.Polyline != null)
            {
                if (trackPolygonType == "剖面分析")
                {
                    globeControl1.Globe.Action = GeoScene.Data.EnumAction3D.ActionNull;
                    //初始化
                    trackPolygonType = "";

                    FrmAnalysisProfileBaseLine frm = new FrmAnalysisProfileBaseLine(globeControl1, e.Polyline);
                    frm.Show(this);
                }
                else
                {
                    trackPolygonType = "";
                }
            }
        }

        /// <summary>
        /// 剖面分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.TrackPolyline;
            globeControl1.Globe.TrackPolylineTool.TrackMode = EnumTrackMode.GroundTrack;
            globeControl1.Globe.TrackPolylineTool.VerticalLineVisible = true;
            trackPolygonType = "剖面分析";
        }

        #region 选择线

        /// <summary>
        /// 选择线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.SelectObject;
            mouseClickInfo = "剖面分析";
        }

        private void SetMouse()
        {
            globeControl1.MouseDown += (sender, e) =>
            {
                mouseDown = e.Location;
            };

            globeControl1.MouseUp += (sender, e) =>
            {
                if (mouseDown != e.Location) return;

                if (e.Button == MouseButtons.Left)
                {
                    if (globeControl1.Globe.Action == EnumAction3D.SelectObject)
                    {
                        if (mouseClickInfo == "剖面分析")
                        {
                            GSOFeature feature = globeControl1.Globe.SelectedObject;
                            if (feature == null ||
                                feature.Geometry == null ||
                                feature.Geometry.Type != EnumGeometryType.GeoPolyline3D)
                            {
                                MessageBox.Show("请选择一条线");
                                return;
                            }
                            globeControl1.Globe.Action = EnumAction3D.ActionNull;
                            GSOGeoPolyline3D line = feature.Geometry as GSOGeoPolyline3D;
                            FrmAnalysisProfileBaseLine frm = new FrmAnalysisProfileBaseLine(globeControl1, line);
                            frm.Show(this);
                        }
                    }
                }
            };
        }

        #endregion
    }
}
