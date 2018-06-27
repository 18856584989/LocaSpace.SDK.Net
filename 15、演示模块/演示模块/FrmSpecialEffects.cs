using System;
using System.Windows.Forms;
using GeoScene.Globe;
using GeoScene.Data;
using System.Drawing;
using System.IO;
using Emgu.CV;

namespace LSVSpecialEffects
{
    public partial class FrmSpecialEffects : Form
    {
        private GSOGlobeControl _glbControl;
        //倾斜摄影图层
        GSOLayer lfpLayer;
        private string _fire1Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image/fire_final_1.png");
        private string _fire2Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image/fire_final_2.png");
        private string _smokePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image/smoke1.png");
        private string _waterDropPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image/test.png");
        private string _flarePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image/flare.png");

        private string _videoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Video/LocaSpace.mp4");

        private string _planAnimatePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Animate/飞机飞行.lgd");
        private string _missileAnimatePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Animate/火力打击.lgd");

        private string _tailName = "船尾迹";
        private string _RotorWashName = "涡轮";

        //视频投射源
        private GSOVideoCamera _gsoVideoCamera;
        //视频信息
        private VideoCapture _videoCapture;

        public FrmSpecialEffects()
        {
            InitializeComponent();
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_glbControl);
        }

        //海水
        private void btn_Ocean_Click(object sender, EventArgs e)
        {
            //关闭海水
            if (_glbControl.Globe.Ocean.Visible)
            {
                //海洋效果关闭
                _glbControl.Globe.Ocean.Visible = false;
                // 移除所有船尾迹
                _glbControl.Globe.Ocean.RemoveAllShipWake();
                // 移除所有涡轮效果
                _glbControl.Globe.Ocean.RemoveAllRotorWash();
                //移除所有要素
                _glbControl.Globe.MemoryLayer.RemoveAllFeature();
                btn_Ocean.Text = "开启海水";
            }
            //开启海水
            else
            {
                //海洋效果开启
                _glbControl.Globe.Ocean.Visible = true;
                //设置飞行到水面上
                GSOCameraState camera = new GSOCameraState();
                camera.Latitude = 0;
                camera.Longitude = 0;
                camera.Distance = 500;
                camera.Tilt = 45;
                _glbControl.Globe.JumpToCameraState(camera);
                btn_Ocean.Text = "关闭海水";
            }
        }

