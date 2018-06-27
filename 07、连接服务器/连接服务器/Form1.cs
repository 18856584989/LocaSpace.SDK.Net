using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 连接服务器
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        Dictionary<string, GSOLayer> layerDictionary = new Dictionary<string, GSOLayer>();
        bool isConnect = false;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            //在图层添加之后，网络图层添加的时候，是一个一个添加的
            globeControl1.AfterLayerAddEvent += (sender, e) =>
            {
                //添加到listbox中
                listBox1.Items.Add(e.Layer.Caption);
                //添加到字典中
                layerDictionary.Add(e.Layer.Caption, e.Layer);
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isConnect)
            {
                MessageBox.Show("已经连接上服务器了");
                return;
            }
            //IP地址
            string strIP = "data1.locaspace.cn";
            //用户名
            string strUser = "admin";
            //密码
            string strPsw = "admin";
            //端口
            int nPort = 1500;
            //连接服务器
            isConnect = globeControl1.Globe.ConnectServer(strIP, nPort, strUser, strPsw);
        }


        #region 单纯双击飞行事件


        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string layerName = listBox1.Items[Int32.Parse(index.ToString())].ToString();
                GSOLayer layer = layerDictionary[layerName];
                flyToLayerOrTerrain(globeControl1, layer.LatLonBounds);
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

        #endregion

    }
}
