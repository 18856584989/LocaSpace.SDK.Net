using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;

namespace SceneCondition
{
    public partial class FrmSceneCondition : Form
    {
        private GSOGlobeControl _glbControl;

        public FrmSceneCondition()
        {
            InitializeComponent();
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_glbControl);
        }

        private void FrmSceneCondition_Load(object sender, EventArgs e)
        {
            _glbControl.Globe.LatLonGrid.Visible = false;
            CreateModel();
        }

        private void checkBox_Rain_CheckedChanged(object sender, EventArgs e)
        {
            //打开/关闭雨
            _glbControl.Globe.Rain.Visible = true;
            _glbControl.Globe.Rain.Visible = checkBox_Rain.Checked;
        }

        private void checkBox_Snow_CheckedChanged(object sender, EventArgs e)
        {
            //打开/关闭雪
            _glbControl.Globe.Snow.Visible = true;
            _glbControl.Globe.Snow.Visible = checkBox_Snow.Checked;
        }

        private void checkBox_cloud_CheckedChanged(object sender, EventArgs e)
        {
            //打开/关闭云
            _glbControl.Globe.Clouds.Visible = true;
            _glbControl.Globe.Clouds.Visible = checkBox_cloud.Checked;
        }

        //添加模型参照物
        private void CreateModel()
        {
            GSOGeoBoxEntity box = new GSOGeoBoxEntity();
            box.Length = 300;
            box.Height = 300;
            box.Width = 200;
            box.Position = new GSOPoint3d(120, 30,0);

            GSOFeature feature = new GSOFeature();
            feature.Geometry = box;

            _glbControl.Globe.MemoryLayer.AddFeature(feature);
            _glbControl.Globe.JumpToFeature(feature, 6860);
            _glbControl.Globe.Refresh();
        }
    }
}