        //粒子系统
        private void btn_Particle_Click(object sender, EventArgs e)
        {
            if (_glbControl.Globe.Ocean.Visible)
                btn_Ocean.PerformClick();

            GSORectParticleEmitter emitter = new GSORectParticleEmitter();
            //设置粒子初始大小
            emitter.Length = 10;
            emitter.Width = 20;
            //纹理路径
            emitter.TexturePath = _flarePath;
            //每秒喷射数量，每秒两个
            emitter.EmitPerSec = 3;
            //重力加速度
            emitter.GravityAcc = 8.9f;

            //场景中最大粒子数量，30个
            emitter.MaxCount = 30;
            //初始粒子个数
            emitter.InitCount = 20;

            //开始时间，从Play时开始(好像不管用)
            emitter.StartEmitTime = 30;
            //喷射持续时间  秒，默认负数，表示不限制
            emitter.EndEmitTime = 50;

            //粒子存活时间 秒
            emitter.LifeFix = 1;
            //粒子生命值变化范围(随机生命)
            emitter.LifeRnd = 10;

            //发射速度 米/s
            emitter.VelFix = 100;
            //发射速度变化范围
            emitter.VelRnd = 10;

            //粒子初始旋转角度 度
            emitter.RotFix = 1;
            //粒子初始旋转角度变化范围
            emitter.RotRnd = 10;

            //粒子旋转速度 度/s
            emitter.RotVelFix = -180;
            //粒子旋转速度变化范围
            emitter.RotVelRnd = 0;

            //粒子初始化大小倍数
            emitter.SizeFix = new GSOPoint2d(10, 10);
            //粒子初始化大小倍数变化范围
            emitter.SizeRnd = new GSOPoint2d(1, 1);

            //发射器方向角
            emitter.AngleXYFix = 90;
            //发射器方向角变化范围，可以理解为XY范围值
            emitter.AngleXYRnd = 0;

            //发射器高度角
            emitter.AngleXZFix = 45;
            //发射器高度角变化范围，可以理解为XZ范围值
            emitter.AngleXZRnd = 45;

            //粒子颜色变化初始值
            emitter.ColorRndStart = Color.AliceBlue;
            //粒子颜色变化终止值
            emitter.ColorRndEnd = Color.Gray;

            //亮度是否叠加
            emitter.IsLumAdded = true;
            //是否独立于发射器
            emitter.IsParticleIndepend = false;

            GSOScaleParticleEffector scaleEffect = new GSOScaleParticleEffector();
            //设定变化值(相对初始化值X,Y值增加10倍)
            scaleEffect.SetScale(10, 10);
            //开始/结束生效的时间的类型，相对出生时间、百分比，还是相对死亡的时间、百分比,默认是相对出生的时间（秒）
            scaleEffect.StartTimeType = EnumEffectorTimeType.FromBornSeconds;
            scaleEffect.EndTimeType = EnumEffectorTimeType.FromBornSeconds;
            scaleEffect.StartTime = 1;
            scaleEffect.EndTime = 5;
            //添加效果
            emitter.AddEffector(scaleEffect);

            //创建粒子场景要素
            GSOGeoParticle geoParticle = new GSOGeoParticle();
            //设置场景位置
            geoParticle.SetPosition(_glbControl.Globe.CameraState.Longitude, _glbControl.Globe.CameraState.Latitude, 0);
            //将发射器添加到粒子场景要素中
            geoParticle.AddEmitter(emitter);
            //播放
            geoParticle.Play();

            //创建要素
            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoParticle;
            //添加要素
            _glbControl.Globe.MemoryLayer.AddFeature(feature);
            _glbControl.Globe.JumpToFeature(feature, 100);
        }

