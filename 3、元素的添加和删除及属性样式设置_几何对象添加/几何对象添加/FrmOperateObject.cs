using GeoScene.Data;
using GeoScene.Globe;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OperateObject
{
    public partial class FrmOperateObject : Form
    {
        private GSOGlobeControl _glbControl;
        string IconPath = System.IO.Path.Combine(Application.StartupPath, "image/DefaultIcon.png");
        string dynamicMarkerImg = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image/flag1.gif");
        string _modelPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image/tank.3ds");

        public FrmOperateObject()
        {
            InitializeComponent();
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_glbControl);
            _glbControl.MouseDoubleClick += GlobeOnMouseDoubleClick;
            _glbControl.TrackPolygonEndEvent += this.TrackEndEvent;
            _glbControl.TrackPolylineEndEvent += this.TrackEndEvent;
            _glbControl.TrackRectEndEvent += this.GlobeOnTrackRectEndEvent;//绘制分析矩形完成事件绑定
        }

        // 点
        private void btn_point_Click(object sender, System.EventArgs e)
        {
            GSOGeoMarker point = new GSOGeoMarker();    //创建点对象
            point.X = 120.417888231016;                 //设置点X的值
            point.Y = 31.3283140323302;                 //设置点Y的值
            point.Z = 0;                                //设置点Z的值，单位为米
            point.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            point.Text = "中科图新";                    //设置点对象显示的文字

            GSOMarkerStyle3D style = new GSOMarkerStyle3D();
            style.IconPath = IconPath;                  //设置图标
            point.Style = style;

            AddNewGeoToLayer(point, "点");
        }

        // 线
        private void btn_Polyline_Click(object sender, System.EventArgs e)
        {
            GSOGeoPolyline3D line = new GSOGeoPolyline3D(); //创建线对象
            GSOPoint3ds pnts = new GSOPoint3ds(); //创建节点对象
            pnts.Add(new GSOPoint3d(120.4, 31.3, 1000));    //把各节点添加到节点对象上
            pnts.Add(new GSOPoint3d(120.41, 31.31, 3000));
            pnts.Add(new GSOPoint3d(120.42, 31.32, 2000));
            pnts.Add(new GSOPoint3d(120.43, 31.30, 2500));
            pnts.Add(new GSOPoint3d(120.44, 31.34, 4000));
            line.AddPart(pnts); //把节点添加到线上

            GSOSimpleLineStyle3D style = new GSOSimpleLineStyle3D();
            line.Style = style;
            AddNewGeoToLayer(line, "线");
        }

        // 面
        private void btn_Polygon_Click(object sender, System.EventArgs e)
        {
            GSOGeoPolygon3D polygon = new GSOGeoPolygon3D(); //创建多边形对象

            //创建节点对象
            GSOPoint3ds polygonPnts = new GSOPoint3ds();
            polygonPnts.Add(new GSOPoint3d(120.47, 31.3, 0));
            polygonPnts.Add(new GSOPoint3d(120.48, 31.3, 0));
            polygonPnts.Add(new GSOPoint3d(120.48, 31.25, 0));
            polygonPnts.Add(new GSOPoint3d(120.47, 31.2, 0));
            polygon.AddPart(polygonPnts);    //把节点添加到多边形对象上
            GSOSimplePolygonStyle3D style = new GSOSimplePolygonStyle3D();
            style.FillColor = Color.FromArgb(255, Color.Gray);
            polygon.Style = style;
            AddNewGeoToLayer(polygon, "面");
        }

        // 矩形
        private void btn_Rect_Click(object sender, System.EventArgs e)
        {
            GSOGeoRectangle rect = new GSOGeoRectangle();
            rect.Position = GetCurrentViewPoint();
            rect.Height = 0.001;//单位：度
            rect.Width = 0.002; //单位：度
            GSOSimplePolygonStyle3D style = new GSOSimplePolygonStyle3D();
            style.FillColor = Color.FromArgb(100, Color.Gray);
            rect.Style = style;
            AddNewGeoToLayer(rect, "矩形");
        }

        // 圆
        private void btn_Circle_Click(object sender, System.EventArgs e)
        {
            GSOGeoCircle circle = new GSOGeoCircle();
            circle.Position = GetCurrentViewPoint();//圆的指定位置
            circle.Radius = 0.00001; //圆的半径，单位：度
            AddNewGeoToLayer(circle, "圆");
            _glbControl.Globe.MemoryLayer.SaveAs("aa.lgd");
        }

        // 椭圆
        private void btn_Ellipse_Click(object sender, System.EventArgs e)
        {
            GSOGeoEllipse eclipse = new GSOGeoEllipse();
            eclipse.Position = GetCurrentViewPoint();//指定模型创建位置
            eclipse.XRadius = 0.001;//X方向方向半径，单位：度
            eclipse.YRadius = 0.002;//Y方向方向半径，单位：度
            GSOSimplePolygonStyle3D style = new GSOSimplePolygonStyle3D();//样式
            //设置填充样式为透明度100，颜色为灰色
            style.FillColor = Color.FromArgb(100, Color.Gray);
            eclipse.Style = style;
            AddNewGeoToLayer(eclipse, "椭圆");
        }

        // 椭圆饼
        private void btn_EllipsePie_Click(object sender, EventArgs e)
        {
            GSOGeoEllipsePie ellipsePie = new GSOGeoEllipsePie();
            ellipsePie.XRadius = 0.001;//X方向方向半径，单位：度
            ellipsePie.YRadius = 0.002;//Y方向方向半径，单位：度
            ellipsePie.StartAngle = 50;//缺口起始角度
            ellipsePie.EndAngle = 90; //缺口结束角度
            ellipsePie.Position = GetCurrentViewPoint();
            AddNewGeoToLayer(ellipsePie, "椭圆饼");
        }

        // 球
        private void btn_Sphere_Click(object sender, System.EventArgs e)
        {
            GSOGeoSphereEntity sphere = new GSOGeoSphereEntity();
            sphere.Position = GetCurrentViewPoint();
            sphere.Radius = 10;//球体半径，单位：米
            sphere.Slices = 600;//切分份数，默认32，越大表示精度越高，但计算量相应变高
            AddNewGeoToLayer(sphere, "球");
        }

        // 椭球
        private void btn_Ellipsolid_Click(object sender, System.EventArgs e)
        {
            GSOGeoEllipsoidEntity solid = new GSOGeoEllipsoidEntity();
            solid.Position = GetCurrentViewPoint();
            solid.XRadius = 120;//X方向半径，单位：米
            solid.YRadius = 100;//Y方向半径，单位：米
            solid.ZRadius = 100;//Z方向半径，单位：米
            solid.Slices = 200; //分段数
            AddNewGeoToLayer(solid, "椭球");
        }

        // 缺口椭球
        private void btn_NotchEllipsolid_Click(object sender, System.EventArgs e)
        {
            GSOGeoRangeEllipsoidEntity rangeEllipsoid = new GSOGeoRangeEllipsoidEntity();
            rangeEllipsoid.XRadius = 120;//X方向半径，单位：米
            rangeEllipsoid.YRadius = 200;//Y方向半径，单位：米
            rangeEllipsoid.ZRadius = 200;//Z方向半径，单位：米
            rangeEllipsoid.StartLat = -60;//-90→+90度
            rangeEllipsoid.EndLat = -30;//-90→+90度，Z方向负方向为-90，Z方向正方向为90，决定椭球被切高度
            rangeEllipsoid.StartLon = 0;//0-360度, 纬度方向为0，逆时针旋转
            rangeEllipsoid.EndLon = 60;//0-360度
            rangeEllipsoid.Position = GetCurrentViewPoint();//位置
            rangeEllipsoid.Slices = 200; //分段数
            AddNewGeoToLayer(rangeEllipsoid, "缺口椭球");
        }

        //台柱
        private void btn_Frustum_Click(object sender, EventArgs e)
        {
            GSOGeoFrustumEntity frustumEntity = new GSOGeoFrustumEntity();
            frustumEntity.Position = GetCurrentViewPoint();
            frustumEntity.Length = 300; //高度，单位：米
            frustumEntity.BottomRadius = 100;  //底面半径
            frustumEntity.TopRadius = 100;  //顶面半径
            AddNewGeoToLayer(frustumEntity, "台柱");
        }

        //椭圆台柱
        private void btn_EllipseFrustum_Click(object sender, EventArgs e)
        {
            GSOGeoEllipFrustumEntity ellipFrustum = new GSOGeoEllipFrustumEntity();
            ellipFrustum.Position = GetCurrentViewPoint();
            ellipFrustum.TopXRadius = 200;//顶面椭圆X方向半径
            ellipFrustum.TopYRadius = 200;//顶面椭圆Y方向半径
            ellipFrustum.BottomXRadius = 200;//底面椭圆X方向半径
            ellipFrustum.BottomYRadius = 200;//底面椭圆Y方向半径
            ellipFrustum.Length = 300;//台柱高度
            ellipFrustum.Slices = 200;
            AddNewGeoToLayer(ellipFrustum, "椭圆台柱");
        }

        // 缺口台柱
        private void btn_NotchFrustum_Click(object sender, EventArgs e)
        {
            GSOGeoRangeEllipFrustumEntity rangeEllipFrustum = new GSOGeoRangeEllipFrustumEntity();
            rangeEllipFrustum.Position = GetCurrentViewPoint();
            rangeEllipFrustum.TopXRadius = 100;//顶面椭圆X方向半径
            rangeEllipFrustum.TopYRadius = 200;//顶面椭圆Y方向半径
            rangeEllipFrustum.BottomXRadius = 100;//底面椭圆X方向半径
            rangeEllipFrustum.BottomYRadius = 200;//底面椭圆Y方向半径
            rangeEllipFrustum.Length = 300;//台柱高度
            rangeEllipFrustum.StartAngle = 30;//台柱起始角度
            rangeEllipFrustum.EndAngle = 360; //台柱结束角度
            rangeEllipFrustum.Slices = 200; //分段数
            AddNewGeoToLayer(rangeEllipFrustum, "缺口台柱");
        }

        // 立方体
        private void btn_Box_Click(object sender, EventArgs e)
        {
            GSOGeoBoxEntity box = new GSOGeoBoxEntity();
            box.Length = 100;  //长度，X方向，单位：米
            box.Width = 200;   //宽度，Y方向，单位：米
            box.Height = 100;  //高度，Z方向，单位：米
            box.Position = GetCurrentViewPoint();
            AddNewGeoToLayer(box, "立方体");
        }

        #region 动态对象

        // 动态标注
        private void btn_DynamicMarker_Click(object sender, EventArgs e)
        {
            GSOGeoDynamicMarker marker = new GSOGeoDynamicMarker();
            //设置标注位置
            marker.Position = new GSOPoint3d(120.4178, 31.328, 0);
            //标注模式：依附模型表面
            marker.AltitudeMode = EnumAltitudeMode.ClampToModel;
            marker.TimerInterval = 50000;
            marker.PlaySpeed = 10; //运动速度
            marker.Play();  //播放
            //marker.Stop();//停止动画

            GSOMarkerStyle3D markerStyle = new GSOMarkerStyle3D();
            //设置显示图片位置(.gif动态图)
            markerStyle.IconPath 
                = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image/flag1.gif");
            markerStyle.IconScale = 4; //图片显示缩放倍数
            marker.Style = markerStyle; //将Style赋给marker

            AddNewGeoToLayer(marker, "动态标注");
        }

        // 沿线运动对象
        private void btn_MoveObj_Click(object sender, EventArgs e)
        {
            //创建路线(也可以通过获取)
            GSOGeoPolyline3D polyLine = new GSOGeoPolyline3D();
            GSOPoint3ds pnts = new GSOPoint3ds(); //创建节点对象
            //把各节点添加到节点对象上
            pnts.Add(new GSOPoint3d(120.4, 31.3, 0));   
            pnts.Add(new GSOPoint3d(120.41, 31.31, 0));
            pnts.Add(new GSOPoint3d(120.42, 31.32, 0));
            pnts.Add(new GSOPoint3d(120.43, 31.30, 0));
            pnts.Add(new GSOPoint3d(120.44, 31.34, 0));
            polyLine.AddPart(pnts);

            GSORoute route = new GSORoute(); //创建路径
            for (int i = 0; i < polyLine[0].Count; i++)
                route.Add(polyLine[0][i]);
            // 设置路径属性
            route.CircleRoute = true; //路径是否闭合
            route.Speed = 10;         //沿线运动速度
            route.SpeedAcceleration = 1; //加速度
            route.RotateSpeed = 10;  //拐弯速度

            //加载模型
            GSOGeoModel model = new GSOGeoModel();
            model.FilePath = _modelPath;  //3D模型路径

            //创建沿线运动模型要素
            GSOGeoDynamicRoute dynamicRoute = new GSOGeoDynamicRoute();
            dynamicRoute.ActorGeometry = model;  //添加模型到沿线运动模型上

            dynamicRoute.Route = route; //赋路线
            dynamicRoute.Play();        //播放运动
            dynamicRoute.TimerInterval = 20;  //播放时间间隔

            GSOFeature feature = new GSOFeature();
            feature.Geometry = dynamicRoute;
            GSOFeature polylineFeature = new GSOFeature();
            polylineFeature.Geometry = polyLine;
            _glbControl.Globe.MemoryLayer.AddFeature(feature);
            _glbControl.Globe.MemoryLayer.AddFeature(polylineFeature);
            _glbControl.Globe.FlyToFeature(polylineFeature);
        }

        //水面
        private void btn_Water_Click(object sender, EventArgs e)
        {
            GSOGeoWater water = new GSOGeoWater();
            GSOPoint3ds polygonPnts = new GSOPoint3ds(); // 创建水面的节点
            polygonPnts.Add(new GSOPoint3d(120.47, 31.3, 0));
            polygonPnts.Add(new GSOPoint3d(120.48, 31.3, 0));
            polygonPnts.Add(new GSOPoint3d(120.48, 31.25, 0));
            polygonPnts.Add(new GSOPoint3d(120.47, 31.2, 0));
            water.AddPart(polygonPnts);
            water.Play();          //播放水面动态效果
            water.WaveSpeedX = 0;  //X方向水流速度
            water.WaveSpeedY = 0.1;  //Y方向水流速度
            AddNewGeoToLayer(water, "水面");
        }

        #endregion

        private void flyToFeature(GSOFeature feature)
        {
            if (null == _glbControl
                || null == feature
                || null == feature.Geometry
                || null == feature.Geometry.Bounds)
                return;

            var bounds = feature.Geometry.Bounds;
            if (bounds.Center == null
             || bounds.Width == 0.0
             || bounds.Height == 0.0)
            {
                _glbControl.Globe.FlyToFeature(feature);
                return;
            }
            //获取图层中心点
            GSOPoint3d pntPostion = new GSOPoint3d();
            pntPostion.X = bounds.Center.X;
            pntPostion.Y = bounds.Center.Y;
            //获取图层最大边
            double dMaxGeoLen = Math.Max(bounds.Width, bounds.Height);
            //判断视角高度
            double dSize = dMaxGeoLen * Math.PI * 6378137 / 90;
            pntPostion.Z = dSize > 20000000 ? dSize / 4 : dSize;
            _glbControl.Globe.FlyToPosition(pntPostion, EnumAltitudeMode.RelativeToGround);
        }

        private void AddNewGeoToLayer(GSOGeometry geoEntity, string strName)
        {
            GSOFeature newFeature = new GSOFeature();
            newFeature.Geometry = geoEntity;
            newFeature.Name = strName;
            _glbControl.Globe.MemoryLayer.AddFeature(newFeature);
            flyToFeature(newFeature);
        }

        private GSOPoint3d GetCurrentViewPoint()
        {
            GSOPoint3d pt = new GSOPoint3d();
            pt.X = _glbControl.Globe.CameraState.Longitude;
            pt.Y = _glbControl.Globe.CameraState.Latitude;
            pt.Z = 0;
            return pt;
        }

        private void TrackEndEvent(object sender, EventArgs e)
        {
            if (_glbControl.Globe.Action != EnumAction3D.ActionNull)
                _glbControl.Globe.Action = EnumAction3D.ActionNull;
        }

        private void GlobeOnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                (_glbControl.Globe.Action == EnumAction3D.DrawPolygon
                || _glbControl.Globe.Action == EnumAction3D.DrawPolyline
                ))
            {
                _glbControl.Globe.Action = EnumAction3D.ActionNull;
            }
        }

        private void GlobeOnTrackRectEndEvent(object sender, TrackRectEndEventArgs e)
        {
            if (e.Polygon != null)
            {
                //将分析矩形复制
                GSOGeoPolygon3D polygon = e.Polygon.Clone() as GSOGeoPolygon3D;
                //清除分析
                _glbControl.Globe.ClearAnalysis();
                //新建要素
                GSOFeature newFeature = new GSOFeature();
                //图形元素赋值给要素
                newFeature.Geometry = polygon;
                newFeature.Name = "我的矩形";
                //添加要素到图层
                _glbControl.Globe.MemoryLayer.AddFeature(newFeature);
                _glbControl.Refresh();
                _glbControl.Globe.Action = EnumAction3D.ActionNull;
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this._glbControl.Globe.MemoryLayer.RemoveAllFeature();
        }
    }
}
