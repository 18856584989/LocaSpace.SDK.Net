using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;
using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LayerAttriTableEdit
{
    public partial class FrmAttriTable : Form
    {
        private bool _tableEditable = false;
        private GSOGlobeControl _glbControl;
        private GSOLayer _layer;
        private DataTable _dataTable;
        private string _cellValueBeginCellEdit = string.Empty;

        public FrmAttriTable(GSOGlobeControl glbControl, GSOLayer layer)
        {
            InitializeComponent();
            _glbControl = glbControl;
            _layer = layer;
            InitialTable();
        }

        /// <summary>
        /// 将图层中的要素属性读取到表中
        /// </summary>
        private void InitialTable()
        {
            var features = _layer.GetAllFeatures();
            if (features.Length < 1)
            {
                MessageBox.Show("不存在要素。");
                return;
            }
            var coutn = features[0].GetFieldCount();
            _dataTable = new DataTable();

            //生成字段
            for (int i = 0; i < coutn; i++)
            {
                var field = features[0].GetFieldDefn(i);
                var column = _dataTable.Columns.Add(field.Name);
            }

            //获取每个元素，将属性数据填充到表格中
            for (int i = 0; i < features.Length; i++)
            {
                //新建行
                DataRow item1 = _dataTable.NewRow();
                //遍历Feature
                var feature = features[i];
                //遍历Feature中的属性数据
                for (int j = 0; j < coutn; j++)
                {
                    //将属性数据按顺序填入行中
                    item1[j] = feature.GetValue(j);
                }
                //添加行
                _dataTable.Rows.Add(item1);
            }
            this.dataGridView1.DataSource = _dataTable;
        }

        private void btn_EditTable_Click(object sender, EventArgs e)
        {
            _tableEditable = !_tableEditable;
            if (_tableEditable)
            {
                this.btn_AddField.Enabled = true;
                this.btn_Delete.Enabled = true;
                this.MenuStrip_FeatureEdit.Enabled = true;
                this.dataGridView1.ReadOnly = false;
                this.btn_EditTable.Text = "完成编辑";
            }
            else
            {
                this.btn_AddField.Enabled = false;
                this.MenuStrip_FeatureEdit.Enabled = false;
                this.btn_Delete.Enabled = false;
                this.dataGridView1.ReadOnly = true;
                this.btn_EditTable.Text = "编辑表格";
            }
        }

        //添加字段窗口
        private void btn_AddField_Click(object sender, EventArgs e)
        {
            FrmAddFieldToLayer frm = new FrmAddFieldToLayer(_layer, this.dataGridView1);
            frm.ShowDialog();
        }

        /// <summary>
        /// 删除字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (null == this.dataGridView1.SelectedCells
                || 1 > this.dataGridView1.SelectedCells.Count)
            {
                MessageBox.Show("请选择要删除的列。");
                return;
            }
            //新建选择列列表
            List<DataGridViewColumn> colsToDel = new List<DataGridViewColumn>();
            for (int i = 0; i < this.dataGridView1.SelectedCells.Count; i++)
            {
                //获取到datagridView中选中的列信息
                var column = this.dataGridView1.Columns[this.dataGridView1.SelectedCells[i].ColumnIndex];
                if (!colsToDel.Contains(column))
                    //添加列信息
                    colsToDel.Add(column);
            }
            //提示是否删除
            if (MessageBox.Show(string.Format("是否删除{0}字段？\n此操作不可撤销。", string.Join(",", colsToDel.AsEnumerable().Select(c => c.Name))),
                "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //获得所有要素
                GSOFeatures features = _layer.GetAllFeatures();
                //遍历选中列的列表
                foreach (var item in colsToDel)
                {
                    //遍历所有要素
                    for (int i = 0; i < features.Length; i++)
                    {
                        GSOFeature feature = features[i];
                        //获取选中列在要素属性表中的索引
                        int index = feature.GetFieldIndex(item.Name);
                        //删除该字段
                        feature.DeleteField(index);
                    }
                    //同时删除控件中的列
                    this.dataGridView1.Columns.Remove(item);
                }
                //保存图层
                _layer.Save();
            }
        }

        //获取字段修改前的值
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                _cellValueBeginCellEdit = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //行索引
            int rowIndex = e.RowIndex;
            //列索引
            int columnIndex = e.ColumnIndex;
            //获得修改的要素
            GSOFeature featureEdit = (_layer.Dataset as GSOFeatureDataset).GetFeatureAt(rowIndex);
            //获得修改的字段名称
            string fieldName = dataGridView1.Columns[columnIndex].Name.Trim();
            //获得修改过的字段定义
            GSOFieldDefn field = featureEdit.GetFieldDefn(fieldName);
            //获得修改过的值
            string cellValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString().Trim();
            if (featureEdit == null || field == null)
            {
                MessageBox.Show("修改的对象不存在！", "提示");
                return;
            }
            //进行输入值类型的判断
            switch (field.Type)
            {
                case EnumFieldType.INT32:
                    int intValue = 0;
                    if (!Int32.TryParse(cellValue, out intValue))
                    {
                        MessageBox.Show("输入的数据格式不正确，请重新输入！", "提示");
                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = _cellValueBeginCellEdit;
                        return;
                    }
                    //值设置
                    featureEdit.SetFieldValue(fieldName, intValue);
                    break;
                case EnumFieldType.Double:
                    double doubleValue = 0;
                    if (!double.TryParse(cellValue, out doubleValue))
                    {
                        MessageBox.Show("输入的数据格式不正确，请重新输入！", "提示");
                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = _cellValueBeginCellEdit;
                        return;
                    }
                    //值设置
                    featureEdit.SetFieldValue(fieldName, doubleValue);
                    break;
                case EnumFieldType.Date:
                    DateTime dateTimeValue = DateTime.Now.Date;
                    if (!DateTime.TryParse(cellValue, out dateTimeValue))
                    {
                        MessageBox.Show("输入的数据格式不正确，请重新输入！", "提示");
                        dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = _cellValueBeginCellEdit;
                        return;
                    }
                    //值设置
                    featureEdit.SetFieldValue(fieldName, dateTimeValue);
                    break;
                case EnumFieldType.Text:
                    //值设置
                    featureEdit.SetFieldValue(fieldName, cellValue);
                    break;
                default:
                    throw new Exception("字段类型不符合条件。");
            }
            _layer.Save();
        }

        //行头点击飞到所在要素
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            var feature = _layer.GetAllFeatures()[index];
            flyToFeature(_glbControl, feature);
        }

        //要素定位方法
        public void flyToFeature(GSOGlobeControl globeControl, GSOFeature feature, bool selected = false)
        {
            if (null == globeControl
                || null == feature
                || null == feature.Geometry
                || null == feature.Geometry.Bounds)
                return;
            //获取图层中心点
            GSOPoint3d pntPostion = new GSOPoint3d();
            pntPostion.X = feature.Geometry.Bounds.Center.X;
            pntPostion.Y = feature.Geometry.Bounds.Center.Y;
            //获取图层最大边
            double dMaxGeoLen = Math.Max(feature.Geometry.Bounds.Width, feature.Geometry.Bounds.Height);
            //判断视角高度
            double dSize = dMaxGeoLen * Math.PI * 6378137 / 90;
            pntPostion.Z = dSize > 20000000 ? dSize / 4 : dSize;
            _glbControl.Globe.FlyToPosition(pntPostion, EnumAltitudeMode.RelativeToGround);
        }
    }
}
