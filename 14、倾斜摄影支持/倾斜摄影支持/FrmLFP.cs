using GeoScene.Data;
using GeoScene.Globe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LFPSupport
{
    public partial class FrmLFP : Form
    {
        //是否为压平分析/填挖方分析
        private bool _isPressOn = false;
        private GSOGlobeControl _glbControl;
        //模型压平分析多边形
        private List<GSOGeoPolygon3D> _trackPressPolygon = new List<GSOGeoPolygon3D>();
        //模型路径
        string _modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestModel\\tank.3ds");

        //倾斜摄影图层
        GSOLayer lfpLayer;

        public FrmLFP()
        {
            InitializeComponent();
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            //绑定分析多边形绘制结束事件
            _glbControl.TrackPolygonEndEvent += _glbControl_TrackPolygonEndEvent;
            //绑定网络图层添加事件
            _glbControl.AfterNetLayerAddEvent += _glbControl_AfterNetLayerAddEvent;
            panel1.Controls.Add(_glbControl);
        }

        private void btn_Transform_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            var node = xmlDoc.CreateXmlDeclaration("1.0", "GB18030", null);
            xmlDoc.AppendChild(node);

            //根节点
            var rootElement = xmlDoc.CreateElement("DataDefine");
            var RootNode = xmlDoc.AppendChild(rootElement);

            //版本
            var VersionNode = AppendChildNode(xmlDoc, "Version", RootNode);
            VersionNode.InnerText = "0";

            //要素名称
            var NameNode = AppendChildNode(xmlDoc, "Name", RootNode);
            NameNode.InnerText = "lfpLayer";

            //中心位置
            //可以通过倾斜摄影文件的metadata.xml获取中心点位置
            var PositionNode = AppendChildNode(xmlDoc, "Position", RootNode);
            PositionNode.InnerText = "0,0,0";

            //高度模式
            var AltitudeModeNode = AppendChildNode(xmlDoc, "AltitudeMode", RootNode);
            AltitudeModeNode.InnerText = "2";

            //偏移量
            var OffsetMetersNode = AppendChildNode(xmlDoc, "OffsetMeters", RootNode);
            OffsetMetersNode.InnerText = "0,0,0";

            //旋转量
            var RotationNode = AppendChildNode(xmlDoc, "Rotation", RootNode);
            RotationNode.InnerText = "0,0,0";

            //缩放量
            var ScaleNode = AppendChildNode(xmlDoc, "Scale", RootNode);
            ScaleNode.InnerText = "1,1,1";

            //本地路径(相对lfp文件)
            var LocalPathNode = AppendChildNode(xmlDoc, "LocalPath", RootNode);
            LocalPathNode.InnerText = "./";

            //网络路径
            var NetPathNode = AppendChildNode(xmlDoc, "NetPath", RootNode);

            //网络路径_类型
            var NetPathTypeNode = AppendChildNode(xmlDoc, "Type", NetPathNode);

            //网络路径_URL
            var NetPathUrlNode = AppendChildNode(xmlDoc, "Url", NetPathNode);

            //坐标范围
            var RangeNode = AppendChildNode(xmlDoc, "Range", RootNode);
            //坐标范围_最西
            var RangeWestNode = AppendChildNode(xmlDoc, "West", RangeNode);
            RangeWestNode.InnerText = "120.408521094169";
            //坐标范围_最东
            var RangeEastNode = AppendChildNode(xmlDoc, "East", RangeNode);
            RangeWestNode.InnerText = "120.409584470569";
            //坐标范围_最南
            var RangeSouthNode = AppendChildNode(xmlDoc, "South", RangeNode);
            RangeWestNode.InnerText = "31.3179772054299";
            //坐标范围_最北
            var RangeNorthNode = AppendChildNode(xmlDoc, "North", RangeNode);
            RangeWestNode.InnerText = "31.3191483505188";
            //坐标范围_最低
            var RangeMinZNode = AppendChildNode(xmlDoc, "MinZ", RangeNode);
            RangeWestNode.InnerText = "16.0027980804443";
            //坐标范围_最高
            var RangeMaxZNode = AppendChildNode(xmlDoc, "MaxZ", RangeNode);
            RangeWestNode.InnerText = "25.8922748565674";

            //文件节点列表
            var NodeListNode = AppendChildNode(xmlDoc, "NodeList", RootNode);

            //文件节点
            var Node = AppendChildNode(xmlDoc, "Node", NodeListNode);
            Node.InnerText = "./Tile_+000_+000/Tile_+000_+000.osgb";

            //压平模型路径
            var FlattenPolygon3DsNode = AppendChildNode(xmlDoc, "FlattenPolygon3Ds", RootNode);
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "demo.lfp";
            xmlDoc.Save(filePath);
            MessageBox.Show(string.Format("示例lfp文档已保存到{0}。", filePath));
        }

        //添加子节点
        private XmlNode AppendChildNode(XmlDocument xmlDoc, string childName, XmlNode parentNode)
        {
            //创建要素
            var element = xmlDoc.CreateElement(childName);
            //添加子节点
            return parentNode.AppendChild(element);
        }

        /// <summary>
        /// 模型压平
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ModelPreDown_Click(object sender, EventArgs e)
        {
            if (this.lfpLayer == null)
            {
                MessageBox.Show("请先连接服务器获取倾斜摄影图层。");
                return;
            }
            else
            {
                FlyToLayer(lfpLayer);
            }
            //改变分析场景为绘制分析多边形
            this._glbControl.Globe.Action = EnumAction3D.TrackPolygon;
            _isPressOn = true;
            //分析多边形的绘制方式为空间绘制
            _glbControl.Globe.TrackPolygonTool.TrackMode = EnumTrackMode.SpaceTrack;
        }

        /// <summary>
        /// 模型替换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReplaceModel_Click(object sender, EventArgs e)
        {
            if (_trackPressPolygon.Count < 1)
            {
                MessageBox.Show("请先绘制压平模型。");
                return;
            }
            foreach (var trackPolygon in _trackPressPolygon)
            {
                //创建模型
                GSOGeoModel model = new GSOGeoModel();
                //给定模型路径
                model.FilePath = _modelPath;
                //模型加载
                model.Load();
                //模型位置
                model.Position = trackPolygon.GeoCenterPoint;
                //将模型放置于模型表面
                model.AltitudeMode = EnumAltitudeMode.ClampToModel; //把几何体放到表面上
                GSOFeature f = new GSOFeature(); //创建几何要素
                f.Geometry = model;
                f.Name = "模型 01";

                //把几何要素添加到内存图层中 
                GSOFeature newFeature = _glbControl.Globe.MemoryLayer.AddFeature(f);
                _glbControl.Refresh();    //刷新场景
            }
        }

        /// <summary>
        /// 填挖方计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            if (this.lfpLayer == null)
            {
                MessageBox.Show("请先连接服务器获取倾斜摄影图层。");
                return;
            }
            else
            {
                FlyToLayer(lfpLayer);
            }
            //改变分析场景为绘制分析多边形
            this._glbControl.Globe.Action = EnumAction3D.TrackPolygon;
            //分析多边形的绘制方式为空间绘制
            _glbControl.Globe.TrackPolygonTool.TrackMode = EnumTrackMode.SpaceTrack;
        }

        /// <summary>
        /// 连接服务器，获取倾斜摄影数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConnetServer_Click(object sender, EventArgs e)
        {
            //ip地址
            string ip = "data1.locaspace.cn";
            //端口
            int port = 1500;
            //用户名
            string userName = "admin";
            //密码
            string psw = "admin";
            //避免多次加载，影响分析结果
            if (this._glbControl.Globe.Layers.Count > 0)
            {
                InitiLayer();
                return;
            }
            //连接服务器
            this._glbControl.Globe.ConnectServer(ip, port, userName, psw);
            _glbControl.Refresh();
        }

        private void _glbControl_AfterNetLayerAddEvent(object sender, AfterNetLayerAddEventArgs e)
        {
            InitiLayer();
        }

        /// <summary>
        /// 初始化倾斜摄影图层
        /// </summary>
        private void InitiLayer()
        {
            if (lfpLayer != null)
            {
                FlyToLayer(lfpLayer);
                return;
            }
            for (int i = 0; i < this._glbControl.Globe.Layers.Count; i++)
            {
                //获取文件扩展名为.lfp的第一个倾斜摄影图层
                if (this._glbControl.Globe.Layers[i].Name.Contains(".lfp"))
                {
                    lfpLayer = this._glbControl.Globe.Layers[i];
                    break;
                }
            }
            FlyToLayer(lfpLayer);
            return;
        }

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

        private void _glbControl_TrackPolygonEndEvent(object sender, TrackPolygonEndEventArgs e)
        {
            //判断绘制的多边形是否在倾斜摄影图层上
            GSOPoint3ds polygonPots = e.Polygon[0];
            if (!lfpLayer.LatLonBounds.Left.Equals(0.0) &&
                            !lfpLayer.LatLonBounds.Bottom.Equals(0.0) &&
                            !lfpLayer.LatLonBounds.Top.Equals(0.0) &&
                            !lfpLayer.LatLonBounds.Right.Equals(0.0))
            {
                for (int i = 0; i < polygonPots.Count; i++)
                {
                    if (!lfpLayer.LatLonBounds.Contains(polygonPots[i].X, polygonPots[i].Y))
                    {
                        MessageBox.Show("请将多边形画于倾斜摄影图层上。");
                        //清除上一个绘制的分析多边形
                        _glbControl.Globe.ClearLastTrackPolygon();
                        return;
                    }
                }
            }
            //压平分析
            if (_isPressOn)
            {
                //将倾斜摄影图层转换为GSOPageLODFeatureLayer分析图层
                GSOPageLODFeatureLayer layer2 = lfpLayer as GSOPageLODFeatureLayer;
                //压平面
                GSOGeoPolygon3D poly1 = e.Polygon;
                //加入到压平面的List为模型替换做准备
                _trackPressPolygon.Add(e.Polygon);
                //高度模式为绝对高度
                poly1.AltitudeMode = EnumAltitudeMode.Absolute;

                if (layer2 != null)
                {
                    //添加压平面
                    layer2.AddFlattenPolygon3D(poly1, "");
                    //保存压平面
                    layer2.Save();
                }
                _isPressOn = false;
            }
            //填挖方分析
            else
            {
                //挖方量
                double m_dDigVolume = 0;
                //填方量
                double m_dFillVolume = 0;
                //分析总面积
                double m_dTotalArea = 0;
                //挖方面积(废除)
                double m_dDigArea = 0;
                //填方面积(废除)
                double m_dFillArea = 0;

                double dAlt = 50; //挖填方高度
                double pointDistance = 1;//采样精度,单位：米
                //将平面坐标转换为经纬度坐标，使用默认投影ID为0
                GSOPoint2d point2D = GSOProjectManager.Inverse(new GSOPoint2d(pointDistance, pointDistance), 0);
                double dDSampleGap = point2D.X;//重采样的点的距离,单位是：经纬度
                //挖方分析线
                GSOGeoPolyline3D lineDig = new GSOGeoPolyline3D();
                //填方分析线
                GSOGeoPolyline3D lineFill = new GSOGeoPolyline3D();
                //填挖方分析
                bool analysisResult = _glbControl.Globe.Analysis3D.DigFillAnalyseWithModel(e.Polygon, dAlt, out m_dDigVolume, out m_dFillVolume,
                           out m_dDigArea, out m_dFillArea, out m_dTotalArea, dDSampleGap, lineDig, lineFill);
                //分析成功
                if (analysisResult)
                {
                    StringBuilder str = new StringBuilder();
                    str.AppendLine("分析高度：" + dAlt.ToString());
                    str.AppendLine("分析精度：" + pointDistance.ToString() + "米");
                    str.AppendLine("挖方量：" + m_dDigVolume.ToString() + "立方米");
                    str.AppendLine("填方量：" + m_dFillVolume.ToString() + "立方米");
                    str.AppendLine("总面积：" + m_dTotalArea.ToString() + "平方米");
                    MessageBox.Show(str.ToString());
                }
                else
                    MessageBox.Show("分析失败。");
            }
            _glbControl.Refresh();
            _glbControl.Globe.Action = EnumAction3D.ActionNull;
        }
    }
}
