using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 界面文字
{
    public partial class Form1 : Form
    {
        private GSOGlobeControl globeControl1;

        #region 文字图层初始化

        //文字图层地址
        string ScreenTextLayerPath = Application.StartupPath + "/Resource/layers/ScreenText.lgd";
        //文字图层
        GSOLayer layerScreenText = null;

        #endregion

        #region 跟随鼠标文字初始化

        private GSOGeoScreenText overlayText = null;
        private GSOFeature feature_ScreenText = null;

        #endregion

        public Form1()
        {
            InitializeComponent();

            globeControl1 = new GSOGlobeControl();
            panel1.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 初始化文字图层

            //如果没有文件，就将内存图层复制一份
            if (File.Exists(ScreenTextLayerPath) == false)
            {
                globeControl1.Globe.MemoryLayer.SaveAs(ScreenTextLayerPath);
            }
            layerScreenText = globeControl1.Globe.Layers.Add(ScreenTextLayerPath);

            #endregion

            //文字图层
            TextTitle("文字图层");

            //跟随鼠标文字图层
            globeControl1.MouseMove += new MouseEventHandler(globeControl1_MouseMove);
            SetScreenText("跟随鼠标文字");
        }

        #region 文字图层

        /// <summary>
        /// 文字图层
        /// </summary>
        /// <param name="text">显示的文字</param>
        private void TextTitle(string text)
        {
            
            if (layerScreenText != null)
            {
                //清除其中所有要素
                layerScreenText.RemoveAllFeature();
                GSOGeoScreenText overlayTextTitle = new GSOGeoScreenText(); //创建屏幕文字
                GSOTextStyle textStyle = new GSOTextStyle();                //设置属性
                textStyle.ForeColor = Color.White;
                textStyle.FontSize = 36;
                overlayTextTitle.TextStyle = textStyle;
                overlayTextTitle.Align = EnumAlign.TopLeft;                 //设置文字对齐方式
                overlayTextTitle.PosAlign = EnumAlign.BottomRight;          //设置文字位置
                overlayTextTitle.Name = "ScreenTextTitle";
                overlayTextTitle.SetOffset(180, 60);                        //设置文字偏移量
                overlayTextTitle.Text = text;                         //设置文字
                GSOFeature feature_ScreenTextTitle = new GSOFeature();      //创建要素
                feature_ScreenTextTitle.Geometry = overlayTextTitle;        //赋予要素
                layerScreenText.AddFeature(feature_ScreenTextTitle);
                layerScreenText.Save();
            }
        }

        #endregion

        #region 跟随鼠标图层

        /// <summary>
        /// 跟随鼠标图层
        /// </summary>
        /// <param name="text">显示文字</param>
        private void SetScreenText(string text)
        {
            //如果要素存在就删除
            if (feature_ScreenText != null)
            {
                feature_ScreenText.Delete();
            }
            if (text != "" && layerScreenText != null)
            {
                overlayText = new GSOGeoScreenText();           //创建对象
                GSOTextStyle textStyle = new GSOTextStyle();    //创建样式
                textStyle.ForeColor = Color.White;              //字体颜色
                textStyle.FontSize = 9;                         //字体大小
                overlayText.TextStyle = textStyle;              //赋予字体样式
                overlayText.Align = EnumAlign.TopLeft;          //字体对其方式
                overlayText.Name = "ScreenText";                //字体对象名称
                overlayText.SetOffset(20, 0);                   //字体偏移量
                overlayText.Text = text;                        //显示文字
                feature_ScreenText = new GSOFeature();          //创建要素
                feature_ScreenText.Geometry = overlayText;      //赋予要素
                layerScreenText.AddFeature(feature_ScreenText); //添加要素到图层
            }
        }

        void globeControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (overlayText != null && overlayText.Text != "" && feature_ScreenText != null)
            {
                overlayText.SetOffset(e.X + 20, e.Y);
                feature_ScreenText.Geometry = overlayText;
                globeControl1.Refresh();
            }
        }

        #endregion
    }
}
