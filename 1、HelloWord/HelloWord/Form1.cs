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

namespace HelloWord
{
    public partial class Form1 : Form
    {
        //创建球对象
        GSOGlobeControl globeControl1;

        public Form1()
        {
            InitializeComponent();

            //添加球
            globeControl1 = new GSOGlobeControl();
            this.Controls.Add(globeControl1);
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
    }
}
