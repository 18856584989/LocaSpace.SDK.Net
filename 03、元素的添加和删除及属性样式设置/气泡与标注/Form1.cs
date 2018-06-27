using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
using WorldGIS;

namespace 气泡与标注
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        GSOBalloon featureTooltip;
        GSOBalloonEx balloonEx;

        bool islabel = false;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            //点击节点飞行到要素全貌
            treeView1.NodeMouseDoubleClick += (sender, e) =>
            {
                if (e.Node.Tag.GetType() == typeof(GSOFeature))
                {
                    GSOFeature feature = e.Node.Tag as GSOFeature;
                    if (feature.Geometry.CameraState == null)
                    {
                        GSORect2d latLonBounds = feature.Geometry.Bounds;
                        if ((latLonBounds.Left.Equals(0.0) == false)
                            && (latLonBounds.Bottom.Equals(0.0) == false)
                            && (latLonBounds.Top.Equals(0.0) == false)
                            && (latLonBounds.Right.Equals(0.0) == false))
                        {
                            Utility.flyToLayerOrTerrain(globeControl1,latLonBounds);
                        }
                    }
                }
            };

            #region Balloon初始化

            featureTooltip = new GSOBalloon(globeControl1.Handle);      //实例化GSOBalloon对象
            featureTooltip.SetSize(EnumSizeIndex.ROUNDED_CX, 5); // 设置边角的圆润度
            featureTooltip.SetSize(EnumSizeIndex.ROUNDED_CY, 5); // 设置边角的圆润度
            featureTooltip.SetSize(EnumSizeIndex.MARGIN_CX, 3);  // 设置空白边缘宽度
            featureTooltip.SetSize(EnumSizeIndex.MARGIN_CY, 3);  // 设置空白边缘宽度
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_HEIGHT, 30); // 设置GSOBalloon 锚的高度
            featureTooltip.EscapeSequencesEnabled = true;
            featureTooltip.HyperlinkEnabled = true;  // 设置是否可以点击GSOBalloon里面的超链接
            featureTooltip.Opaque = 0;  // 透明度，取值范围是0～100，0为不透明，100为全透明
            featureTooltip.MaxWidth = 300;  // 最大宽度
            featureTooltip.SetBorder(Color.FromArgb(255, 255, 128, 64), 1, 1);  // 边框
            featureTooltip.SetColorBkType(EnumBkColorType.SILVER);  //填充颜色
            // 也可以下面方法设置
            //featureTooltip.SetColorBk(Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255,240, 247, 250), Color.FromArgb(255,192, 192, 200));
            featureTooltip.SetEffectBk(EnumBkEffect.VBUMP, 10); //渐变效果
            featureTooltip.SetShadow(0, 0, 50, true, 0, 0); // 阴影
            //featureTooltip.CloseButtonVisible = true;  //显示关闭按钮

            //鼠标进入显示气泡
            globeControl1.FeatureMouseIntoEvent += (sender, e) =>
            {
                if (!featureTooltip.IsVisible())
                {
                    String str1 = "<table><tr><td valign=vcenter><center><h2> " + e.Feature.Name + "</h2><br><hr color=blue></center></td></tr></table>";
                    String str2 = e.Feature.Description;

                    // 显示GSOBalloon
                    featureTooltip.ShowBalloon((int)e.MousePos.X, (int)e.MousePos.Y, str1 + str2);

                }
            };

            //鼠标移出时隐藏气泡
            globeControl1.FeatureMouseOutEvent += (sender, e) =>
            {
                if (featureTooltip.IsVisible())
                {
                    globeControl1.SwapBuffer(); //为了避免闪屏
                    featureTooltip.HideBalloon();
                }

            };

            #endregion

            #region BalloonEx初始化

            balloonEx = new GSOBalloonEx(globeControl1.Handle);
            //点击要素显示
            globeControl1.FeatureMouseClickEvent += (sender, e) =>
            {
                GSOBalloonParam balloonParam = balloonEx.ParseParam(e.Feature.Description);
                balloonEx.ShowBalloonEx((int)e.MousePos.X,(int)e.MousePos.Y,balloonParam);
            };

            #endregion

            //移动视角时，隐藏气泡
            globeControl1.CameraBeginMoveEvent += (sender, args) =>
            {
                balloonEx.HideBalloon();
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载要素，写入到treeviwe中

            #region 点

            AddPoint();

            #endregion

            #region 线

            AddLine();

            #endregion

            #region 面

            AddPolygon();

            #endregion

            #region 模型

            AddModel();

            #endregion

            //
            RefreshTreeNode();
        }

        #region 添加要素

        private void AddPoint()
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
            feature.Description = string.Format("<img src=\"{0}\">",Application.StartupPath + "\\Resource\\image\\Balloon\\Balloon.png");

            globeControl1.Globe.MemoryLayer.AddFeature(feature);//将要素添加到图层中
        }

        private void AddLine()
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
            GSOFeature lineFeature = new GSOFeature();
            lineFeature.Geometry = line;           //把线对象添加到几何对象上
            lineFeature.Name = "线 01";          //设置几何对象的名称
            lineFeature.SetFieldValue("description", "这是线的属性");       //设置几何对象的字段值

            lineFeature.Description = "<html>\r\n<head>\r\n<style>\r\n#tab-list {\r\nborder-collapse:collapse;\r\nfont-size:15px;\r\nmargin:20px;\r\ntext-align:left;\r\nwidth:280px;\r\n}\r\n\r\n#tab-list th {\r\nborder-bottom:2px solid #6678B1;\r\ncolor:#003399;\r\nfont-size:14px;\r\nfont-weight:normal;\r\npadding:10px 8px;\r\n}\r\n#tab-list td {\r\nborder-bottom:1px solid #CCCCCC;\r\ncolor:#666699;\r\npadding:6px 8px;\r\n}\r\n</style>\r\n</head>\r\n<body style=\"border:none\">\r\n<center>\r\n<table id=\"tab-list\">\r\n<thead><tr><th>属性名称</th><th>属性值</th></tr></thead>\r\n<tbody>$tablecontent</tbody></table>\r\n</center>\r\n</body>\r\n</html>\r\n";
            double lineLength = line.GetSpaceLength(true, 6378137);
            Dictionary<string,string> property = new Dictionary<string, string>();
            property.Add("长度", (lineLength/1000).ToString("0.00") + "KM");

            lineFeature.Description = lineFeature.Description.Replace("$tablecontent", maketable(property));

            //把几何要素添加到内存图层中
            globeControl1.Globe.MemoryLayer.AddFeature(lineFeature);
        }

        private void AddPolygon()
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

            #region 属性设置

            f.Description = "<html>\r\n<head>\r\n<style>\r\n#tab-list {\r\nborder-collapse:collapse;\r\nfont-size:15px;\r\nmargin:20px;\r\ntext-align:left;\r\nwidth:280px;\r\n}\r\n\r\n#tab-list th {\r\nborder-bottom:2px solid #6678B1;\r\ncolor:#003399;\r\nfont-size:14px;\r\nfont-weight:normal;\r\npadding:10px 8px;\r\n}\r\n#tab-list td {\r\nborder-bottom:1px solid #CCCCCC;\r\ncolor:#666699;\r\npadding:6px 8px;\r\n}\r\n</style>\r\n</head>\r\n<body style=\"border:none\">\r\n<center>\r\n<table id=\"tab-list\">\r\n<thead><tr><th>属性名称</th><th>属性值</th></tr></thead>\r\n<tbody>$tablecontent</tbody></table>\r\n</center>\r\n</body>\r\n</html>\r\n";

            GSOGeoPolyline3D line = new GSOGeoPolyline3D();
            line.AddPart((f.Geometry as GSOGeoPolygon3D)[0]);
            double length = line.GetSpaceLength(true, 6378137) / 1000;

            Dictionary<string, string> property = new Dictionary<string, string>();
            property.Add("面积", ((f.Geometry as GSOGeoPolygon3D).Area / 1000000).ToString("f4") + "平方千米");
            property.Add("周长", length.ToString("f2") + "千米");

            f.Description = f.Description.Replace("$tablecontent", maketable(property));

            #endregion

            globeControl1.Globe.MemoryLayer.AddFeature(f);  //把几何要素添加到内存图层中 
        }

        private void AddModel()
        {
            GSOGeoModel model = new GSOGeoModel(); //创建模型   
            GSOPoint3d pt = new GSOPoint3d(); //创建点
            pt.X = 116.6;
            pt.Y = 39.9;
            pt.Z = 0;


            //模型可以是3ds、obj、gse、gsez格式的三维模型
            //模型所在路径，用户可根据实际情况进行设置
            string filepath = Application.StartupPath + "\\Model\\坦克.3ds";

            //设置模型
            model.FilePath = filepath;
            model.Position = pt;

            model.AltitudeMode = EnumAltitudeMode.ClampToGround; //把几何体放到地面上

            GSOFeature feaf = new GSOFeature(); //创建几何要素
            feaf.Geometry = model;
            feaf.Name = "模型 01";
            feaf.Description = "模型 01";  //设置feature description的值，这个值将在tooltip上显示

            //把几何要素添加到内存图层中 
            globeControl1.Globe.MemoryLayer.AddFeature(feaf);
        }

        #endregion

        #region 刷新树节点

        /// <summary>
        /// 刷新节点
        /// </summary>
        private void RefreshTreeNode()
        {
            treeView1.Nodes.Clear();
            GSOLayer layer = globeControl1.Globe.MemoryLayer;
            for (int i = 0; i < layer.GetAllFeatures().Length; i++)
            {
                GSOFeature feature = layer.GetAt(i);
                if (feature != null)
                {
                    TreeNode tempNode = new TreeNode();
                    tempNode.Text = feature.Name;
                    tempNode.Checked = feature.Visible;
                    tempNode.Tag = feature;
                    if (feature.Geometry != null)
                    {
                        treeView1.Nodes.Add(tempNode);
                    }
                }
            }
        }

        #endregion

        private string maketable(Dictionary<string,string> property)
        {
            string test = "<tr><td>{0}</td><td>{1}</td><tr>";

            string result = "";

            foreach (KeyValuePair<string, string> pair in property)
            {
                string temp = test.Replace("{0}", pair.Key);
                temp = temp.Replace("{1}", pair.Value);
                result += temp;
            }

            return result;
        }

        private void Balloon_Btn_Click(object sender, EventArgs e)
        {
            //开启Balloon气泡
            globeControl1.Globe.FeatureMouseOverEnable = !globeControl1.Globe.FeatureMouseOverEnable;
            //开启高亮
            globeControl1.Globe.FeatureMouseOverHighLight = !globeControl1.Globe.FeatureMouseOverHighLight;

            //设置状态
            label2.Text = string.Format("Ballon气泡：{0}", globeControl1.Globe.FeatureMouseOverEnable == true ? "开" : "关");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            islabel = !islabel;
            label3.Text = string.Format("标注：{0}", islabel ? "开" : "关");
            GSOLayer layer = globeControl1.Globe.MemoryLayer;
            for (int i = 0; i < layer.GetAllFeatures().Length; i++)
            {
                GSOFeature feature = layer.GetAt(i);
                GSOLabel label = new GSOLabel();
                label.Text = feature.Name;  //设置显示的文本信息
                label.Style = new GSOLabelStyle();
                label.Style.Opaque = 0.8;  //设置标注的透明度，取值区间是0-1

                //设置引线的类型，可以是实线、虚线等。
                label.Style.TracktionLineType = EnumTracktionLineType.Dot;

                //设置字体大小
                label.Style.TextStyle.FontHeight = 20;

                //设置字体类型
                label.Style.TextStyle.FontName = "黑体";

                //设置标注的位置，默认标注在要素的正上方，下面80，60的单位是像素
                //label.Style.TractionLineEndPos = new GSOPoint2d(80, 60);
                label.Style.TractionLineEndPos = new GSOPoint2d(0, 60);

                //设置是否为斜体
                label.Style.TextStyle.Italic = true;

                //设置标注的边框颜色
                label.Style.OutlineColor = Color.Red;

                //设置标注的边框粗细
                label.Style.OutlineWidth = 1;

                //设置标注的引线粗细
                label.Style.TracktionLineWidth = 1;

                //设置标注矩形区的颜色渐变
                label.Style.BackBeginColor = Color.Orange;
                label.Style.BackEndColor = Color.PaleGreen;

                //label.BKImage = @"D:\图片资源\国旗.jpg";

                ////该属性如果设置为空，标注只显示图片，如果不为空，那么在图片之上显示文字。
                //label.Text = "";

                feature.Label = islabel ? label : null;

                globeControl1.Globe.Refresh();
            }
        }
    }
}