        //火
        private void btn_Fire_Click(object sender, EventArgs e)
        {
            if (_glbControl.Globe.Ocean.Visible)
                btn_Ocean.PerformClick();

            //烟火粒子示例,由三个发射器构成
            GSOGeoParticle geoParticle = new GSOGeoParticle();
            // 添加到相机当前经纬度位置
            geoParticle.SetPosition(_glbControl.Globe.CameraState.Longitude, _glbControl.Globe.CameraState.Latitude, 0);

            //创建环形烟雾粒子发射器
            GSORingParticleEmitter emitterSmoke = new GSORingParticleEmitter();
            //添加烟雾纹理
            emitterSmoke.TexturePath = _smokePath;
            //设置粒子大小
            emitterSmoke.SetSizeFix(20, 20); //20,20
            //初始速度
            emitterSmoke.VelFix = 70; //70
            //重力加速度(负值为向上加速)
            emitterSmoke.AccFix = -3.0f; //-0.3f
            //发射方向为四周，呈圆形
            emitterSmoke.AngleXYFix = 0;
            emitterSmoke.AngleXYRnd = 180;

            //发射高度角为80-90度
            emitterSmoke.AngleXZFix = 85;
            emitterSmoke.AngleXZRnd = 5;
            //内环半径
            emitterSmoke.InnerRadius = 0;
            //外环半径
            emitterSmoke.OuterRadius = 30;
            //生命1-3秒
            emitterSmoke.LifeFix = 2.0f;
            emitterSmoke.LifeRnd = 1.0f;
            //初始旋转角度-10-10度
            emitterSmoke.RotFix = 0;
            emitterSmoke.RotRnd = 10;
            //旋转速度-180-180度/s
            emitterSmoke.RotVelFix = -180;
            emitterSmoke.RotVelRnd = 0;

            //发射速度60个/s
            emitterSmoke.EmitPerSec = 60;
            emitterSmoke.ColorRndStart = Color.Black;
            emitterSmoke.ColorRndEnd = Color.Black;

            emitterSmoke.IsLumAdded = false;

            GSOScaleParticleEffector effectorSmokeStart = new GSOScaleParticleEffector();
            effectorSmokeStart.SetScale(4, 4);  //4,4
            effectorSmokeStart.StartTime = 0;
            effectorSmokeStart.EndTime = 1.8f;
            // 添加效果器
            emitterSmoke.AddEffector(effectorSmokeStart);

            GSOColorParticleEffector effectorSmokeEnd = new GSOColorParticleEffector();
            effectorSmokeEnd.SetColorChanged(0.6f, 0.6f, 0.6f, 0);
            effectorSmokeEnd.StartTime = 0;
            // 负数表示整个粒子生命结束
            effectorSmokeEnd.EndTime = -1;
            emitterSmoke.AddEffector(effectorSmokeEnd);

            GSOColorParticleEffector effector3 = new GSOColorParticleEffector();
            //粒子透明
            effector3.SetColorChanged(0, 0, 0, -1);
            // 距离粒子生命结束0.5秒
            effector3.StartTime = 0.5f;
            effector3.StartTimeType = EnumEffectorTimeType.ToDeadSeconds;
            // 距离粒子生命结束0秒
            effector3.EndTime = 0;
            effector3.EndTimeType = EnumEffectorTimeType.ToDeadSeconds;
            emitterSmoke.AddEffector(effector3);

            //火焰2发射器
            GSORingParticleEmitter emitterFire2 = new GSORingParticleEmitter();
            //添加火焰纹理
            emitterFire2.TexturePath = _fire2Path;

            emitterFire2.SetSizeFix(8, 8); //8,8
            emitterFire2.VelFix = 30;    //30

            // 重力加速度 -3.0
            emitterFire2.GravityAcc = -3.0f;

            emitterFire2.AngleXYFix = 0;
            emitterFire2.AngleXYRnd = 180;

            emitterFire2.AngleXZFix = 90;
            emitterFire2.AngleXZRnd = 5;

            emitterFire2.InnerRadius = 0;
            emitterFire2.OuterRadius = 30;

            emitterFire2.LifeFix = 2.0f;
            emitterFire2.LifeRnd = 0.5f;

            emitterFire2.RotFix = 0;
            emitterFire2.RotRnd = 30;

            emitterFire2.RotVelFix = 0;
            emitterFire2.RotVelRnd = 60;

            emitterFire2.EmitPerSec = 300;

            emitterFire2.ColorRndStart = Color.FromArgb(255, 255, (int)(0.38 * 255), 0);
            emitterFire2.ColorRndEnd = Color.FromArgb(255, 255, (int)(0.404 * 255), 0);

            GSOColorParticleEffector fire2ColoreEffector = new GSOColorParticleEffector();
            fire2ColoreEffector.SetColorChanged(-1, -1, -1, 0);
            // 距离粒子生命结束1秒
            fire2ColoreEffector.StartTime = 1;
            fire2ColoreEffector.StartTimeType = EnumEffectorTimeType.ToDeadSeconds;
            // 距离粒子生命结束0秒
            fire2ColoreEffector.EndTime = 0;
            fire2ColoreEffector.EndTimeType = EnumEffectorTimeType.ToDeadSeconds;
            emitterFire2.AddEffector(fire2ColoreEffector);

            //复制火焰2发射器为火焰1发射器
            GSORingParticleEmitter emitterFire1 = (GSORingParticleEmitter)emitterFire2.Clone();
            //修改纹理图片
            emitterFire1.TexturePath = _fire1Path;
            //修改重力加速度为 -2.0f
            emitterFire1.GravityAcc = -2.0f;

            //将三个发射器添加到粒子对象中
            geoParticle.AddEmitter(emitterSmoke);
            geoParticle.AddEmitter(emitterFire2);
            geoParticle.AddEmitter(emitterFire1);

            //播放动画效果
            geoParticle.Play();
            geoParticle.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            //创建要素对象
            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoParticle;

            _glbControl.Globe.MemoryLayer.AddFeature(feature);
            _glbControl.Globe.JumpToFeature(feature, 1000);
        }

