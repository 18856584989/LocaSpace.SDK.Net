using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
using WorldGIS;

namespace 输出
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        string sizeStr = "{0}*{1} 像素";

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 影像拼接以及无效值过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FrmDataJoinDom frm = new FrmDataJoinDom(globeControl1);
            frm.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = false;
            openfile.Filter = "*.lrp|*.lrp";
            if (openfile.ShowDialog(this) == DialogResult.OK)
            {
                GSOLayer layer = globeControl1.Globe.Layers.Add(openfile.FileName);
                flyToLayerOrTerrain(globeControl1,layer.LatLonBounds);
            }
        }

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
    }
}
