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
using WorldGIS.Classes;
using System.IO;
using System.Collections;
using GeoScene.Data;

namespace PhotoTrack
{
    public partial class Form1 : Form
    {
        //创建球对象
        GSOGlobeControl globeControl1;
        private GSOLayer layerTemp;

        double EARTH_RADIUS = 6378137.0;
        double DTOR = 0.01745329251994329576923690768333;

        public Form1()
        {
            InitializeComponent();

            //添加球
            globeControl1 = new GSOGlobeControl();
            this.splitContainer1.Panel2.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            globeControl1.Globe.UserBackgroundColorValid = true;
            globeControl1.Globe.UserBackgroundColor = Color.White;
            globeControl1.Globe.LatLonGrid.Visible = false; //经纬网
            globeControl1.Globe.OverviewControl.Visible = false;//鹰眼
            globeControl1.Globe.ControlPanel.Visible = false;//控制面板
            globeControl1.Globe.ScalerControl.Visible = false; //比例尺
            globeControl1.Globe.StatusBar.Visible = false;//状态栏
            globeControl1.Globe.Atmosphere.Visible = true;    //大气层
            globeControl1.Globe.Atmosphere.ShaderUsing = true; //光影大气
            globeControl1.Globe.MarbleVisible = false;    //大气雾效/大理石表面
            globeControl1.Globe.UnderGroundFloor.Visible = false; //地下网格
            globeControl1.Globe.Antialiasing = true;           //反走样
            globeControl1.Globe.BothFaceRendered = false;
            globeControl1.Globe.FlyToPointSpeed = 200000;//飞行速度
            globeControl1.Globe.EditClampObject = false;//是否依附对象
            globeControl1.Globe.FeatureMouseOverEnable = true;  //允许鼠标浮动
            globeControl1.Globe.Object2DMouseOverEnable = false;//是否鼠标手势提示
            globeControl1.Globe.IsReleaseMemOutOfView = false;//超出视野重新加载
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            Picturexif picInfo = new Picturexif();
            this.Cursor = Cursors.WaitCursor; 
            string[] filesphoto = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpg", SearchOption.AllDirectories);
            listView1.Items.Clear();
            Picturexif em = new Picturexif();
            string imgInfo = "";
            for (int i = 0; i < filesphoto.Length; i++)
            {
                imgInfo = em.GetGPSCoordinate(filesphoto[i]);
                if (imgInfo != null && imgInfo.Split('+').Length > 2)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems[0].Text = i.ToString();
                    item.SubItems.Add(Path.GetFileName(filesphoto[i]));
                    item.SubItems.Add(imgInfo.Split('+')[2]);
                    item.SubItems.Add(Convert.ToDouble(imgInfo.Split('+')[1]).ToString("f6"));//经度
                    item.SubItems.Add(Convert.ToDouble(imgInfo.Split('+')[0]).ToString("f6"));//纬度
                    item.SubItems.Add(filesphoto[i]);//图片的路径
                    listView1.Items.Add(item);
                }
            }
            this.listView1.ListViewItemSorter = new ListViewSort(2, true);//按时间排序
            this.listView1.Sort();
            this.Cursor = Cursors.Default;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            double dMinLon = 0, dMaxLon = 0, dMinLat = 0, dMaxLat = 0;
            string strLayerPath = saveFileDialog1.FileName;
            string path = Application.StartupPath + "\\Resource\\image\\DefaultIcon.png";
            if (string.IsNullOrEmpty(saveFileDialog1.FileName))
            {
                MessageBox.Show("请选择存储目录");
                return;
            }
            globeControl1.Globe.MemoryLayer.SaveAs(strLayerPath);
            layerTemp = globeControl1.Globe.Layers.Add(strLayerPath);
            layerTemp.RemoveAllFeature();
            GSOGeoPolyline3D polyLine = new GSOGeoPolyline3D();
            GSOPoint3ds pois = new GSOPoint3ds();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ListViewItem item = listView1.Items[i];
                double lon, lat;
                if (!double.TryParse(item.SubItems[3].Text.ToString() == "" ? "0" : item.SubItems[3].Text.ToString(), out lon))
                {
                    MessageBox.Show("经度参数不合法");
                    return;
                }
                if (!double.TryParse(item.SubItems[4].Text.ToString() == "" ? "0" : item.SubItems[4].Text.ToString(), out lat))
                {
                    MessageBox.Show("纬度参数不合法");
                    return;
                }
                if (i == 0)
                {
                    dMaxLon = lon;
                    dMinLon = lon;
                    dMinLat = lat;
                    dMaxLat = lat;
                }
                GSOPoint3d node = new GSOPoint3d(lon, lat, 0);
                pois.Add(node);
                string strDescriptionPrefix = "<![CDATA[<!-- <BALLOON><CONTENT_CX>800</CONTENT_CX><CONTENT_CY>600</CONTENT_CY>"
                    + "<CONTENT_TYPE>link</CONTENT_TYPE><SHOW_MODE>balloonex</SHOW_MODE>-->";

                string strDescription = strDescriptionPrefix + "file:\\\\" + Application.StartupPath + "\\Resource\\Page\\pic_route.html";
                strDescription += "?URL=" + item.SubItems[5].Text.ToString();
                //strDescription += "]]>";
                AddMarker(item.SubItems[1].Text.ToString(), lon, lat, path, strDescription, layerTemp);

                if (lon < dMinLon)
                {
                    dMinLon = lon;
                }
                else if (lon > dMaxLon)
                {
                    dMaxLon = lon;
                }
                if (lat < dMinLat)
                {
                    dMinLat = lat;
                }
                else if (lat > dMaxLat)
                {
                    dMaxLat = lat;
                }
            }
            if (layerTemp == null)
            {
                MessageBox.Show("没有生成轨迹的数据");
                return;
            }
            polyLine.AddPart(pois);
            GSOFeature feature = new GSOFeature();
            feature.Geometry = polyLine;
            layerTemp.AddFeature(feature);//添加线
            layerTemp.SaveAs(strLayerPath);
            globeControl1.Globe.FlyToFeature(feature);


        }

        /// <summary>
        /// 添加地标
        /// </summary>    
        private bool AddMarker(string name, double lon, double lat, string path, string description, GSOLayer layer)
        {
            try
            {
                GSOFeature newFeature = new GSOFeature();
                GSOGeoMarker p = new GSOGeoMarker();
                GSOMarkerStyle3D style = new GSOMarkerStyle3D();

                style.IconPath = path;
                p.Style = style;
                p.X = lon;
                p.Y = lat;
                p.Text = name.Substring(0, name.Length - 4);
                p.AltitudeMode = EnumAltitudeMode.ClampToGround;
                newFeature.Geometry = p;
                newFeature.Name = name;
                newFeature.Description = description + " ";
                layer.AddFeature(newFeature);
                return true;
            }
            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "(Kml文件)|*.kml";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox2.Text = saveFileDialog1.FileName;
        }

    }

    class ListViewSort : IComparer
    {
        private int col;
        private bool descK;
        public ListViewSort()
        {
            col = 0;
        }
        public ListViewSort(int column, object Desc)
        {
            descK = (bool)Desc;
            col = column;
        }
        public int Compare(object x, object y)
        {
            int tempInt = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            if (descK) return -tempInt;
            else return tempInt;
        }
    }
}
