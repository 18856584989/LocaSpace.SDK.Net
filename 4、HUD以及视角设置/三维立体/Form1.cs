using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 三维立体
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        bool isFullScreen = false;
        FormWindowState fws;
        bool is3D = false;

        Rectangle rectangleOld = new Rectangle(0, 0, 0, 0);

        public Form1()
        {
            InitializeComponent();

            //初始化控件
            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 三维立体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            is3D = !is3D;
            FullScreen();
            globeControl1.Globe.SetStereoEnable(is3D);
            globeControl1.Globe.SetStereoMode(EnumStereoMode.HORIZONTAL_SPLIT);
        }

        /// <summary>
        /// 键盘注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    FullScreen();
                    is3D = !is3D;
                    break;
                //Esc仅用于退出全屏
                case Keys.Escape:
                    if (isFullScreen)
                    {
                        FullScreen();
                        is3D = !is3D;
                    }
                    break;
                default:
                    break;
            }
        }


        #region 地图全屏

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
                this.FormBorderStyle = FormBorderStyle.Sizable;
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
            IntPtr trayHwnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd", null);
            if (fullscreen)
            {
                ShowWindow(trayHwnd, 0);
                Rectangle rectFull = Screen.PrimaryScreen.Bounds;
                SystemParametersInfo(SPI_GETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//get 
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectFull, SPIF_UPDATEINIFILE);//set 

            }
            else
            {
                ShowWindow(trayHwnd, 1);
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);
            }
            return true;
        }

        #region 引用系统DLL

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        private static extern int ShowWindow(int hWnd, int _value);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern int SystemParametersInfo(
                int uAction,
                int uParam,
                ref Rectangle lpvParam,
                int fuWinIni
                );

        public const int SPI_SETWORKAREA = 47;
        public const int SPI_GETWORKAREA = 48;
        public const int SW_SHOW = 5;
        private const int SW_HIDE = 0;  //隐藏任务栏
        private const int SW_RESTORE = 9;//显示任务栏
        public const int SPIF_UPDATEINIFILE = 0x1;

        #endregion

        #endregion
    }
}
