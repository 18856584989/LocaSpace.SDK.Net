using GeoScene.Data;
using GeoScene.Globe;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LayerOperate
{
    public partial class FrmLayerMove : Form
    {
        private GSOGlobeControl _glbControl;
        private GSOFeature _startFeat;
        private GSOFeature _endFeat;
        private Point _locationPoint;
        private GSOLayer _layer;
        private TextBox _actX;
        private TextBox _actY;
        private bool _isBegin = true;

        private string _pointImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource/CrossIcon.png");
        private bool _IsPickPoint = false;

        public FrmLayerMove(GSOGlobeControl glbControl, GSOLayer layer)
        {
            InitializeComponent();
            _layer = layer;
            _glbControl = glbControl;
        }

        /// <summary>
        /// "取点"按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PickBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn.Tag == null)
                return;
            _IsPickPoint = !_IsPickPoint;

            //通过按钮的Tag判断是取起点坐标，还是终点坐标
            if ("Begin".Equals(btn.Tag.ToString()))
            {
                _isBegin = true;
                groupBoxBengin.ForeColor = System.Drawing.Color.Orange;
                groupBoxEnd.ForeColor = System.Drawing.Color.Black;
                PickPointFromGlob(this.textBox_BeginX, this.textBox_BeginY, groupBoxBengin);
            }
            else if ("End".Equals(btn.Tag.ToString()))
            {
                _isBegin = false;
                groupBoxEnd.ForeColor = System.Drawing.Color.Orange;
                groupBoxBengin.ForeColor = System.Drawing.Color.Black;
                PickPointFromGlob(this.textBox_EndX, this.textBox_EndY, groupBoxEnd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textBoxX">激活的X坐标窗口</param>
        /// <param name="textBoxY">激活的Y坐标窗口</param>
        /// <param name="groupBox"></param>
        private void PickPointFromGlob(TextBox textBoxX, TextBox textBoxY, GroupBox groupBox)
        {
            _actX = textBoxX;
            _actY = textBoxY;
            SetGlobState();
        }

        //点击状态设置
        void SetGlobState()
        {
            _glbControl.MouseUp += this.ctl_MouseUp;
            _glbControl.MouseDown += this.ctl_MouseDown;
            this.Opacity = 0.5;
        }

        //取消点击状态设置
        void BackGlobState()
        {
            _glbControl.MouseUp -= this.ctl_MouseUp;
            _glbControl.MouseDown -= this.ctl_MouseDown;
            this.Opacity = 1;
        }

        //鼠标MouseDown事件，获取当前坐标，与MouseUp对比的坐标对比排除移动球操作
        void ctl_MouseDown(object sender, MouseEventArgs e)
        {
            _locationPoint = e.Location;
        }

        void ctl_MouseUp(object sender, MouseEventArgs e)
        {
            //判断鼠标为左键点击，并排除用左键移动球体的动作(通过MouseDown时与MouseUp时鼠标屏幕坐标比较)
            if (e.Button == MouseButtons.Left && e.Location == _locationPoint)
            {
                GSOLayer layer;
                GSOPoint3d point;
                //获取三维空间鼠标点击事件的空间点坐标
                _glbControl.Globe.HitTest(e.X, e.Y, out layer, out point, false, false, 0);

                //有可能并没有点击到图层上，因此需要将点击的屏幕坐标转换成球面坐标
                if (point.X == 0.0 || point.Y == 0.0)
                {
                    point = this._glbControl.Globe.ScreenToScene(e.X, e.Y);
                }
                if (point.Z < 0)
                {
                    point.Z = 0;
                }
                //todo:还需要对获取的坐标值的范围进行判断(由于视角的原因，获取到的坐标有可能非法)
                //给当前激活textBox赋值
                _actX.Text = point.X.ToString();
                _actY.Text = point.Y.ToString();

                //新建Feature
                var featurePoint = new GSOFeature();
                GSOMarkerStyle3D style = new GSOMarkerStyle3D();
                GSOGeoMarker p = new GSOGeoMarker();
                style.IconPath = _pointImagePath;
                p.Style = style;
                p.AltitudeMode = EnumAltitudeMode.Absolute;
                p.X = point.X;
                p.Y = point.Y;
                p.Z = point.Z;

                if (_isBegin)
                {
                    _startFeat = featurePoint;
                    p.Text = "起点";
                    _startFeat.Name = "起点";
                    _startFeat.Geometry = p;
                }
                else
                {
                    _endFeat = featurePoint;
                    p.Text = "终点";
                    _endFeat.Name = "终点";
                    _endFeat.Geometry = p;
                }
                var features = _glbControl.Globe.MemoryLayer.GetFeatureByName(featurePoint.Name, true);
                if (features != null && features.Length > 0)
                {
                    for (int i = 0; i < features.Length; i++)
                    {
                        _glbControl.Globe.MemoryLayer.RemoveFeatureByID(features[i].ID);
                    }
                }
                _glbControl.Globe.MemoryLayer.AddFeature(featurePoint);
                _glbControl.Refresh();
                BackGlobState();
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            bool notFit = false;
            if (this.textBox_BeginX.Text.Trim().Equals(string.Empty)
               || this.textBox_BeginY.Text.Trim().Equals(string.Empty))
            {
                errorProvider1.SetError(groupBoxBengin, "请获取起点坐标。");
                notFit = true;
            }
            if (this.textBox_EndX.Text.Trim().Equals(string.Empty)
               || this.textBox_EndY.Text.Trim().Equals(string.Empty))
            {
                errorProvider1.SetError(groupBoxEnd, "请获取目标点坐标。");
                notFit = false;
            }
            if (notFit)
                return;

            //计算X轴位移坐标
            double daltX = double.Parse(this.textBox_EndX.Text.Trim()) - double.Parse(this.textBox_BeginX.Text.Trim());
            //计算Y轴位移坐标
            double daltY = double.Parse(this.textBox_EndY.Text.Trim()) - double.Parse(this.textBox_BeginY.Text.Trim());

            //获取所有的要素
            GSOFeatures features = _layer.GetAllFeatures();
            for (int i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];
                //遍历要素，将Geometry平移(daltX, daltY)坐标
                if (feature.Geometry != null)
                    feature.Geometry.MoveXY(daltX, daltY);
            }
            _layer.Save();
            _glbControl.Refresh();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLayerMove_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭窗口时清除标注
            _glbControl.Globe.MemoryLayer.RemoveAllFeature();
        }
    }
}