        //喷泉
        private void btn_Spring_Click(object sender, EventArgs e)
        {
            if (_glbControl.Globe.Ocean.Visible)
                btn_Ocean.PerformClick();

            //喷泉粒子要素对象
            GSOGeoParticle geoParticle = new GSOGeoParticle();
            //添加到当前相机位置
            geoParticle.SetPosition(_glbControl.Globe.CameraState.Longitude,
                _glbControl.Globe.CameraState.Latitude, 0);

            GSOPointParticleEmitter emitter = new GSOPointParticleEmitter();
            //设置喷泉纹理
            emitter.TexturePath = _waterDropPath;
            //设置粒子大小
            emitter.SetSizeFix(0.5f, 2);
            emitter.VelFix = 10;
            emitter.VelRnd = 2;

            emitter.GravityAcc = 9.8f;
            emitter.AngleXYFix = 0;
            emitter.AngleXYRnd = 180;

            emitter.AngleXZFix = 88;
            emitter.AngleXZRnd = 2;

            emitter.LifeFix = 5.0f;
            emitter.LifeRnd = 1.0f;

            emitter.RotFix = 0;
            emitter.RotRnd = 0;

            emitter.RotVelFix = 0;
            emitter.RotVelRnd = 0;

            //每秒钟1000个粒子
            emitter.EmitPerSec = 1000;
            //白色，33不透明度
            emitter.ColorRndStart = Color.FromArgb(33, 255, 255, 255);
            //白色，11不透明度
            emitter.ColorRndEnd = Color.FromArgb(11, 255, 255, 255);
            emitter.IsLumAdded = false;

            //将发射器添加到粒子对象中
            geoParticle.AddEmitter(emitter);
            geoParticle.Play();
            geoParticle.AltitudeMode = EnumAltitudeMode.Absolute;
            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoParticle;
            _glbControl.Globe.MemoryLayer.AddFeature(feature);
            _glbControl.Globe.JumpToFeature(feature, 100);
        }

        //飞机动画
        private void btn_PlanMove_Click(object sender, EventArgs e)
        {
            //创建相机状态
            GSOCameraState camera = new GSOCameraState();
            camera.Longitude = 100.42875293029;
            camera.Latitude = 38.9355930610869;
            camera.Distance = 12209.9485092387;
            camera.Heading = -92.7905229605158;
            camera.Tilt = 68.5957814133134;
            camera.Altitude = 1490.27994062379;
            camera.AltitudeMode = EnumAltitudeMode.Absolute;
            //视角变为该相机状态
            _glbControl.Globe.JumpToCameraState(camera);

            //添加.lgd图层
            GSOLayer layer = _glbControl.Globe.Layers.Add(_planAnimatePath);
            if (layer != null)
            {
                //添加.gla动画文件
                GSOAnimationPage page = _glbControl.Globe.AnimationPages.AddAnimationPage(_planAnimatePath.Replace(".lgd", ".gla"));
                if (page != null)
                {
                    page.RepeatCount = 1000;
                    page.Play();
                }
            }
        }

