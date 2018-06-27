using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 元素的添加和删除及属性样式设置
{
    public partial class Form1 : Form
    {

        GSOGlobeControl globeControl1;

        private GSOFeature lineFeature = null;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //加载图层，方便观察
            globeControl1.Globe.Layers.Add(
                Application.StartupPath + "/Resource/gisdata/tianditudata/" +
                "天地图影像.lrc");
        }

        #region 创建点

        /// <summary>
        /// 创建点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPoint_Click(object sender, EventArgs e)
        {

            GSOGeoMarker point = new GSOGeoMarker();    //创建点对象
            point.X = 120.417888231016;                          //设置点X的值，单位为度
            point.Y = 31.3283140323302;                           //设置点Y的值，单位为度
            point.Z = 20;                              //设置点Z的值，单位为米
            point.AltitudeMode = EnumAltitudeMode.RelativeToGround;//设置点的高程模式，设置为相对地面。则点的为（X,Y）处地面高程上方100米（point.Z = 100）
            point.Text = "中科图新";                    //设置点对象显示的文字
            GSOMarkerStyle3D mstyle = new GSOMarkerStyle3D();//新建点样式
            mstyle.IconPath = Application.StartupPath + "\\Resource\\image\\DefaultIcon.png";//设置图标路径
            point.Style = mstyle;                       //把显示风格
            GSOFeature feature = new GSOFeature();      //创建几何要素
            feature.Geometry = point;                   //把点赋予集合要素
            feature.Name = point.Text;                  //赋予名字
            globeControl1.Globe.MemoryLayer.AddFeature(feature);//将要素添加到图层中

            //下面不属于工程内容，只是飞到点的位置
            GSOCameraState cs = new GSOCameraState();
            cs.Longitude = point.X;
            cs.Latitude = point.Y;
            cs.Altitude = 1000;
            globeControl1.Globe.FlyToCameraState(cs);
        }

        #endregion

        #region 创建线

        /// <summary>
        /// 创建线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLine_Click(object sender, EventArgs e)
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
            lineFeature = new GSOFeature();
            lineFeature.Geometry = line;           //把线对象添加到几何对象上
            lineFeature.Name = "线 01";          //设置几何对象的名称
            lineFeature.SetFieldValue("description", "这是线的属性");       //设置几何对象的字段值
            //把几何要素添加到内存图层中
            globeControl1.Globe.MemoryLayer.AddFeature(lineFeature);

            //下面不属于工程内容，只是飞到点的位置
            GSOCameraState cs = new GSOCameraState();
            cs.Longitude = 116.62;
            cs.Latitude = 39.92;
            cs.Altitude = 9000;
            globeControl1.Globe.FlyToCameraState(cs);
        }

        #endregion

        #region 创建面

        /// <summary>
        /// 创建面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPolygon_Click(object sender, EventArgs e)
        {
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

            //创建几何对象并设置属性
            GSOFeature f = new GSOFeature();
            f.Geometry = geoPolygon;
            f.Name = "多边形 01";
            f.SetFieldValue("description", "a demo polygon");

            //绑定数据
            btnRemovePolygon.Tag = f;

            globeControl1.Globe.MemoryLayer.AddFeature(f);  //把几何要素添加到内存图层中 

            //下面不属于工程内容，只是飞到点的位置
            GSOCameraState cs = new GSOCameraState();
            cs.Longitude = 116.75;
            cs.Latitude = 39.8;
            cs.Altitude = 50000;
            globeControl1.Globe.FlyToCameraState(cs);
        }

        #endregion

        #region 创建模型

        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddModel_Click(object sender, EventArgs e)
        {
            GSOGeoModel model = new GSOGeoModel(); //创建模型   
            GSOPoint3d pt = new GSOPoint3d(); //创建点
            pt.X = 116.6;
            pt.Y = 39.9;
            pt.Z = 0;

            GSOModelPointStyle3D style = new GSOModelPointStyle3D();  //创建模型的风格          
            model.Style = style;

            //模型可以是3ds、obj、gse、gsez格式的三维模型
            //模型所在路径，用户可根据实际情况进行设置
            string filepath = Application.StartupPath + "\\Model\\坦克.3ds";

            //设置模型
            model.FilePath = filepath;
            model.Position = pt;

            model.AltitudeMode = EnumAltitudeMode.ClampToGround; //把几何体放到地面上

            GSOFeature f = new GSOFeature(); //创建几何要素
            f.Geometry = model;
            f.Name = "模型 01";
            f.Description = "模型 01";  //设置feature description的值，这个值将在tooltip上显示

            //把几何要素添加到内存图层中 
            globeControl1.Globe.MemoryLayer.AddFeature(f);

            //飞行到模型所在的位置
            globeControl1.Globe.FlyToFeature(f);
        }

        #endregion

        private void btnRemovePoint_Click(object sender, EventArgs e)
        {
            //在球上查找后删除，可用Name,ID,Description等查找。
            GeoScene.Data.GSOFeature feature = globeControl1.Globe.MemoryLayer.GetFeatureByName("中科图新", false)[0];
            feature.Delete();
            globeControl1.Refresh();
        }

        private void btnRemoveLine_Click(object sender, EventArgs e)
        {
            //根据全局变量删除
            lineFeature.Delete();
            globeControl1.Refresh();
        }

        private void btnRemovePolygon_Click(object sender, EventArgs e)
        {
            //根据绑定数据删除
            (btnRemovePolygon.Tag as GSOFeature).Delete();
            globeControl1.Refresh();
        }

        private void btnRemoveModel_Click(object sender, EventArgs e)
        {
            //通过选中进行删除
            if (globeControl1.Globe.SelectedObject == null)
            {
                MessageBox.Show("已经切换为选择模式，请选择删除的要素，再点击此按钮！");
                globeControl1.Globe.Action = EnumAction3D.SelectObject;
                return;
            }

            globeControl1.Globe.Action = EnumAction3D.ActionNull;
            globeControl1.Globe.SelectedObject.Delete();
            globeControl1.Refresh();
        }
    }
}
