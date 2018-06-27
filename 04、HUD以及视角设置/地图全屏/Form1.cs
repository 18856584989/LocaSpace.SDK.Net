using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GeoScene.Globe;

namespace 基本控制以及HUD
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        //保存现在是否已经全屏的状态
        bool isFullScreen = false;
        //保存未全屏之前的窗口大小坐标信息
        Rectangle rectangleOld = new Rectangle(0, 0, 0, 0);
        //保存未全屏之前，窗口的显示信息
        FormWindowState fws;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 按钮开始全屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FullScreen();
        }

        /// <summary>
        /// 按键盘开始全屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    FullScreen();
                    break;
                    //Esc仅用于退出全屏
                case Keys.Escape:
                    if (isFullScreen)
                    {
                        FullScreen();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 开始全屏
        /// </summary>
        private void FullScreen()
        {
            SetFullScreen(!isFullScreen, ref rectangleOld);
            //是否在任务栏显示图标
            this.ShowInTaskbar = isFullScreen;
            //判断是否为全屏，是全屏就隐藏（这里需要把所有控件隐藏）
            panel1.Dock = isFullScreen == false ? DockStyle.Fill : DockStyle.Left;
            button1.Visible = isFullScreen;
            //临时挂起布局逻辑
            this.SuspendLayout();
            if (!isFullScreen)
            {
                fws = this.WindowState;
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                globeControl1.Globe.SetStereoEnable(false);
                this.WindowState = fws;
            }
            this.ResumeLayout(false);
            isFullScreen = !isFullScreen;
            this.Focus();
        }

        /// <summary> 
        /// 设置全屏或取消全屏 
        /// </summary> 
        /// <param name="fullscreen">true:全屏 false:恢复 </param> 
        /// <param name="rectOld">设置的时候，此参数返回原始尺寸，恢复时用此参数设置恢复 </param> 
        /// <returns>设置结果 </returns> 
        public static bool SetFullScreen(bool fullscreen, ref Rectangle rectOld)
        {
            if (fullscreen)
            {
                Rectangle rectFull = Screen.PrimaryScreen.Bounds;
                SystemParametersInfo(SPI_GETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//get 
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectFull, SPIF_UPDATEINIFILE);//set 
            }
            else
            {
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);
            }
            return true;
        }

        #region 引用系统DLL

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        private static extern int ShowWindow(int hWnd, int _value);
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern int SystemParametersInfo(
                int uAction,
                int uParam,
                ref Rectangle lpvParam,
                int fuWinIni
                );

        public const int SPI_SETWORKAREA = 47;
        public const int SPI_GETWORKAREA = 48;
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
        public const int SPIF_UPDATEINIFILE = 0x0001;

        #endregion
    }
}
