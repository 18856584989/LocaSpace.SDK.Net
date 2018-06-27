using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 测量
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
        }

        /// <summary>
        /// 恢复鼠标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.ActionNull;
        }

        /// <summary>
        /// 三角测量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //更改鼠标动作
            globeControl1.Globe.Action = EnumAction3D.MeasureDistance;
            //更改来测量动作
            globeControl1.Globe.DistanceRuler.MeasureMode = EnumDistanceMeasureMode.HVSLineMeasure;
        }

        /// <summary>
        /// 高度测量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //改变鼠标动作
            globeControl1.Globe.Action = EnumAction3D.MeasureHeight;
            //变更测量模式
            globeControl1.Globe.HeightRuler.SpaceMeasure = true;
        }

        /// <summary>
        /// 测量地表距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //改变鼠标动作
            globeControl1.Globe.Action = EnumAction3D.MeasureDistance;
            //变更测量模式
            globeControl1.Globe.DistanceRuler.MeasureMode = EnumDistanceMeasureMode.GroundPolylineMeasure;
        }

        /// <summary>
        /// 测量空间距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //改变鼠标动作
            globeControl1.Globe.Action = EnumAction3D.MeasureDistance;
            //变更测量模式
            globeControl1.Globe.DistanceRuler.MeasureMode = EnumDistanceMeasureMode.SpacePolylineMeasure;
        }

        /// <summary>
        /// 测量投影距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //改变鼠标动作
            globeControl1.Globe.Action = EnumAction3D.MeasureDistance;
            //变更测量模式
            globeControl1.Globe.DistanceRuler.MeasureMode = EnumDistanceMeasureMode.HoriLineMeasure;

        }

        /// <summary>
        /// 测量地表面积
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //改变鼠标动作
            globeControl1.Globe.Action = EnumAction3D.MeasureArea;
            //变更测量模式
            globeControl1.Globe.AreaRuler.MeasureMode = EnumAreaMeasureMode.GroundAreaMeasure;
        }

        /// <summary>
        /// 测量空间面积
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            //改变鼠标动作
            globeControl1.Globe.Action = EnumAction3D.MeasureArea;
            //变更测量模式
            globeControl1.Globe.AreaRuler.MeasureMode = EnumAreaMeasureMode.SpaceAreaMeasure;
        }

        /// <summary>
        /// 测量投影面积
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            //改变鼠标动作
            globeControl1.Globe.Action = EnumAction3D.MeasureArea;
            //变更测量模式
            globeControl1.Globe.AreaRuler.MeasureMode = EnumAreaMeasureMode.SphereAreaMeasure;
        }

        /// <summary>
        /// 清除测量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            //清除测量
            globeControl1.Globe.ClearMeasure();
            //刷新球
            globeControl1.Globe.Refresh();
        }

    }
}
