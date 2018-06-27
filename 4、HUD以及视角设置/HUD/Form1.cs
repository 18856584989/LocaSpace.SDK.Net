using System.Collections.Generic;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace HUD
{
    public partial class Form1 : Form
    {
        GSOGlobeControl globeControl1;
        //建立字典，把按钮跟事件对应
        Dictionary<string, GSOHudButtonInfo> listQuickToolBar;
        //判断鼠标是否接触按钮
        bool isMouseInHudControl = false;
        GSOHudPanel panel = new GSOHudPanel();//创建GSOHudPanel对象

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            this.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            //HUDToolBar示例
            HUDToolBar();

            //GSOHUDButton示例
            GSOHUDBUTTON();

            //GSOHUDPanel示例
            GSOHUDPANEL();

            //GSOHUDSlider示例
            GSOHUDSLIDER();
        }

        #region HUD实际使用示例

        /// <summary>
        /// 配置HUD
        /// </summary>
        private void HUDToolBar()
        {
            //配置按钮属性
            GSOHudButtonInfo navigate = new GSOHudButtonInfo(
                "navigate",                     //按钮名称
                EnumAction3D.ActionNull,        //按钮事件
                "/Resource/image/hand32.png",   //按钮小图标
                "/Resource/image/hand36.png",   //按钮大图标
                -180, 30,                       //按钮左上角的坐标
                "浏览对象");                    //按钮文字
            GSOHudButtonInfo select = new GSOHudButtonInfo(
                "select",
                EnumAction3D.SelectObject,
                "/Resource/image/select32.png",
                "/Resource/image/select36.png",
                -140, 30,
                "选中对象");
            GSOHudButtonInfo line = new GSOHudButtonInfo(
                "line",
                EnumAction3D.DrawPolyline,
                "/Resource/image/Polyline32.png",
                "/Resource/image/Polyline36.png",
                -100, 30,
                "绘制线");
            GSOHudButtonInfo polygon = new GSOHudButtonInfo(
                "polygon",
                EnumAction3D.DrawPolygon,
                "/Resource/image/Polygon32.png",
                "/Resource/image/Polygon36.png",
                -60, 30,
                "绘制面");
            GSOHudButtonInfo showFrom = new GSOHudButtonInfo(
                "showFrom",
                EnumAction3D.ActionNull,
                "/Resource/image/Model32.png",
                "/Resource/image/Model36.png",
                180, 30,
                "显示窗口");
            //Hud背景
            GSOHudButtonInfo toolBar = new GSOHudButtonInfo(
                "toolbar",
                EnumAction3D.ActionNull,
                "/Resource/image/ToolBar.png",
                "/Resource/image/ToolBar.png",
                -195, 25,
                "");
            //添加进HudControl中
            globeControl1.Globe.AddHudControl(navigate);
            globeControl1.Globe.AddHudControl(select);
            globeControl1.Globe.AddHudControl(line);
            globeControl1.Globe.AddHudControl(polygon);
            globeControl1.Globe.AddHudControl(showFrom);
            globeControl1.Globe.AddHudControl(toolBar);
            //添加进字典中
            listQuickToolBar = new Dictionary<string, GSOHudButtonInfo>();
            listQuickToolBar.Add(navigate.Name, navigate);
            listQuickToolBar.Add(select.Name, select);
            listQuickToolBar.Add(line.Name, line);
            listQuickToolBar.Add(polygon.Name, polygon);
            listQuickToolBar.Add(showFrom.Name, showFrom);
            listQuickToolBar.Add(toolBar.Name, toolBar);

            //鼠标按下事件
            globeControl1.HudControlMouseDownEvent += (sender, e) =>
            {
                if (e.HudControl != null)   //如果按钮不为空
                {
                    GSOHudButton button = e.HudControl as GSOHudButton;
                    if (button == null)
                    {
                        return;
                    }
                    //在字典中找到按钮
                    if (listQuickToolBar.ContainsKey(button.Name) == true)
                    {
                        GSOHudButtonInfo buttonInfo = listQuickToolBar[button.Name];
                        if (buttonInfo != null)
                        {
                            //把字典中的动作赋给球
                            globeControl1.Globe.Action = buttonInfo.action;
                            //判断名称，显示窗口
                            if (buttonInfo.Name == "showFrom")
                            {
                                MessageBox.Show("显示窗口");
                            }
                        }
                    }
                }
            };

            //鼠标移入事件
            globeControl1.HudControlMouseIntoEvent += (sender, e) =>
            {
                if (e.HudControl != null)
                {
                    isMouseInHudControl = true;
                    //先恢复默认
                    setButtonTextAndImageEmpty();
                    GSOHudButton button = e.HudControl as GSOHudButton;
                    if (button == null)
                    {
                        return;
                    }
                    if (listQuickToolBar.ContainsKey(button.Name) == true)
                    {
                        GSOHudButtonInfo buttonInfo = listQuickToolBar[button.Name];
                        if (buttonInfo == null)
                        {
                            return;
                        }
                        //改变鼠标滑过的按钮图标和文字
                        button.SetImage(Application.StartupPath + buttonInfo.bigImagePath);
                        button.Text = " " + buttonInfo.toolTip;
                    }
                }
            };

            //鼠标移出事件
            globeControl1.HudControlMouseOutEvent += (sender, e) =>
            {
                if (e.HudControl != null)
                {
                    isMouseInHudControl = false;
                    GSOHudButton button = e.HudControl as GSOHudButton;
                    if (button == null)
                    {
                        return;
                    }
                    //恢复原样
                    setButtonTextAndImageEmpty();
                }
            };
        }

        /// <summary>
        /// 当鼠标移出，缩小图标并隐藏文字，恢复原状
        /// </summary>
        private void setButtonTextAndImageEmpty()
        {
            if (listQuickToolBar != null)
            {
                foreach (string key in listQuickToolBar.Keys)
                {
                    GSOHudButtonInfo button = listQuickToolBar[key];
                    if (button != null)
                    {
                        button.SetImage(Application.StartupPath + button.imagePath);
                        button.Text = "";
                    }
                }
            }
        }

        #endregion

        #region GSOHUDButton示例

        /// <summary>
        ///HUDButton示例 
        /// </summary>
        private void GSOHUDBUTTON()
        {
            GSOHudButton btn = new GSOHudButton();//创建GSOHudButton对象
            btn.SetImage(Application.StartupPath + "/Resource/image/t1.png");//设置图片路径，图片格式可以是png，jpg或ico。
            btn.Align = EnumAlign.BottomRight;
            //设置图片对齐方式为右下角对齐，EnumAlign成员分别有BottomCenter,BottomLeft,BottomRight,MiddleCenter,MiddleLeft,MiddleRight,TopCenter,TopLeft,TopRight。
            btn.SetOffset(0, 20);//设置图片相对于场景右下角的距离。
            btn.MinOpaque = 1;//通过MaxOpaque、MinOpaque这两个属性设置GSOHudButton对象的透明度，其值为0-1。
            btn.MaxOpaque = 1;
            btn.Height = 200;//设置btn高度
            btn.Width = 115;//设置宽度
            btn.HeightFixed = true; //设置GSOHudButton对象的图片高度与该对象的高度相同           
            btn.WidthFixed = true; //设置GSOHudButton对象的图片宽度与该对象的宽度相同    
            globeControl1.Globe.AddHudControl(btn);//将GSOHudButton对象添加到场景中
        }

        #endregion

        #region GSOHUDPanel示例

        /// <summary>
        /// GSOHUDPanel示例
        /// </summary>
        private void GSOHUDPANEL()
        {
            
            panel.CloseButtonVisible = true;//设置panel的关闭按钮可见
            panel.FadeOut = true;//设置panel的淡出效果
            panel.MaxOpaque = 1;
            panel.MinOpaque = 1;
            panel.Height = 187;//设置panel的高度
            panel.Width = 115;//设置panel的宽度
            panel.Align = EnumAlign.BottomLeft;//设置panel对齐方式为右下角对齐
            panel.SetOffset(0, 15);//设置panel相对于场景右下角的距离
            globeControl1.Globe.AddHudControl(panel);//在场景中添加panel
        }

        #endregion

        #region GSOHUDSlider示例

        /// <summary>
        /// GSOHUDSlider示例
        /// </summary>
        private void GSOHUDSLIDER()
        {
            GSOHudSliderBar bar = new GSOHudSliderBar();
            bar.BarLength = 200;//设置bar的长度
            bar.BarLengthFixed = true;//设置bar的长度是否固定
            bar.FadeOut = false;//设置bar淡出效果
            bar.MaxOpaque = 1;
            bar.MinOpaque = 1;
            bar.SliderValue = 1;//设置bar的值,范围0-1
            bar.Align = EnumAlign.BottomRight;//设置bar的对齐方式
            bar.SetOffset(0, 0); //设置bar相对于场景右下角的距离   
            globeControl1.Globe.AddHudControl(bar);//在场景中添加bar
        }

        #endregion
    }
}
