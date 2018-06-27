using GeoScene.Data;
using GeoScene.Globe;
using System;
using System.Windows.Forms;

namespace Sunlight
{
    public partial class FrmSunlight : Form
    {
        private GSOGlobeControl _glbControl;
        private GSOLayer _modelLayer;
        DateTime datetime = System.DateTime.Now;

        public FrmSunlight()
        {
            InitializeComponent();
            //初始化球控件
            _glbControl = new GSOGlobeControl();
            _glbControl.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(_glbControl);
        }

        //光照打开/关闭
        private void btn_sunLight_Click(object sender, EventArgs e)
        {
            if (_glbControl.Globe.Sun.Visible)
            {
                this.btn_sunLight.Text = "打开日照";
                //设置日照不可见
                _glbControl.Globe.Sun.Visible = false;
                //关闭阴影效果
                _glbControl.Globe.ShadowVisible = false;
                _glbControl.Refresh();
            }
            else
            {
                datetime = System.DateTime.Now;
                this.btn_sunLight.Text = "关闭日照";
                //设置日照可见
                _glbControl.Globe.Sun.Visible = true;
                //设置为当前实时时间
                _glbControl.Globe.Sun.IsRealTimePos = true;
                //重要:要打开阴影效果才能看到光照的阴影
                _glbControl.Globe.ShadowVisible = true;
                //刷新球
                _glbControl.Refresh();
            }
        }

        //修改光照时间
        private void btn_Time_Click(object sender, EventArgs e)
        {
            if (!_glbControl.Globe.Sun.Visible)
                btn_sunLight.PerformClick();

            //时间增加一小时
            datetime = datetime.AddHours(1);
            //关闭太阳实时位置
            _glbControl.Globe.Sun.IsRealTimePos = false;
            //重要:设置其他时间的光照效果一定要将实时位置关闭，并调用此接口(分别设置年、月、日...)
            _glbControl.Globe.Sun.SetPositionByTime(datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second);
            _glbControl.Globe.Refresh();
        }

        //设置实时位置
        private void btn_RealtimePos_Click(object sender, EventArgs e)
        {
            if (!_glbControl.Globe.Sun.Visible)
                btn_sunLight.PerformClick();
            //设置太阳位置为当前位置
            _glbControl.Globe.Sun.IsRealTimePos = true;
        }

        private void FrmSunlight_Load(object sender, EventArgs e)
        {
            //初始化球设置
            _glbControl.Globe.LatLonGrid.Visible = false;
            _glbControl.Globe.ControlPanel.Visible = false;
            btn_ConnectServer.PerformClick();
        }

        //连接服务器获取模型图层
        private void btn_ConnectServer_Click(object sender, EventArgs e)
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
                return;
            }
            //连接服务器
            this._glbControl.Globe.ConnectServer(ip, port, userName, psw);
            _glbControl.Refresh();
        }

        //初始化图层
        private void InitiLayer()
        {
            if (_modelLayer != null)
            {
                FlyToLayer(_modelLayer);
                return;
            }
            for (int i = 0; i < this._glbControl.Globe.Layers.Count; i++)
            {
                //获取文件三维模型
                if (this._glbControl.Globe.Layers[i].Name.Contains("三维"))
                {
                    _modelLayer = this._glbControl.Globe.Layers[i];
                    break;
                }
            }
            FlyToLayer(_modelLayer);
            return;
        }

        //视角移动至图层
        private void FlyToLayer(GSOLayer layer)
        {
            if (layer == null
                || layer.LatLonBounds == null)
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
            _glbControl.Globe.JumpToPosition(pntPostion, EnumAltitudeMode.RelativeToGround, 5000);
        }
    }
}
