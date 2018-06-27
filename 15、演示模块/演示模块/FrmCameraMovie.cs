using GeoScene.Globe;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LSVSpecialEffects
{
    public partial class FrmCameraMovie : Form
    {
        private GSOGlobeControl _glbControl;
        //动画页
        private GSOAnimationPage _cameraMoviePage;
        //相机状态列表
        private List<CameraFrame> _listFrame = new List<CameraFrame>();

        public FrmCameraMovie(GSOGlobeControl glbControl)
        {
            InitializeComponent();
            _glbControl = glbControl;
        }

        //拾取当前相机状态
        private void btn_PickCameraState_Click(object sender, EventArgs e)
        {
            //如果构建过相机页，则新添加时将其清空
            if (_cameraMoviePage != null)
            {
                _listFrame.Clear();
                lbc_FrameCount.Text = string.Format("相机状态数：0");
                _cameraMoviePage = null;
            }

            //拾取当前相机状态信息
            CameraFrame frame = new CameraFrame()
            {
                //获取当前相机状态
                CameraState = _glbControl.Globe.CameraState,
                //当前状态到下一状态的持续的时间
                Duration = Convert.ToDouble(numericUpDown_ConsistTime.Value),
                //相机状态命名
                FrameName = string.Format("相机状态{0}", _listFrame.Count)
            };
            //将当前相机状态信息添加到相机状态列表
            _listFrame.Add(frame);
            //显示统计信息
            lbc_FrameCount.Text = string.Format("相机状态数：{0}", _listFrame.Count);
        }

        //生成动画页预览并
        private void btn_Preview_Click(object sender, EventArgs e)
        {
            //动画创建条件为有两个以上的相机状态
            if (_listFrame.Count < 2)
            {
                MessageBox.Show("不满足动画创建条件，请继续拾取。");
                return;
            }

            //创建动画相机
            GSOAniCamera aniCamera = new GSOAniCamera();
            //创建动画时间线
            GSOAniObjTimeLine timeline = new GSOAniObjTimeLine();
            //将动画相机与动画时间线绑定
            timeline.AniObject = aniCamera;

            //创建动画页面
            _cameraMoviePage = new GSOAnimationPage();
            _cameraMoviePage.Name = "Test1";
            //设置每秒帧数为60帧
            _cameraMoviePage.FPS = 60;

            //初始化动画持续帧数
            int totleFrameCount = 0;

            //遍历关键帧列表
            for (int i = 0; i < _listFrame.Count; i++)
            {
                //创建关键帧之间的变化效果
                GSOAniEffectCameraStateChange effectChange = new GSOAniEffectCameraStateChange();
                //变化起始状态
                CameraFrame starFrame = _listFrame[i];
                effectChange.StartState = starFrame.CameraState;

                //变化结束状态
                CameraFrame endFrame = i == _listFrame.Count - 1 ? _listFrame[i] : _listFrame[i + 1];
                effectChange.EndState = endFrame.CameraState;

                //计算相机状态之间的持续帧数
                effectChange.FrameCount = (int)(starFrame.Duration * _cameraMoviePage.FPS);
                //重复播放次数为1次
                effectChange.RepeatCount = 1;
                //使用缩放高度设置为false
                effectChange.ZoomOutAltUsed = false;

                totleFrameCount += effectChange.FrameCount;
                //创建动画关键帧
                GSOAniKeyFrame keyFrame = new GSOAniKeyFrame();
                //添加状态变化效果
                keyFrame.AddEffect(effectChange);
                //添加帧数
                keyFrame.Frame = totleFrameCount;
                //将关键帧添加到动画时间线
                timeline.AddKeyFrame(keyFrame);
            }

            //向动画页添加总帧数
            _cameraMoviePage.FrameCount = totleFrameCount;
            //向动画页添加动画时间线
            _cameraMoviePage.AddObjTimeLine(timeline);
            //清空其他动画
            if (_glbControl.Globe.AnimationPages.Length > 0)
                _glbControl.Globe.AnimationPages.RemoveAll();
            //向Globe中添加该动画页
            _cameraMoviePage = _glbControl.Globe.AnimationPages.Add(_cameraMoviePage);
            //播放动画页
            _cameraMoviePage.Play();
        }

        //取消
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //创建动画文件
        private void btn_CreateFile_Click(object sender, EventArgs e)
        {
            //判断动画页是否为空
            if (_cameraMoviePage == null)
            {
                MessageBox.Show("请先拾取相机状态并预览相机节点。");
                return;
            }
            //保存窗口
            SaveFileDialog dlg = new SaveFileDialog();
            //保存格式为.gla
            dlg.Filter = "*.gla | .gla";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //将动画保存为文件
                _cameraMoviePage.SaveAs(dlg.FileName);
                MessageBox.Show("保存成功。");
            }
        }
    }

    //每帧相机动画信息
    public class CameraFrame
    {
        private string _frameName;
        private GSOCameraState _cameraState;
        private double _duration;

        /// <summary>
        /// 相机状态
        /// </summary>
        public GSOCameraState CameraState { get => _cameraState; set => _cameraState = value; }

        /// <summary>
        /// 持续时间
        /// </summary>
        public double Duration { get => _duration; set => _duration = value; }

        /// <summary>
        /// 画帧名称
        /// </summary>
        public string FrameName { get => _frameName; set => _frameName = value; }
    }
}
