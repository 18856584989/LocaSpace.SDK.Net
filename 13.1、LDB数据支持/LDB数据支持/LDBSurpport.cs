using GeoScene.Data;
using GeoScene.Engine;
using GeoScene.Globe;
using System;
using System.Windows.Forms;

namespace LDBSupport
{
    public partial class LDBSurpport : Form
    {
        private GSOGlobeControl _glbControl;
        private TreeNode _layerManagerNode;
        private string _shpLayer = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LayerTest/LayerTest.shp");

        GSODataSource _ldbDataSource;
        GSOLayer _featureLayer;

        /// <summary>
        /// 初始化加载
        /// </summary>
        public LDBSurpport()
        {
            InitializeComponent();
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_glbControl);
            _glbControl.AfterLayerAddEvent += new AfterLayerAddEventHandler(globeControl1_AfterLayerAddEvent);
            InitNode();
        }

        /// <summary>
        /// 添加图层根节点
        /// </summary>
        private void InitNode()
        {
            _layerManagerNode = new TreeNode();
            _layerManagerNode.Checked = true;
            _layerManagerNode.Text = "图层管理";
            this.TreeView.Nodes.Add(_layerManagerNode);
        }

        /// <summary>
        /// 添加数据之后根据数据创建节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void globeControl1_AfterLayerAddEvent(object sender, AfterLayerAddEventArgs e)
        {
            if (e.Layer == null)
            {
                return;
            }
            TreeNode node = new TreeNode();
            node.Tag = e.Layer;
            node.Name = e.Layer.Name;
            node.Text = e.Layer.Caption + System.IO.Path.GetExtension(e.Layer.Name);
            node.Checked = e.Layer.Visible;
            _layerManagerNode.Nodes.Insert(0, node);
            _layerManagerNode.Expand();
        }

        /// <summary>
        /// 创建ldb数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CreateLDB_Click(object sender, EventArgs e)
        {
            //保存文件窗口
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "*.ldb | *.ldb";
            dialog.OverwritePrompt = false;
            if (dialog.ShowDialog() != DialogResult.OK )
                return;
            if(System.IO.File.Exists(dialog.FileName))
            {
                MessageBox.Show("文件已存在，数据文件不可覆盖。");
                return;
            }

            //创建数据库连接
            GSODataSourceCnn dataSourceCnn = new GSODataSourceCnn();
            //设置连接类型为LDB
            dataSourceCnn.Type = EnumDataSourceType.LDB;
            //绑定ldb文件
            dataSourceCnn.Database = dialog.FileName;
            //创建ldb数据库
            _ldbDataSource = _glbControl.Globe.DataManager.CreateDataSource(dataSourceCnn);

            //窗口名称修改为当前创建的数据库
            this.Text = this.Text.Split('_')[0] + "_" + dialog.FileName;
            btn_EditLayer.Enabled = true;

            _glbControl.Globe.Layers.RemoveAll();
            TreeView.Nodes[0].Nodes.Clear();
            _featureLayer = null;
            btn_EditFeature.Enabled = false;
        }

        /// <summary>
        /// 打开LDB数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenLDB_Click(object sender, EventArgs e)
        {
            //打开窗口
            OpenFileDialog openDia = new OpenFileDialog();
            openDia.Filter = "*.ldb | *.ldb";
            if (openDia.ShowDialog() != DialogResult.OK)
                return;
            _glbControl.Globe.Layers.RemoveAll();
            TreeView.Nodes[0].Nodes.Clear();
            //创建数据库链接
            GSODataSourceCnn dataSourceCnn = new GSODataSourceCnn();
            //设置数据库链接为LDB
            dataSourceCnn.Type = EnumDataSourceType.LDB;
            //绑定数据库文件
            dataSourceCnn.Database = openDia.FileName;
            //打开数据库链接
            _ldbDataSource = _glbControl.Globe.DataManager.OpenDataSource(dataSourceCnn);
            btn_EditLayer.Enabled = true;
            //遍历LDB数据库中的所有图层
            for (int i = 0; i < _ldbDataSource.DatasetCount; i++)
            {
                //获得LDB数据库中的图层数据
                var featuredata = _ldbDataSource[i];
                //将图层数据加载到Globe控件中
                _glbControl.Globe.Layers.Add(featuredata);
            }

            this.Text = this.Text.Split('_')[0] + "_" + openDia.FileName;
            //如果数据库中图层数据不为空
            if (_ldbDataSource.DatasetCount > 0)
            {
                //当前编辑图层赋值
                _featureLayer = _glbControl.Globe.Layers[0];
                btn_EditFeature.Enabled = true;
                this.Text = this.Text + "_" + _featureLayer.Caption;
            }
            else
                btn_EditFeature.Enabled = false;
        }

        /// <summary>
        /// 向LDB中新建图层数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditLayer_Click(object sender, EventArgs e)
        {
            //添加名为Test的图层数据
            GSOFeatureDataset dataset = _ldbDataSource.CreateFeatureDataset("Test");
            //将新建的图层数据添加到Globe控件中
            GSOLayer featureLayer = _glbControl.Globe.Layers.Add(dataset);
            btn_EditFeature.Enabled = true;
        }

        /// <summary>
        /// 向图层数据中添加要素Feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditFeature_Click(object sender, EventArgs e)
        {
            //新建要素
            GSOGeoPolygon3D polygon = new GSOGeoPolygon3D();
            GSOPoint3ds points = new GSOPoint3ds();
            points.Add(new GSOPoint3d(120, 30, 0));
            points.Add(new GSOPoint3d(120.004, 30, 0));
            points.Add(new GSOPoint3d(120.002, 30.001, 0));
            polygon.AddPart(points);

            GSOFeature feature = new GSOFeature();
            feature.Geometry = polygon;

            _featureLayer.AddFeature(feature);

            _glbControl.Globe.MemoryLayer.AddFeature(feature);
            _glbControl.Globe.FlyToFeature(feature);

            _featureLayer.Save();
        }
    }
}
