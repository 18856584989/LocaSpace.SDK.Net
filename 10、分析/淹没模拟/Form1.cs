using System;
using System.Drawing;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
using 淹没模拟.淹没模拟;

namespace 淹没模拟
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        string trackPolygonType = null;
        Point mouseDown = new Point();

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            //画完范围事件
            globeControl1.TrackPolygonEndEvent += (sender, e) =>
            {
                if (trackPolygonType == "淹没模拟")
                {
                    globeControl1.Globe.Action = EnumAction3D.ActionNull;
                    FrmAnalysisFloodSubmerge frm = new FrmAnalysisFloodSubmerge(globeControl1, e.Polygon);
                    frm.Show(this);
                }
            };

            //记录鼠标落下的坐标
            globeControl1.MouseDown += (sender, e) =>
            {
                mouseDown = e.Location;
            };

            //判断鼠标抬起时，坐标位置不变
            globeControl1.MouseUp += (sender, e) =>
            {
                if (mouseDown == e.Location)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (globeControl1.Globe.Action == EnumAction3D.SelectObject)
                        {
                            if (trackPolygonType == "淹没模拟")
                            {
                                GSOFeature feature = globeControl1.Globe.SelectedObject;
                                if (feature == null||feature.Geometry == null
                                    || feature.Geometry.Type != EnumGeometryType.GeoPolygon3D)
                                {
                                    MessageBox.Show("请选择一个面");
                                    return;
                                }
                                GSOGeoPolygon3D ePolygon = feature.Geometry as GSOGeoPolygon3D;
                                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                                FrmAnalysisFloodSubmerge frm = new FrmAnalysisFloodSubmerge(globeControl1,ePolygon);
                                frm.Show(this);
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// 加载地形，方便测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
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

        #region 画范围模拟

        /// <summary>
        /// 淹没模拟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
            globeControl1.Globe.TrackPolygonTool.TrackMode = EnumTrackMode.GroundTrack;
            trackPolygonType = "淹没模拟";
        }

        #endregion

        #region 选择范围模拟
        /// <summary>
        /// 创建面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.DrawPolygon;
        }

        /// <summary>
        /// 选择面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.SelectObject;
            trackPolygonType = "淹没模拟";
        }

        #endregion
    }
}
