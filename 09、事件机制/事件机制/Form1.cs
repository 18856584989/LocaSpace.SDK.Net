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

namespace 事件机制
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            //在用Delete键删除要素之后
            globeControl1.AfterKeyDownDeleteFeatureEvent += (sender, args) => { };
            //在用Delete键删除要素之后
            globeControl1.BeforeKeyDownDeleteFeatureEvent += (sender, args) => { };

            //在要素上点击鼠标
            globeControl1.FeatureMouseClickEvent += (sender, args) => { };
            //鼠标在要素内保持静止一段时间
            globeControl1.FeatureMouseHoverEvent += (sender, args) => { };
            //鼠标进入要素内部
            globeControl1.FeatureMouseIntoEvent += (sender, args) => { };
            //鼠标离开要素内部
            globeControl1.FeatureMouseOutEvent += (sender, args) => { };
            //鼠标在要素上
            globeControl1.FeatureMouseOverEvent += (sender, args) => { };
            
            //鼠标在HUD双击
            globeControl1.HudControlMouseDbClickEvent += (sender, args) => { };
            //鼠标进入HUD
            globeControl1.HudControlMouseIntoEvent += (sender, args) => { };
            //鼠标移出HUD
            globeControl1.HudControlMouseOutEvent += (sender, args) => { };
            //鼠标移过HUD
            globeControl1.HudControlMouseMoveEvent += (sender, args) => { };
            //鼠标在HUD上抬起
            globeControl1.HudControlMouseUpEvent += (sender, args) => { };
            //鼠标在HUD上按下
            globeControl1.HudControlMouseDownEvent += (sender, args) => { };

            //在线加载地形之后
            globeControl1.AfterNetTerrainAddEvent += (sender, args) => { };
            //在线加载图层之后
            globeControl1.AfterNetLayerAddEvent += (sender, args) => { };
            //在线加载工程之后
            globeControl1.AfterNetSceneAddEvent += (sender, args) => { };
            //添加图层之后
            globeControl1.AfterLayerAddEvent += (sender, args) => { };
            //图层移动之后
            globeControl1.AfterLayerMoveEvent += (sender, args) => { };
            //图层移除之后
            globeControl1.AfterLayerRemoveEvent += (sender, args) => { };
            //地形添加之后
            globeControl1.AfterTerrainAddEvent += (sender, args) => { };
            //地形移动之后
            globeControl1.AfterTerrainMoveEvent += (sender, args) => { };
            //地形移除之后
            globeControl1.AfterTerrainRemoveEvent += (sender, args) => { };

            //移除图层之前
            globeControl1.BeforeLayerRemoveEvent += (sender, args) => { };
            //移除地形之前
            globeControl1.BeforeTerrainRemoveEvent += (sender, args) => { };
            //读取工程之前
            globeControl1.BeforeSceneRenderEvent += (sender, args) => { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "/Resource/gisdata/baidudata/百度标注.lrc";
            globeControl1.Globe.Layers.Add(path);
        }
    }
}
