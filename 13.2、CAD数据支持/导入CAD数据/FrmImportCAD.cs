using GeoScene.Data;
using GeoScene.Globe;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImportCAD
{
    public partial class FrmImportCAD : Form
    {
        private GSOGlobeControl _glbControl;

        public FrmImportCAD()
        {
            InitializeComponent();
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_glbControl);
        }

        private void btn_ImportCAD_Click(object sender, EventArgs e)
        {
            //打开CAD文件
            OpenFileDialog dialog = new OpenFileDialog();
            //定义CAD文件类型
            string[] cadExtension = new string[] { ".dxf", ".dwg" };
            dialog.Filter = "支持格式(*.dxf,*.dwg)|*.dxf;*.dwg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //获取文件后缀名
                string fileExt = Path.GetExtension(dialog.FileName);
                //判断是CAD文件并且文件夹下没有同名投影文件
                if (cadExtension.Contains(fileExt)
                    && !File.Exists(dialog.FileName.Replace(fileExt, ".prj")))
                {
                    MessageBox.Show(Path.GetFileName(dialog.FileName) + "文件不包含投影信息，请选择匹配的投影文件或者重新生成一个投影文件", "未知投影");
                    //添加投影文件窗口
                    FrmAddPrj frm = new FrmAddPrj(dialog.FileName);
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
                //添加CAD文件图层
                GSOLayer layer = _glbControl.Globe.Layers.Add(dialog.FileName);
                layer.Editable = true;
                FlyToLayer(layer);  //添加完图层之后视角飞到图层上方
            }
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

    }
}
