using GeoScene.Data;
using GeoScene.Globe;
using System.Windows.Forms;

namespace LayerOperate
{
    public partial class FrmLayerHang : Form
    {
        private GSOGlobeControl _glbControl;
        private GSOLayer _layer;

        public FrmLayerHang(GSOGlobeControl glbControl, GSOLayer layer)
        {
            InitializeComponent();
            _glbControl = glbControl;
            _layer = layer;
        }

        private void btn_OK_Click(object sender, System.EventArgs e)
        {
            if(string.IsNullOrEmpty(this.textBox1.Text))
            {
                errorProvider1.SetError(this.textBox1, "请输入升降高度");
                return;
            }
            if (!double.TryParse(this.textBox1.Text, out double height))
            {
                errorProvider1.SetError(this.textBox1, "输入高度不合法，请重新输入数字。");
                return;
            }
            GSOFeatureLayer flayer = _layer as GSOFeatureLayer;
            //获得图层中的所有要素
            GSOFeatures features = flayer.GetAllFeatures();
            for (int i = 0; i < features.Length; i++)
            {
                //遍历所有要素
                GSOFeature feature = features[i];
                if (feature is GSOFeatureFolder)
                {
                    MoveEachFeature(feature as GSOFeatureFolder, height);
                }
                else
                {
                    GSOGeometry geometry = feature.Geometry;
                    if (geometry != null)
                    {
                        //为了显示升降效果，
                        //需要将ClampToGround模式修改为RelativeToGround模式
                        if (geometry.AltitudeMode == EnumAltitudeMode.ClampToGround)
                        {
                            geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                        }
                        //将z轴移动height米
                        geometry.MoveZ(height);
                    }
                }
            }
            _glbControl.Refresh();
        }

        /// <summary>
        /// 递归升高/降低给定高度值
        /// </summary>
        /// <param name="folder">要素集</param>
        /// <param name="height">高度/米</param>
        private void MoveEachFeature(GSOFeatureFolder folder, double height)
        {
            GSOFeatures features = folder.Features;

            for (int i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];
                if (feature is GSOFeatureFolder)
                {
                    MoveEachFeature(feature as GSOFeatureFolder, height);
                }
                else
                {
                    GSOGeometry geometry = feature.Geometry;
                    if (geometry != null)
                    {
                        //为了显示升降效果，需要将ClampToGround模式修改为RelativeToGround模式
                        if (geometry.AltitudeMode == EnumAltitudeMode.ClampToGround)
                        {
                            geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                        }
                        //将z轴移动height米
                        geometry.MoveZ(height);
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
