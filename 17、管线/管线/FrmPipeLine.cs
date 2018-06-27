using GeoScene.Data;
using GeoScene.Globe;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PipeLineSupport
{
    public partial class FrmPipeLine : Form
    {
        private GSOGlobeControl _glbControl;
        string _testShpPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestLayer\\PipeLine.shp");
        GSOFeature _pipeFeature1;
        GSOFeature _pipeFeature2;
        GSOLayer _shpLayer;
        double _radius = 1;
        bool _pipeLineCreated = false;
        bool _pipeArrowVisible = false;
        bool _layerAdded = false;

        public FrmPipeLine()
        {
            InitializeComponent();

            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_glbControl);
        }

        //创建管线要素
        public void CreatePipeLine()
        {
            //创建线要素
            GSOGeoPolyline3D line1 = new GSOGeoPolyline3D();
            GSOPoint3ds points1 = new GSOPoint3ds();
            GSOPoint3d point1 = new GSOPoint3d(120.27191, 31.9864637, 5);
            GSOPoint3d point2 = new GSOPoint3d(120.271, 31.9864637, 5);
            points1.Add(point1);
            points1.Add(point2);
            line1.AddPart(points1);
            //设置线高度模式为相对地表
            line1.AltitudeMode = EnumAltitudeMode.RelativeToGround;

            //设置样式
            GSOPipeLineStyle3D style = new GSOPipeLineStyle3D();
            //管线颜色
            style.LineColor = Color.Brown;
            //管线半径, 单位：米
            style.Radius = 1;
            line1.Style = style;
            //相对地表抬高半径的距离
            line1.MoveZ(style.Radius);
            //创建要素
            _pipeFeature1 = new GSOFeature();
            _pipeFeature1.Geometry = line1;
            //将要素添加到globe中并显示
            _glbControl.Globe.MemoryLayer.AddFeature(_pipeFeature1);

            _pipeFeature2 = new GSOFeature();
            GSOGeoPolyline3D line2 = new GSOGeoPolyline3D();
            line2.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            GSOPoint3ds points2 = new GSOPoint3ds();
            GSOPoint3d point3 = new GSOPoint3d(120.27191, 31.986, 0);
            GSOPoint3d point4 = new GSOPoint3d(120.271, 31.986, 0);
            points2.Add(point3);
            points2.Add(point4);
            line2.AddPart(points2);
            line2.Style = style;
            line2.MoveZ(style.Radius);
            _pipeFeature2.Geometry = line2;

            _glbControl.Globe.MemoryLayer.AddFeature(_pipeFeature1);
            _glbControl.Globe.MemoryLayer.AddFeature(_pipeFeature2);
            _glbControl.Globe.FlyToFeature(_pipeFeature1);

            //添加辅助线
            GSOSimpleLineStyle3D lineStyle = new GSOSimpleLineStyle3D()
            {
                LineColor = Color.Yellow,
                LineType = EnumLineType.Dot
            };

            //水平线
            GSOPoint3d pointtemp = new GSOPoint3d(point4.X, point4.Y, point2.Z + _radius);
            GSOGeoPolyline3D lineHor = new GSOGeoPolyline3D();
            GSOPoint3ds pointsHor = new GSOPoint3ds();
            pointsHor.Add(pointtemp);
            pointsHor.Add(new GSOPoint3d(point2.X, point2.Y, point2.Z + _radius));
            lineHor.AddPart(pointsHor);
            lineHor.Style = lineStyle;
            lineHor.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            double horLength = Math.Round(lineHor.GetSpaceLength(true, 6378137), 3);
            GSOFeature featureHorLine = new GSOFeature()
            {
                Geometry = lineHor
            };
            featureHorLine.Label = CreateLabel(horLength.ToString());
            this._glbControl.Globe.MemoryLayer.AddFeature(featureHorLine);

            //垂直线
            GSOGeoPolyline3D lineVer = new GSOGeoPolyline3D();
            GSOPoint3ds pointsVer = new GSOPoint3ds();
            pointsVer.Add(pointtemp);
            pointsVer.Add(new GSOPoint3d(point4.X, point4.Y, point4.Z + _radius));
            lineVer.AddPart(pointsVer);
            lineVer.Style = lineStyle;
            lineVer.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            double verLength = Math.Round(Math.Abs(point2.Z - point4.Z));

            GSOFeature featureVerLine = new GSOFeature()
            {
                Geometry = lineVer
            };
            featureVerLine.Label = CreateLabel(verLength.ToString());
            this._glbControl.Globe.MemoryLayer.AddFeature(featureVerLine);
        }

        //飞行至目标图层
        private void FlyToLayer(GSOLayer layer)
        {
            if (layer == null
                || layer.LatLonBounds == null
                || layer.LatLonBounds.Width == 0.0
                || layer.LatLonBounds.Height == 0.0)
                return;
            //获取图层中心点
            GSOPoint3d pntPostion = new GSOPoint3d();
            pntPostion.X = layer.LatLonBounds.Center.X;
            pntPostion.Y = layer.LatLonBounds.Center.Y;
            //获取图层最大边
            double dMaxGeoLen = Math.Max(layer.LatLonBounds.Width, layer.LatLonBounds.Height);
            //判断视角高度
            double dSize = dMaxGeoLen * Math.PI * 6378137 / 90;
            pntPostion.Z = dSize > 20000000 ? dSize / 4 : dSize;
            _glbControl.Globe.FlyToPosition(pntPostion, EnumAltitudeMode.RelativeToGround);
        }

        private void btn_CreatePipeLine_Click(object sender, EventArgs e)
        {
            if (!_pipeLineCreated)
            {
                CreatePipeLine();
                _pipeLineCreated = true;
            }
        }

        //加载shp文件并显示管线
        private void btn_LoadLayer_Click(object sender, EventArgs e)
        {
            if (_layerAdded)
                return;
            _shpLayer = _glbControl.Globe.Layers.Add(_testShpPath);
            _shpLayer.Editable = true;
            //设置样式
            GSOPipeLineStyle3D style = new GSOPipeLineStyle3D();
            style.LineColor = Color.Green;
            //管线半径
            style.Radius = _radius;
            //获得默认图层的要素
            var features = _shpLayer.GetAllFeatures();
            //遍历要素
            for (int i = 0; i < features.Length; i++)
            {
                GSOGeoPolyline3D geometry = features[i].Geometry as GSOGeoPolyline3D;
                geometry.Style = style;
                //将高度抬高到管径高度
                geometry.MoveZ(style.Radius);
                //重要，要将高度模式设置成相对地表，如果为依附地面则无渲染效果
                geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            }
            _glbControl.Refresh();
            FlyToLayer(_shpLayer);
        }

        /// <summary>
        /// 水平净距分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_HorizonDist_Click(object sender, EventArgs e)
        {
            btn_CreatePipeLine.PerformClick();
            //创建传入参数
            GSOPoint3d pntIntersect11 = new GSOPoint3d();
            GSOPoint3d pntIntersect12 = new GSOPoint3d();
            GSOPoint3d pntProIntersect11 = new GSOPoint3d();
            GSOPoint3d pntProIntersect12 = new GSOPoint3d();

            //水平净距分析，传入两条线，返回四个点
            double vVert1 = _glbControl.Globe.Analysis3D.ComputeVerticalDistance(_pipeFeature1.Geometry as GSOGeoPolyline3D, _pipeFeature2.Geometry as GSOGeoPolyline3D, out pntIntersect11,
                out pntIntersect12, out pntProIntersect11, out pntProIntersect12, false);

            //计算两点间的空间距离
            GSOGeoPolyline3D polyline1 = new GSOGeoPolyline3D();
            GSOPoint3ds points1 = new GSOPoint3ds();
            points1.Add(pntIntersect11);
            points1.Add(pntIntersect12);
            polyline1.AddPart(points1);

            //将两点间的空间距离扣除管径即为水平净距， 6378137为地球半径
            vVert1 = polyline1.GetSpaceLength(true, 6378137) - _radius - _radius;
            MessageBox.Show(string.Format("计算出的水平净距为{0}", Math.Round(vVert1, 3)));
        }

        /// <summary>
        /// 垂直净距分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_VerDist_Click(object sender, EventArgs e)
        {
            btn_CreatePipeLine.PerformClick();
            GSOPoint3d pntIntersect1 = new GSOPoint3d();
            GSOPoint3d pntIntersect2 = new GSOPoint3d();
            GSOPoint3d pntProIntersect1 = new GSOPoint3d();
            GSOPoint3d pntProIntersect2 = new GSOPoint3d();
            //计算两根管线最短垂直间距点
            double hVert = _glbControl.Globe.Analysis3D.ComputeVerticalDistance(_pipeFeature1.Geometry as GSOGeoPolyline3D, _pipeFeature2.Geometry as GSOGeoPolyline3D, out pntIntersect1,
                out pntIntersect2, out pntProIntersect1, out pntProIntersect2, false);
            //通过返回的两个最短垂直间距点的Z值差，扣除管径，得到两根管线的垂直净距
            hVert = Math.Abs(pntIntersect1.Z - pntIntersect2.Z) - _radius - _radius;
            MessageBox.Show(string.Format("计算出的垂直净距为{0}", Math.Round(hVert, 3)));
        }

        private void btn_FlowDerc_Click(object sender, EventArgs e)
        {
            if (_shpLayer == null)
                btn_LoadLayer.PerformClick();

            _pipeArrowVisible = !_pipeArrowVisible;
            //获取图层要素
            var features = _shpLayer.GetAllFeatures();

            for (int i = 0; i < features.Length; i++)
            {
                //获取要素的样式
                GSOLineStyle3D lineStyle = features[i].Geometry.Style as GSOLineStyle3D;
                //如果线样式中的ArrowStyle箭头样式为空，则新建箭头样式(水流箭头)
                if (lineStyle.ArrowStyle == null)
                {
                    lineStyle.ArrowStyle = new GSOArrowStyle();
                    lineStyle.ArrowStyle.BodyWidth = 2;//箭头体宽度
                    lineStyle.ArrowStyle.BodyLen = 6;//箭头体长度
                    lineStyle.ArrowStyle.HeadWidth = 8;//箭头头宽度
                    lineStyle.ArrowStyle.HeadLen = 10;//箭头头长度
                    lineStyle.ArrowStyle.OutlineVisible = true;//是否显示箭头外轮廓
                    lineStyle.ArrowStyle.OutlineColor = Color.Red;//设置外轮廓颜色
                    lineStyle.ArrowStyle.Speed = lineStyle.ArrowStyle.Speed / 2; //箭头运动速度
                    lineStyle.ArrowStyle.Play();//播放箭头运动
                }
                lineStyle.ArrowVisible = _pipeArrowVisible;//判断水流箭头显示/隐藏
            }

            btn_FlowDerc.Text = _pipeArrowVisible ? "隐藏流向分析" : "显示流向分析";
            //刷新球
            this._glbControl.Globe.Refresh();
        }

        GSOLabel CreateLabel(string labelText)
        {
            GSOLabel label = new GSOLabel();
            GSOLabelStyle lableStyle = new GSOLabelStyle();
            lableStyle.Opaque = 0.5;
            lableStyle.TextStyle.FontName = "宋体";
            lableStyle.TextStyle.FontSize = 12;
            lableStyle.TracktionLineType = EnumTracktionLineType.Dot;
            label.Text = labelText;
            label.Style = lableStyle;
            label.Visible = true;
            return label;
        }
    }
}
