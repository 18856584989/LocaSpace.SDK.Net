using System;
using System.Drawing;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 飞行模式
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        GSOFeature feature;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //创建一条线，用于沿线飞行
            feature = makeLine();
        }

        #region 创建线

        private GSOFeature makeLine()
        {
            GSOGeoPolyline3D line = new GSOGeoPolyline3D(); //创建线对象
            GSOPoint3ds pnts = new GSOPoint3ds(); //创建节点对象

            pnts.Add(new GSOPoint3d(116.6, 39.9, 1000));    //把各节点添加到节点对象上
            pnts.Add(new GSOPoint3d(116.61, 39.91, 3000));
            pnts.Add(new GSOPoint3d(116.62, 39.92, 2000));
            pnts.Add(new GSOPoint3d(116.63, 39.90, 2500));
            pnts.Add(new GSOPoint3d(116.64, 39.94, 4000));
            line.AddPart(pnts); //把节点添加到线上

            GSOSimpleLineStyle3D style = new GSOSimpleLineStyle3D(); //创建线的风格
            //设置透明度及颜色，FromArgb()中的四个参数分别为alpha、red、green、blue，取值范围为0到255
            style.LineColor = Color.FromArgb(150, 0, 255, 0);
            style.LineWidth = 3;          //设置线的宽度为3
            style.VertexVisible = true; 	//显示线的节点
            line.Style = style;          //把风格添加到线上

            //创建几何对象并设置属性
            GSOFeature f = new GSOFeature();
            f.Geometry = line;           //把线对象添加到几何对象上
            f.Name = "线 01";          //设置几何对象的名称
            f.SetFieldValue("description", "这是线的属性");       //设置几何对象的字段值
            //把几何要素添加到内存图层中
            globeControl1.Globe.MemoryLayer.AddFeature(f);

            //下面不属于工程内容，只是飞到点的位置
            GSOCameraState cs = new GSOCameraState();
            cs.Longitude = 116.62;
            cs.Latitude = 39.92;
            cs.Altitude = 9000;
            globeControl1.Globe.FlyToCameraState(cs);

            return f;
        }

        #endregion

        #region FlyAlongWithLine

        /// <summary>
        /// FlyAlongWithLine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
            {
                GSOGeoPolyline3D line3d = feature.Geometry as GSOGeoPolyline3D;

                globeControl1.Globe.FlyAlongLineRotateSpeed = 2000;  //过弯速度
                globeControl1.Globe.FlyAlongLineSpeed = 500;       //飞行速度
                //globeControl1.Globe.FlyToPointSpeed = 5000;         //飞到点速度
                
                double dHeightAboveLine = 100;  //高于线
                double dHeading = 0;             //视角夹角
                double dTilt = 80;                   //水平夹角
                globeControl1.Globe.FlyAlongWithLine(line3d,dHeightAboveLine,dHeading,dTilt);
            }
        }

        #endregion

        #region FlyEyeAlongWithLine

        /// <summary>
        /// FlyEyeAlongWithLine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
            {
                GSOGeoPolyline3D line3d = feature.Geometry as GSOGeoPolyline3D;

                double dHeightAboveLine = 100;  //高于线
                double dHeading = 0;             //视角夹角
                double dTilt = 80;                   //水平夹角
                globeControl1.Globe.FlyEyeAlongWithLine(line3d,dHeightAboveLine,0,true,0,false);
            }
        }

        #endregion

        #region 绕中心点飞行

        /// <summary>
        /// 绕中心点飞行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.FlyAroundCenter();
        }

        #endregion

        #region 绕视角飞行

        /// <summary>
        /// 绕视角飞行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.FlyAroundEye();
        }

        #endregion

        #region 绕要素飞行

        /// <summary>
        /// 绕要素飞行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.FlyAroundFeature(feature, true, 100, EnumFlyRepeatValueType.Degrees);
        }

        #endregion

        #region 暂停飞行

        /// <summary>
        /// 暂停飞行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.PauseFly();
        }

        #endregion

        #region 继续飞行

        /// <summary>
        /// 继续飞行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ContinueFly();
        }

        #endregion

        #region 停止飞行

        /// <summary>
        /// 停止飞行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.StopFly();
        }

        #endregion
    }
}
