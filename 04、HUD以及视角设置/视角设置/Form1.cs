using System;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 视角设置
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        GSOCameraState camera;
        bool isLockVerticalCamera = false;

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            globeControl1.BeforeSceneRenderEvent += (sender, e) =>
            {
                if (isLockVerticalCamera)
                {
                    globeControl1.Globe.SetCenterTilt(0.0);
                }
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //添加图层，以便观察视角的改变
            globeControl1.Globe.Layers.Add(
                Application.StartupPath +
                "\\Resource\\gisdata\\tianditudata\\天地图影像.lrc");
            globeControl1.Globe.Layers.Add(
                Application.StartupPath +
                "\\Resource\\gisdata\\tianditudata\\天地图标注.lrc");
        }

        #region FlyToCameraState

        /// <summary>
        /// FlyToCameraState
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SetCamera();
            globeControl1.Globe.FlyToCameraState(camera);
        }

        #endregion

        #region JumpToCameraState

        /// <summary>
        /// JumpToCameraState
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SetCamera();
            globeControl1.Globe.JumpToCameraState(camera);
        }

        #endregion

        #region 全球视角

        /// <summary>
        /// 全球视角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            GSOCameraState camestate = new GSOCameraState();
            camestate.Longitude = 109.07286491474;
            camestate.Latitude = 37.3716091749733;
            camestate.Distance = 20732473.52;
            globeControl1.Globe.JumpToCameraState(camestate);
        }

        #endregion

        #region 正北方向

        /// <summary>
        /// 正北方向
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //设置视角为当前视角，不会改变经纬度
            GSOCameraState camestate = globeControl1.Globe.CameraState;
            camestate.Heading = 0.0;
            globeControl1.Globe.JumpToCameraState(camestate);
        }

        #endregion

        #region 垂直视角

        /// <summary>
        /// 垂直视角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //设置视角为当前视角，不会改变经纬度
            GSOCameraState camestate = globeControl1.Globe.CameraState;
            camestate.Tilt = 0.0;
            globeControl1.Globe.JumpToCameraState(camestate);
        }

        #endregion

        #region 锁定垂直视角

        /// <summary>
        /// 锁定垂直视角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            isLockVerticalCamera = !isLockVerticalCamera;
            globeControl1.Refresh();
        }

        #endregion

        #region 设置摄像机状态

        /// <summary>
        /// 设置摄像机状态
        /// </summary>
        private void SetCamera()
        {
            //新建一个摄像机状态对象
            camera = new GSOCameraState();
            //camera.Altitude = 20000;    //设置视点离地面的垂直距离
            //设置视点的高度模式，支持三种模式，绝对高度，相对地面高度，贴地
            //camera.AltitudeMode = EnumAltitudeMode.ClampToGround;
            //设置视点高度，真实高度，不可与Altitude、AltitudeMode公用
            camera.Distance = 1000;
            //视线的方向与正北的夹角，0度表示正北，90度表示正东，180度表示正南
            camera.Heading = 0;
            camera.Latitude = 31.3283140323302;  //设置视点的经度
            camera.Longitude = 120.417888231016; //设置视点的纬度
            //视线与铅垂线的夹角，0度表示垂直向下看，90度表示沿水平方向看
            camera.Tilt = 0;
        }


        #endregion

        #region 地上视角

        /// <summary>
        /// 地上视角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            //如果之前是地下视角，则重新设置视角，如果不是，就只改变状态
            if (globeControl1.Globe.CameraMode == EnumCameraMode.UnderGround)
            {
                //视角变更为普通
                globeControl1.Globe.CameraMode = EnumCameraMode.Navigation;
                //把当前的摄像机状态复制
                GSOCameraState state = globeControl1.Globe.CameraState;
                //设定俯仰角度
                if (globeControl1.Globe.CameraState.Tilt < 95 && globeControl1.Globe.CameraState.Tilt > 85)
                {
                    state.Tilt = 85;
                }
                else
                {
                    state.Tilt = 180 - globeControl1.Globe.CameraState.Tilt;
                }
                //跳转
                globeControl1.Globe.JumpToCameraState(state);
            }
            else
            {
                globeControl1.Globe.CameraMode = EnumCameraMode.Navigation;
            }
        }


        #endregion

        #region 行走视角

        /// <summary>
        /// 行走视角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.CameraMode = EnumCameraMode.Walk;
        }


        #endregion

        #region 地下视角

        /// <summary>
        /// 地下视角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.CameraMode = EnumCameraMode.UnderGround;
            GSOCameraState state = globeControl1.Globe.CameraState;
            if (globeControl1.Globe.CameraState.Tilt < 95 && globeControl1.Globe.CameraState.Tilt > 85)
            {
                state.Tilt = 95;
            }
            else
            {
                state.Tilt = 180 - globeControl1.Globe.CameraState.Tilt;
            }
            globeControl1.Globe.JumpToCameraState(state);
        }

        #endregion
    }
}
