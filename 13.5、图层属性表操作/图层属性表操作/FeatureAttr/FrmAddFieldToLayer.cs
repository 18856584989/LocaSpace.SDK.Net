using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;
using System;
using System.Windows.Forms;

namespace LayerAttriTableEdit
{
    public partial class FrmAddFieldToLayer : Form
    {
        GSOLayer layer = null;
        DataGridView dataGridView1 = null;

        public FrmAddFieldToLayer(GSOLayer _layer, DataGridView _dataGridView1)
        {
            InitializeComponent();
            layer = _layer;
            dataGridView1 = _dataGridView1;
            comboBoxFieldType.SelectedItem = "Text";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string fieldName = textBoxFieldName.Text.Trim();
            if (fieldName.Equals(string.Empty))
            {
                MessageBox.Show("字段名不能为空！", "提示");
                return;
            }
            int firstChar = 0;
            if (int.TryParse(fieldName.Substring(0, 1), out firstChar))
            {
                MessageBox.Show("字段名不能以数字开头！", "提示");
                return;
            }
            if (fieldName.Length > 10)
            {
                MessageBox.Show("字段名长度不能大于10！", "提示");
                return;
            }

            EnumFieldType fieldType = EnumFieldType.None;
            int fieldWidth = 0;
            string type = comboBoxFieldType.Text.Trim();
            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("字段类型不能为空！", "提示");
                return;
            }
            else
            {
                switch (type)
                {
                    case "Date":
                        fieldType = EnumFieldType.Date;
                        fieldWidth = 10;
                        break;
                    case "Double":
                        fieldType = EnumFieldType.Double;
                        fieldWidth = 8;
                        break;
                    case "INT32":
                        fieldType = EnumFieldType.INT32;
                        fieldWidth = 4;
                        break;
                    case "Text":
                        fieldType = EnumFieldType.Text;
                        fieldWidth = 8000;
                        break;
                    default:
                        MessageBox.Show("字段类型不匹配！", "提示");
                        return;
                }
            }

            if (layer != null)
            {
                GSOFieldDefn fieldDef = new GSOFieldDefn()
                {
                    //设置字段名称
                    Name = fieldName,
                    //设置字段类型
                    Type = fieldType,
                    //设置字段长度
                    Width = fieldWidth
                };

                var features = layer.GetAllFeatures();
                //遍历图层将字段信息添加到每个feature中
                for (int i = 0; i < features.Length; i++)
                {
                    var feature = features[i];
                    feature.AddField(fieldDef);
                }
                
                //保存图层
                layer.Save();

                //将新建列添加到数据表中
                dataGridView1.Columns.Add(fieldName, fieldName);
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
