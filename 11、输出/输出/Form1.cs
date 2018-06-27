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

namespace 输出
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        string sizeStr = "{0}*{1} 像素";

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labSize.Text = string.Format(sizeStr, panel1.Width, panel1.Height);
            labOutSize.Text = string.Format(sizeStr, panel1.Width * numericUpDown1.Value,
                panel1.Height * numericUpDown1.Value);
        }

        /// <summary>
        /// 高清截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //获得输出大小
            float outWidth = (float)(panel1.Width*numericUpDown1.Value);
            float outHeight = (float) (panel1.Height*numericUpDown1.Value);
            //球输出（输出长像素，输出宽像素，输出地址）
            bool isOK = globeControl1.Globe.OutputHighPic(outWidth, outHeight, Application.StartupPath + "/images/test.jpg");

            if (isOK) MessageBox.Show("截图成功");
        }

        /// <summary>
        /// num控件改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            labOutSize.Text = string.Format(sizeStr, panel1.Width*numericUpDown1.Value,
                panel1.Height*numericUpDown1.Value);
        }
        /// <summary>
        /// 改变窗口界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            Form1_Load(null,null);
        }
    }
}
