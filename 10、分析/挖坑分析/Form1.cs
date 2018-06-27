using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 挖坑分析
{
    public partial class Form1 : Form
    {
        private GSOGlobeControl globeControl1;
        private string TracPolygonType;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            globeControl1.TrackPolygonEndEvent += GlobeControl1OnTrackPolygonEndEvent;
        }

        private void GlobeControl1OnTrackPolygonEndEvent(object sender, TrackPolygonEndEventArgs e)
        {
            GSOGeoPolygon3D polygon = e.Polygon;
            if (TracPolygonType == "挖坑")
            {
                //创建坑对象
                GSOGeoPit pit = new GSOGeoPit();
                pit.PitDepthUsing = true;   //是否使用深度
                pit.PitDepth = 10;          //深度
                pit.PitPolygon = polygon;   //坑的面
                globeControl1.Globe.AddPit("坑1",pit);
            }
        }

        /// <summary>
        /// 挖坑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //绘制面
            globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
            globeControl1.Globe.TrackPolygonTool.TrackMode = EnumTrackMode.GroundTrack;
            TracPolygonType = "挖坑";
            globeControl1.Refresh();
        }
    }
}
