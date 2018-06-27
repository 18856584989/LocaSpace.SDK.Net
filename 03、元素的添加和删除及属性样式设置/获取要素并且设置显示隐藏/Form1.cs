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

namespace 获取要素并且设置显示隐藏
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        GSOFeature feature; //创建一个全局变量
        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 创建面要素和飞到面
            GSOGeoPolygon3D geoPolygon = new GSOGeoPolygon3D(); //创建多边形对象

            //创建节点对象
            GSOPoint3ds polygonPnts = new GSOPoint3ds();
            polygonPnts.Add(new GSOPoint3d(116.7, 39.8, 0));
            polygonPnts.Add(new GSOPoint3d(116.8, 39.9, 0));
            polygonPnts.Add(new GSOPoint3d(116.8, 39.7, 0));
            polygonPnts.Add(new GSOPoint3d(116.7, 39.7, 0));

            geoPolygon.AddPart(polygonPnts);    //把节点添加到多边形对象上

            GSOSimplePolygonStyle3D stylePolygon = new GSOSimplePolygonStyle3D();    //创建风格
            stylePolygon.OutLineVisible = true;    //显示多边形的边缘线
            //设置多边形的填充颜色，FromArgb()中的四个参数分别为alpha、red、green、blue，取值范围为0到255 
            stylePolygon.FillColor = Color.FromArgb(100, 255, 255, 0);
            geoPolygon.Style = stylePolygon;  //把风格添加到多边形上

            //下面不属于工程内容，只是飞到点的位置
            GSOCameraState cs = new GSOCameraState();
            cs.Longitude = 116.75;
            cs.Latitude = 39.8;
            cs.Altitude = 50000;
            globeControl1.Globe.FlyToCameraState(cs);

            #endregion

            //创建几何对象并设置属性
            GSOFeature f = new GSOFeature();
            f.Geometry = geoPolygon;
            f.Name = "多边形 01";
            f.CustomID = 1;
            f.SetFieldValue("description", "a demo polygon");
            f.Description = "这是一个多边形";

            //将面添加到球中
            feature = globeControl1.Globe.MemoryLayer.AddFeature(f);  //添加的时候获取要素
        }

        /// <summary>
        /// 全局变量获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("获取到：" + feature.Name);
        }

        /// <summary>
        /// 根据属性获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            GSOFeature myFeature = null;
            //根据CustomID获取
            //myFeature = globeControl1.Globe.MemoryLayer.GetFeatureByCustomID(1);

            //根据ID来获取要素
            //myFeature = globeControl1.Globe.MemoryLayer.GetFeatureByID(1);

            //根据名称获取要素
            //myFeature = globeControl1.Globe.MemoryLayer.GetFeatureByName("多边形 01", true)[0];

            //根据描述获取要素
            myFeature = globeControl1.Globe.MemoryLayer.GetFeatureByDescription("这是一个多边形", true)[0];

            MessageBox.Show("获取到：" + (myFeature == null ? "null" : myFeature.Name));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //添加球点击事件
            globeControl1.FeatureMouseClickEvent += (o, args) =>
            {
                //判断是否为模型
                if (args.Feature != null)
                {
                    MessageBox.Show("获取到:" + args.Feature.Name);
                }
            };
        }

        #region 选中要素获取

        private void button4_Click(object sender, EventArgs e)
        {
            //判断如果已经进入选中模式，就返回正常模式
            if (globeControl1.Globe.Action == EnumAction3D.SelectObject)
            {
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                return;
            }

            //改变球为选中模式
            globeControl1.Globe.Action = EnumAction3D.SelectObject;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GSOFeature myFeature = null;
            myFeature = globeControl1.Globe.SelectedObject;
            MessageBox.Show("获取到:" + (myFeature == null?"null":myFeature.Name));
        }

        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            feature.Visible = !feature.Visible;
            //刷新球
            globeControl1.Refresh();
        }
    }
}