        //导弹动画
        private void btn_Missile_Click(object sender, EventArgs e)
        {
            //创建相机状态
            GSOCameraState camera = new GSOCameraState();
            camera.Longitude = 100.42875293029;
            camera.Latitude = 38.9355930610869;
            camera.Distance = 12209.9485092387;
            camera.Heading = -92.7905229605158;
            camera.Tilt = 68.5957814133134;
            camera.Altitude = 1490.27994062379;
            camera.AltitudeMode = EnumAltitudeMode.Absolute;
            //添加.lgd图层
            _glbControl.Globe.JumpToCameraState(camera);

            //添加.lgd图层
            GSOLayer layer = _glbControl.Globe.Layers.Add(_missileAnimatePath);
            if (layer != null)
            {
                //添加.gla动画文件
                GSOAnimationPage page = _glbControl.Globe.AnimationPages.AddAnimationPage(_missileAnimatePath.Replace(".lgd", ".gla"));
                if (page != null)
                {
                    page.RepeatCount = 1;
                    page.Play();
                }
            }
        }

        //船尾迹
        private void btn_BoatTail_Click(object sender, EventArgs e)
        {
            if (!_glbControl.Globe.Ocean.Visible)
                btn_Ocean.PerformClick();

            if (_glbControl.Globe.MemoryLayer.GetFeatureByName(_tailName, true).Length > 0)
            {
                return;
            }

            //重要：海面效果打开
            _glbControl.Globe.Ocean.Visible = true;
            //创建运动物体
            GSOGeoBoxEntity box = new GSOGeoBoxEntity();
            box.Height = 30;
            box.Width = 3;
            box.Length = 10;
            box.Position = new GSOPoint3d(0, 0, 15);

            //创建要素
            GSOFeature feature = new GSOFeature();
            feature.Geometry = box;
            feature.Name = _tailName;

            _glbControl.Globe.MemoryLayer.AddFeature(feature);

            //尾迹位置
            GSOPoint3d pntWave = new GSOPoint3d(0, 0, 0);

            //添加船尾迹效果
            _glbControl.Globe.Ocean.AddShipWake(_tailName, pntWave, false, -130.0, 200.0, 45.0, 200.0);

            _glbControl.Globe.JumpToPosition(box.Position, EnumAltitudeMode.RelativeToGround, 400);
            timer_tail.Start();
        }

        //根据timer更新船尾迹
        private void UpdateShipWake()
        {
            GSOFeatures resFeatures = _glbControl.Globe.MemoryLayer.GetFeatureByName(_tailName, true);
            if (resFeatures.Length < 1)
            {
                return;
            }
            //获得与船尾迹绑定的要素
            GSOFeature shipFeature = resFeatures[0];
            if (shipFeature != null && shipFeature.Visible)
            {
                //获取绑定的物体
                GSOGeoBoxEntity geoModel = shipFeature.Geometry as GSOGeoBoxEntity;
                //更新物体 位置
                geoModel.PositionX = geoModel.PositionX - 0.00001;
                //获得物体位置
                GSOPoint3d pntWave = geoModel.Position;
                //更新船尾迹
                _glbControl.Globe.Ocean.UpdateShipWake(_tailName, pntWave);
            }
        }

        //直升机涡轮
        private void btn_HelicopterFly_Click(object sender, EventArgs e)
        {
            if (!_glbControl.Globe.Ocean.Visible)
                btn_Ocean.PerformClick();

            if (_glbControl.Globe.MemoryLayer.GetFeatureByName(_RotorWashName, true).Length > 0)
            {
                return;
            }

            //重要：海面效果打开
            _glbControl.Globe.Ocean.Visible = true;

            //创建涡轮物体
            GSOGeoSphereEntity ball = new GSOGeoSphereEntity();
            ball.Radius = 10;
            ball.Position = new GSOPoint3d(0, 0, 30);
            ball.Name = _RotorWashName;
            ball.AltitudeMode = EnumAltitudeMode.RelativeToGround;

            //创建要素
            GSOFeature feature = new GSOFeature();
            feature.Geometry = ball;
            feature.Name = _RotorWashName;

            //添加要素
            _glbControl.Globe.MemoryLayer.AddFeature(feature);
            //涡轮位置
            GSOPoint3d pntWave = new GSOPoint3d(0, 0, 15);
            //添加涡轮效果
            _glbControl.Globe.Ocean.AddRotorWash(_RotorWashName, pntWave, 100, 50);
            _glbControl.Globe.JumpToPosition(ball.Position, EnumAltitudeMode.RelativeToGround, 400);
            //计时器开始计时
            timer_Rotor.Start();
        }

