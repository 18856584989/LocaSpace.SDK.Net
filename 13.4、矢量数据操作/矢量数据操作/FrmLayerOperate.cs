using System;
using System.Windows.Forms;
using GeoScene.Globe;
using System.IO;
using GeoScene.Data;

namespace LayerOperate
{
    public partial class FrmLayerOperate : Form
    {
        string _testLayerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LayerTest\\LayerTest.shp");
        string _modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LayerTest\\tank.3ds");
        private GSOGlobeControl _glbControl;
        private GSOLayer _layer;
        
        public FrmLayerOperate()
        {
            InitializeComponent();
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_glbControl);
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            FrmLayerMove frm = new FrmLayerMove(_glbControl, _layer);
            frm.Show(this);
        }
   
        private void btn_Hang_Click(object sender, EventArgs e)
        {
            FrmLayerHang frm = new FrmLayerHang(_glbControl, _layer);
            frm.Show(this);
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

        private void FrmLayerOperate_Load(object sender, EventArgs e)
        {
            _layer = _glbControl.Globe.Layers.Add(_testLayerPath);
            //设置图层为可编辑
            _layer.Editable = true;
            FlyToLayer(_layer);
            _glbControl.Globe.Action = EnumAction3D.SelectObject;
        }

        private void btn_Model_Click(object sender, EventArgs e)
        {
            GSOGeoModel model = new GSOGeoModel(); //创建模型   
            GSOPoint3d pt = new GSOPoint3d(); //创建点
            pt.X = 120;
            pt.Y = 30;
            pt.Z = 0;

            GSOModelPointStyle3D style = new GSOModelPointStyle3D();  //创建模型的风格       
            model.Style = style;

            //设置模型
            model.FilePath = _modelPath;
            model.Position = pt;

            model.AltitudeMode = EnumAltitudeMode.ClampToGround; //把几何体放到地面上

            GSOFeature f = new GSOFeature(); //创建几何要素
            f.Geometry = model;
            f.Name = "模型 01";
            f.Description = "模型 01";  //设置feature description的值，这个值将在tooltip上显示

            //把几何要素添加到内存图层中 
            GSOFeature newFeature = _glbControl.Globe.MemoryLayer.AddFeature(f);
            _glbControl.Globe.FlyToFeature(f);  //飞行到模型所在的位置
            _glbControl.Refresh();    //刷新场景
        }

        //要素旋转
        private void btn_Rotate_Click(object sender, EventArgs e)
        {
            //方法一
            _glbControl.Globe.Action = EnumAction3D.RotateObject;

            //方法二
            if (_glbControl.Globe.SelectedObject == null)
            {
                MessageBox.Show("请选择要素。");
                return;
            }
            var feature = _glbControl.Globe.SelectedObject;
            feature.Geometry.Rotate(180, 0, 0);//绕X轴旋转180度
        }

        //要素平移
        private void btn_FeatureMove_Click(object sender, EventArgs e)
        {
            //方法一
            _glbControl.Globe.Action = EnumAction3D.MoveObject;

            //方法二
            if (_glbControl.Globe.SelectedObject == null)
            {
                MessageBox.Show("请选择要素。");
                return;
            }
            var feature = _glbControl.Globe.SelectedObject;
            feature.Geometry.MoveXY(2, 2);//向东、向北移动2度
        }

        //要素升降
        private void btn_FeatureElevate_Click(object sender, EventArgs e)
        {
            //方法一
            _glbControl.Globe.Action = EnumAction3D.ElevateObject;

            //方法二
            if (_glbControl.Globe.SelectedObject == null)
            {
                MessageBox.Show("请选择要素。");
                return;
            }
            var feature = _glbControl.Globe.SelectedObject;

            //显示模式为依附地面，看不出升降效果，所以需要修改模式为相对地面
            if (feature.Geometry.AltitudeMode == EnumAltitudeMode.ClampToGround)
                feature.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            feature.Geometry.MoveZ(180);//抬高180米
        }

        //要素缩放
        private void btn_Scale_Click(object sender, EventArgs e)
        {
            //方法一
            _glbControl.Globe.Action = EnumAction3D.ScaleObject;

            //方法二
            if (_glbControl.Globe.SelectedObject == null)
            {
                MessageBox.Show("请选择要素。");
                return;
            }
            var feature = _glbControl.Globe.SelectedObject;
            feature.Geometry.Scale(2, 1, 1);//X轴方向放大一倍
        }
    }
}
