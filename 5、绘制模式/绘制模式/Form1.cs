using System.Drawing;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 绘制模式
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        Point Location_MouseDown;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            //鼠标按下事件，获取坐标
            globeControl1.MouseDown += (sender, e) =>
            {
                Location_MouseDown = e.Location;
            };

            globeControl1.MouseUp += (sender, e) =>
            {
                //鼠标抬起如果坐标不能对上，就认定为拖动球，不反应
                if (Location_MouseDown != e.Location)
                    return;

                if (e.Button == MouseButtons.Left)
                {
                    //如果按照上面示例按我们方法添加HUD，需要加上这个判断，判断是否点在HUD中
                    //if (isMouseInHudControl == false)
                    {
                        if (globeControl1.Globe.Action == EnumAction3D.NormalHit)
                        {
                            GSOPoint3d point3d = new GSOPoint3d();

                            GSOFeature newFeature = new GSOFeature();
                            GSOGeoMarker p = new GSOGeoMarker();
                            GSOMarkerStyle3D style = new GSOMarkerStyle3D();
                            style.IconPath = Application.StartupPath + "/Resource/image/DefaultIcon.png";
                            p.Style = style;
                            p.Z = point3d.Z <= 0 ? 0 : point3d.Z;
                            if (point3d.Z <= 0.0)
                            {
                                point3d = globeControl1.Globe.ScreenToScene(e.X, e.Y);
                            }
                            p.X = point3d.X;
                            p.Y = point3d.Y;
                            p.Z = point3d.Z;
                            newFeature.Geometry = p;
                            newFeature.Name = "我的地标";

                            globeControl1.Globe.MemoryLayer.AddFeature(newFeature);
                            globeControl1.Globe.Action = EnumAction3D.ActionNull;
                        }
                    }
                }
            };
        }

        /// <summary>
        /// 绘制线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.NormalHit;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.DrawPolyline;
            //分析线
            //globeControl1.Globe.Action = EnumAction3D.TrackPolyline;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.DrawPolygon;
            //分析面
            //globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
        }

        private void btn_DrawWater_Click(object sender, System.EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.DrawWater;
        }
    }
}
