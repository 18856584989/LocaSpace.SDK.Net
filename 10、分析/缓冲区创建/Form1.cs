using System;
using System.Drawing;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;

namespace 缓冲区创建
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        string mouseClickType = null;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            //鼠标按下事件
            globeControl1.MouseDown += (sender, e) =>
            {
                MouseDown = e.Location;
            };

            //鼠标抬起事件
            globeControl1.MouseUp += new MouseEventHandler(globeControl1_MouseUp);
        }

        /// <summary>
        /// 创建缓冲区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.SelectObject;
            mouseClickType = "缓冲区创建";
        }

        private void globeControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseDown != e.Location) return;

            if (e.Button == MouseButtons.Left)
            {
                if (globeControl1.Globe.Action == EnumAction3D.NormalHit)
                {
                    GSOPoint3d point3d = new GSOPoint3d();

                    GSOFeature newFeature = new GSOFeature();
                    GSOGeoMarker p = new GSOGeoMarker();
                    GSOMarkerStyle3D style = new GSOMarkerStyle3D();
                    style.IconPath = Application.StartupPath + "/Resource/image/DefaultIcon.png";
                    p.Style = style;
                    p.Z = point3d.Z <= 0 ? 0 : point3d.Z;
                    if (point3d.Z <= 0.0)
                    {
                        point3d = globeControl1.Globe.ScreenToScene(e.X, e.Y);
                    }
                    p.X = point3d.X;
                    p.Y = point3d.Y;
                    p.Z = point3d.Z;
                    newFeature.Geometry = p;
                    newFeature.Name = "我的地标";

                    globeControl1.Globe.MemoryLayer.AddFeature(newFeature);
                    globeControl1.Globe.Action = EnumAction3D.ActionNull;

                }
                //开始判断是否是缓冲区分析
                else if (globeControl1.Globe.Action == EnumAction3D.SelectObject)
                {
                    if (mouseClickType == "缓冲区创建")
                    {
                        //获取选中要素
                        GSOFeature feature = globeControl1.Globe.SelectedObject;
                        if (feature == null || feature.Geometry == null)
                        {
                            MessageBox.Show("请选择一个目标");
                            return;
                        }
                        if (feature.Geometry.Type != EnumGeometryType.GeoMarker
                                && feature.Geometry.Type != EnumGeometryType.GeoPolyline3D
                                && feature.Geometry.Type != EnumGeometryType.GeoPolygon3D)
                        {
                            MessageBox.Show("请选择一个点、线、面对象！", "提示");
                            return;
                        }
                        globeControl1.Globe.Action = EnumAction3D.ActionNull;
                        makeBuffer(feature);
                    }
                }
            }
        }

        private void makeBuffer(GSOFeature feature)
        {
            double radius = (double) numericUpDownRadius.Value; //缓冲区宽度
            double value = (double) numericUpDownFenDuan.Value; //圆角角度
            bool isRoundCorner = CBRoundCorner.Checked;         //拐角是否圆滑
            bool isRoundEnds = CBRoundEnds.Checked;             //两端是否圆滑

            GSOGeoPolygon3D buffer = null;  //创建缓冲面
            if (feature.Geometry.Type == EnumGeometryType.GeoMarker)//如果要素为点
            {
                GSOGeoMarker marker = feature.Geometry as GSOGeoMarker;
                buffer = marker.CreateBuffer(radius, value, false);
                //创建点的缓冲面（宽度，角度，false）
            }
            else if (feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
            {
                GSOGeoPolyline3D line = feature.Geometry as GSOGeoPolyline3D;
                buffer = line.CreateBuffer(radius, isRoundCorner, value, isRoundEnds, false);
                //创建线的缓冲面（宽度，拐角圆滑，角度，两端圆滑，false）
            }
            else if (feature.Geometry.Type == EnumGeometryType.GeoPolygon3D)
            {
                GSOGeoPolygon3D polygon = feature.Geometry as GSOGeoPolygon3D;
                buffer = polygon.CreateBuffer(radius, isRoundCorner, value, isRoundEnds, false);
                //创建面的缓冲面（宽度，拐角圆滑，角度，两端圆滑，false）
            }

            if (buffer != null)
            {
                //缓冲面颜色
                GSOSimplePolygonStyle3D style = new GSOSimplePolygonStyle3D();
                style.FillColor = Color.FromArgb(122, Color.Yellow);
                //缓冲线颜色
                GSOSimpleLineStyle3D outlineStyle = new GSOSimpleLineStyle3D();
                outlineStyle.LineColor = Color.Red;
                style.OutlineStyle = outlineStyle;
                buffer.Style = style;
                GSOFeature featureBuffer = new GSOFeature();
                featureBuffer.Geometry = buffer;
                featureBuffer.Name = feature.Name + "_" + radius + "米_Buffer";
                globeControl1.Globe.MemoryLayer.AddFeature(featureBuffer);

                //重新创建原有要素,使得要素在缓冲面上方，可选择
                if (feature != null && feature.Dataset.Type == EnumDatasetType.Memory && feature.Dataset.Caption == "" && feature.Dataset.Name == "")
                {
                    GSOFeature featureSelectCopy = feature.Clone();
                    globeControl1.Globe.MemoryLayer.AddFeature(featureSelectCopy);
                    feature.Delete();
                }
                globeControl1.Refresh();
            }
        }

        #region 附属代码

        #region 创建点线面

        Point MouseDown = new Point();

        private void button2_Click(object sender, System.EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.NormalHit;
            mouseClickType = "添加点";
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.DrawPolyline;
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.DrawPolygon;
        }

        #endregion

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //添加地形，方便分析
            GSOTerrain terrain = globeControl1.Globe.Terrains.Add(Application.StartupPath + "/Resource/dem/TestDem.tif");
            //添加影像，方便分析
            globeControl1.Globe.Layers.Add(Application.StartupPath + "/Resource/gisdata/tianditudata/天地图影像.lrc");

            //移动视角，方便分析
            flyToLayerOrTerrain(globeControl1, terrain.LatLonBounds);
        }

        #region 图层定位
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

        #endregion
    }
}
