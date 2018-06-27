using System;
using System.Drawing;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
using 填挖方分析.填挖方分析;

namespace 填挖方分析
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        string trackPolygonType = String.Empty;
        string mouseClikeInfo = String.Empty;
        Point mouseDown = new Point();

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            //添加分析范围面画完事件
            globeControl1.TrackPolygonEndEvent += new TrackPolygonEndEventHandler(globeControl1_TrackPolygonEndEvent);

            setMouse();
        }


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
        #endregion

        #region 绘制面分析

        /// <summary>
        /// 分析范围画完事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void globeControl1_TrackPolygonEndEvent(object sender, TrackPolygonEndEventArgs e)
        {
            if (e.Polygon != null)
            {
                if (trackPolygonType == "填挖方分析")
                {
                    globeControl1.Globe.Action = EnumAction3D.ActionNull;
                    FrmAnalysisDigFillOfTerrain frm = new FrmAnalysisDigFillOfTerrain(globeControl1, e.Polygon);
                    frm.Show(this);
                }
            }
        }

        #region 填挖方分析

        /// <summary>
        /// 填挖方分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
            globeControl1.Globe.TrackPolygonTool.TrackMode = EnumTrackMode.GroundTrack;
            trackPolygonType = "填挖方分析";
        }

        #endregion

        #endregion

        #region 选择面分析

        /// <summary>
        /// 绘制面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.DrawPolygon;
        }

        /// <summary>
        /// 选择面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.SelectObject;
            mouseClikeInfo = "填挖方分析";
        }

        private void setMouse()
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
                        if (mouseClikeInfo == "填挖方分析")
                        {
                            GSOFeature feature = globeControl1.Globe.SelectedObject;
                            if (feature == null ||
                                feature.Geometry == null ||
                                feature.Geometry.Type != EnumGeometryType.GeoPolygon3D)
                            {
                                MessageBox.Show("请选择一个面");
                                return;
                            }
                            globeControl1.Globe.Action = EnumAction3D.ActionNull;
                            GSOGeoPolygon3D polygon = feature.Geometry as GSOGeoPolygon3D;
                            FrmAnalysisDigFillOfTerrain frm = new FrmAnalysisDigFillOfTerrain(globeControl1, polygon);
                            frm.Show(this);
                        }
                    }
                }
            };
        }

        #endregion

    }
}