        //根据timer更新涡轮
        private void UpdateRotorWash()
        {
            GSOFeatures resFeatures = _glbControl.Globe.MemoryLayer.GetFeatureByName(_RotorWashName, true);
            if (resFeatures.Length < 1)
            {
                return;
            }
            //获得与涡轮绑定的要素
            GSOFeature shipFeature = resFeatures[0];
            if (shipFeature != null && shipFeature.Visible)
            {
                GSOGeoSphereEntity geoModel = shipFeature.Geometry as GSOGeoSphereEntity;
                geoModel.PositionX = geoModel.PositionX - 0.000003;
                //获得物体位置
                GSOPoint3d pntWave = geoModel.Position;
                //更新涡轮
                _glbControl.Globe.Ocean.UpdateRotorWash(_RotorWashName, pntWave, 100);
            }
        }
         
        #region 视频投射

        MovieInfo movieInfo;

        //视频投射
        private void btn_VedioProjection_Click(object sender, EventArgs e)
        {
            ConnectServer();
            //绑定计时器事件
            timerPlayVideo.Tick += this.timerPlayVideo_Tick;
            //打开视频文件
            OpenFileDialog file = new OpenFileDialog()
            {
                Filter = "*.avi;*.mp4|*.avi;*.mp4",
                Multiselect = false
            };

            if (file.ShowDialog() != DialogResult.OK)
                return;

            //新建VideoCapture
            _videoCapture = new VideoCapture(file.FileName);

            //新建视频投射GSOVideoCamera
            _gsoVideoCamera = new GSOVideoCamera(_glbControl.Globe);

            //获得当前相机位置
            GSOPoint3d pos = _glbControl.Globe.CameraLookAt.Position;

            //视频水平视角
            _gsoVideoCamera.HorizontalFov = 120;
            //视频垂直视角
            _gsoVideoCamera.VerticalFov = 90;
            //根据当前相机位置设置视频投射点位置，高度为200米
            _gsoVideoCamera.Position = new GSOPoint3d(_glbControl.Globe.CameraState.Longitude, _glbControl.Globe.CameraState.Latitude, 200);

            //设置投射点(决定投射方向，本例设置为垂直向下投射)
            _gsoVideoCamera.SetDirectionByPoint(new GSOPoint3d(_glbControl.Globe.CameraState.Longitude, _glbControl.Globe.CameraState.Latitude, 0));
            //设置投射距离
            _gsoVideoCamera.Distance = _glbControl.Globe.CameraState.Distance;
            //设置投射图像格式
            _gsoVideoCamera.SetImageData(null, 0, 0, EnumTexturePixelFormat.TYPE_B8G8R8);
            //将创建的投射点应用到Globe中
            _gsoVideoCamera.Apply();
            //刷新球
            _glbControl.Globe.Refresh();

            //通过OPENCV获得视频的元数据信息
            movieInfo = new MovieInfo(_videoCapture);
            //计算计时器间隔时间
            timerPlayVideo.Interval = Convert.ToInt32(System.Math.Round(1.0 / movieInfo.fps, 2) * 100);
            //设置计时器为可用
            timerPlayVideo.Enabled = true;
        }

        //结束播放
        public void StopVideo()
        {
            //停止视频播放
            timerPlayVideo.Enabled = false;
            _gsoVideoCamera.Clear();
            _videoCapture = null;
        }

