using System;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 分析
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        string trackPolygonType = String.Empty;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            globeControl1.Globe.LatLonGrid.Visible = false; //关闭经纬网

            //添加地形，方便分析
            GSOTerrain terrain = globeControl1.Globe.Terrains.Add(Application.StartupPath + "/Resource/dem/TestDem.tif");
            //添加影像，方便分析
            globeControl1.Globe.Layers.Add(Application.StartupPath + "/Resource/gisdata/tianditudata/天地图影像.lrc");

            //移动视角，方便分析
            flyToLayerOrTerrain(globeControl1,terrain.LatLonBounds);
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

        /// <summary>
        /// 通视分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //通视分析
            globeControl1.Globe.Action = EnumAction3D.VisibilityAnalysis;
        }

        /// <summary>
        /// 可视域分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //可视域分析
            globeControl1.Globe.Action = EnumAction3D.ViewshedAnalysis;
        }

        /// <summary>
        /// 雷达分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //雷达分析
            globeControl1.Globe.Action = EnumAction3D.ViewEnvelopeAnalysis;
        }

        /// <summary>
        /// 清除分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ClearAnalysis();
        }
    }
}
