using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
using System.IO;

namespace LayerAttriTableEdit
{
    public partial class FrmAttriTableEdit : Form
    {
        private GSOGlobeControl _glbControl;
        private GSOLayer _layer;

        public FrmAttriTableEdit()
        {
            InitializeComponent();
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_glbControl);
        }

        private void btn_OpenLayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "支持格式(*.shp)|*.shp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (_layer != null)
                    _glbControl.Globe.Layers.Remove(_layer);
                //添加SHP文件图层
                _layer = _glbControl.Globe.Layers.Add(dialog.FileName);
                //设置图层属性是否可编辑
                _layer.Editable = true;
                FlyToLayer(_layer);
                btn_EditAttriTable.Enabled = true;
            }
        }

        private void btn_EditAttriTable_Click(object sender, EventArgs e)
        {
            if (null == _layer.Dataset)
            {
                MessageBox.Show("该数据不是属性数据，属性表为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmAttriTable attrTable = new FrmAttriTable(_glbControl, _layer);
            attrTable.ShowDialog();
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