        //计时器
        private void timerPlayVideo_Tick(object sender, EventArgs e)
        {
            //根据计时器增加索引值
            movieInfo.currentFrame++;
            //如果当前帧索引超过了总帧数，则停止播放视频
            if (movieInfo.currentFrame >= movieInfo.frameCount)
            {
                timerPlayVideo.Stop();
                MessageBox.Show("视频播放完毕！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StopVideo();
                return;
            }
            //设置当前帧索引
            _videoCapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, movieInfo.currentFrame);
            //获取当前帧
            var frame = _videoCapture.QueryFrame();
            //取出当前帧
            Bitmap bm = frame.Bitmap;
            //新建流
            MemoryStream ms = new MemoryStream();
            //读取流
            bm.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();
            int dH = bm.Height;
            int dW = bm.Width;
            //读取流
            ms.Close();

            //设置视频投射点当前播放的图像
            _gsoVideoCamera.SetImageData(bytes, dW, dH, EnumTexturePixelFormat.TYPE_B8G8R8);
        }

        /// <summary>
        /// 结构体，描述视频内容的元数据
        /// </summary>
        struct MovieInfo  
        {
            //总帧数
            public int frameCount;
            //宽度
            public int width;
            //高度
            public int height;
            //当前帧索引
            public int currentFrame;
            //码率
            public int fps;

            public MovieInfo(VideoCapture vCapture)
            {
                //获取总帧数
                frameCount = Convert.ToInt32(vCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount));
                //获取视频宽度
                width = Convert.ToInt32(vCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth));
                //获取视频高度
                height = Convert.ToInt32(vCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight));
                //获取当前帧索引
                currentFrame = Convert.ToInt32(vCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames));
                //获取码率
                fps = Convert.ToInt32(vCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
            }
        }

        //连接服务器
        private void ConnectServer()
        {
            //ip地址
            string ip = "data1.locaspace.cn";
            //端口
            int port = 1500;
            //用户名
            string userName = "admin";
            //密码
            string psw = "admin";
            //避免多次加载，影响分析结果
            if (this._glbControl.Globe.Layers.Count > 0)
            {
                InitiLayer();
            }
            //连接服务器
            this._glbControl.Globe.ConnectServer(ip, port, userName, psw);
        }

        //获得倾斜摄影图层
        private void InitiLayer()
        {
            if (lfpLayer != null)
            {
                FlyToLayer(lfpLayer);
                return;
            }
            for (int i = 0; i < this._glbControl.Globe.Layers.Count; i++)
            {
                //获取文件扩展名为.lfp的第一个倾斜摄影图层
                if (this._glbControl.Globe.Layers[i].Name.Contains(".lfp"))
                {
                    lfpLayer = this._glbControl.Globe.Layers[i];
                    break;
                }
            }
            FlyToLayer(lfpLayer);
            return;
        }

        //定位到倾斜摄影图层
        private void FlyToLayer(GSOLayer layer)
        {
            if (layer == null
                || layer.LatLonBounds == null
                || layer.LatLonBounds.Width == 0.0
                || layer.LatLonBounds.Height == 0.0)
                return;
            //获取图层中心点
            GSOPoint3d pntPostion = new GSOPoint3d();
            pntPostion.X = layer.LatLonBounds.Center.X;
            pntPostion.Y = layer.LatLonBounds.Center.Y;
            //获取图层最大边
            double dMaxGeoLen = Math.Max(layer.LatLonBounds.Width, layer.LatLonBounds.Height);
            //判断视角高度
            double dSize = dMaxGeoLen * Math.PI * 6378137 / 90;
            pntPostion.Z = dSize > 20000000 ? dSize / 4 : dSize;
            _glbControl.Globe.JumpToPosition(pntPostion, EnumAltitudeMode.RelativeToGround, 1000);
        }
        #endregion

        //相机动画
        private void btn_CameraMovie_Click(object sender, EventArgs e)
        {
            FrmCameraMovie frm = new FrmCameraMovie(_glbControl);
            frm.Show(this);
        }

        private void FrmSpecialEffects_Load(object sender, EventArgs e)
        {
            //关闭经纬网
            _glbControl.Globe.LatLonGrid.Visible = false;
            ConnectServer();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateShipWake();
            UpdateRotorWash();
        }
    }
}
