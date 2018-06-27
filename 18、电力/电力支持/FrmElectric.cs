using GeoScene.Data;
using GeoScene.Globe;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ElectricSupport
{
    public partial class FrmElectric : Form
    {
        private GSOGlobeControl _glbControl;
        private string _modelPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Model/No1.len");
        GSOFeature _feature;

        public FrmElectric()
        {
            InitializeComponent();
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(_glbControl);
        }

        private void btn_addPowerLine_Click(object sender, EventArgs e)
        {
            //创建杆塔节点位置
            GSOPoint3d point1 = new GSOPoint3d(120.121, 30.210, 0);
            GSOPoint3d point2 = new GSOPoint3d(120.121, 30.2105, 0);
            GSOPoint3ds points = new GSOPoint3ds();
            //加载顺序就是连接顺序
            points.Add(point1);
            points.Add(point2);

            //电力线
            GSOGeoPowerLine powerLine = new GSOGeoPowerLine();
            for (int i = 0; i < points.Count; i++)
            {
                //创建杆塔节点
                GSOGeoPowerLineNode node = new GSOGeoPowerLineNode();
                node.Position = points[i];
                //添加杆塔模型
                node.NodeTemplatePath = i % 2 == 0 ? _modelPath : _modelPath;
                //赋予旋转角(需要调整旋转角适应电力线位置)
                node.RotateZ = 0;
                //将杆塔节点添加到电力线
                powerLine.AddNode(node);
            }

            //电力线样式设置
            powerLine.LinkLineStyle = new GSOElecLineStyle3D()
            {
                LineColor = Color.White,
                //电力线半径
                Radius = 0.05,
                //分段数
                Slice = 5,
                //电力线曲率
                CurveFactor = 0.0002
            };

            //新建要素
            GSOFeature feature = new GSOFeature();
            feature.Geometry = powerLine;

            //添加要素到globe中
            _glbControl.Globe.MemoryLayer.AddFeature(feature);
            _glbControl.Globe.JumpToFeature(feature, 1500);
        }

        private void FrmElectric_Load(object sender, EventArgs e)
        {
            _glbControl.Globe.LatLonGrid.Visible = false;
        }
    }
}
