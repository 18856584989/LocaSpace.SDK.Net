using System;
using System.Drawing;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;

namespace 填挖方分析.填挖方分析
{
    public partial class FrmAnalysisDigFillOfTerrain : Form
    {
        GSOGlobeControl globeControl1;
        GSOGeoPolygon3D m_polygon3D;
        //最高点
        GSOPoint3d m_pntMaxAlt;
        //最低点
        GSOPoint3d m_pntMinAlt;
        double m_dDigVolume = 0;
        double m_dFillVolume = 0;
        double m_dTotalArea = 0;
        double m_dDigArea = 0;
        double m_dFillArea = 0;

        private GSOFeature m_AltFeature = null;

        public FrmAnalysisDigFillOfTerrain(GSOGlobeControl _globeControl1, GSOGeoPolygon3D _polygon3D)
        {
            InitializeComponent();

            //从主窗口引入两个值，一个球，一个画的范围
            globeControl1 = _globeControl1;
            m_polygon3D = _polygon3D;
        }

        /// <summary>
        /// 设置文字
        /// </summary>
        private void SetText()
        {
            textBoxPntMax.Text = m_pntMaxAlt.X.ToString("f6") + "," + m_pntMaxAlt.Y.ToString("f6") + "," + m_pntMaxAlt.Z.ToString("f2");
            textBoxPntMin.Text = m_pntMinAlt.X.ToString("f6") + "," + m_pntMinAlt.Y.ToString("f6") + "," + m_pntMinAlt.Z.ToString("f2");
            textBoxFillVolume.Text = m_dFillVolume.ToString("f2") + " 立方米";
            textBoxDigVolume.Text = m_dDigVolume.ToString("f2") + " 立方米";

            double dDFVolume = m_dDigVolume + m_dFillVolume;
            textBoxDFVolume.Text = dDFVolume.ToString("f2") + " 立方米";
            textBoxFillArea.Text = m_dFillArea.ToString("f2") + " 平方米";
            textBoxDigArea.Text = m_dDigArea.ToString("f2") + " 平方米";

            double dDFArea = m_dFillArea + m_dDigArea;
            textBoxDFArea.Text = dDFArea.ToString("f2") + " 平方米";
            textBoxTotalArea.Text = m_dTotalArea.ToString("f2") + " 平方米";
        }


        /// <summary>
        /// 剖面分析窗口Load事件，用于设定一个默认高度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigFillAnalysisDlg_Load(object sender, EventArgs e)
        {
            //如果传过来的两个值都不为空
            if (globeControl1.Globe != null && m_polygon3D != null)
            {
                double dAlt = 0;//默认高度为0
                //交给系统处理，传入值为面，高度，返回为挖的高度，填的高度，挖的区域，填的区域，全部的面积，最高点，最低点，最后两项默认false，0
                globeControl1.Globe.Analysis3D.DigFillAnalyse(m_polygon3D, dAlt, out m_dDigVolume, out m_dFillVolume,
                    out m_dDigArea, out m_dFillArea, out m_dTotalArea, out m_pntMaxAlt, out m_pntMinAlt, false, 0);
                textBoxDestAlt.Text = (m_pntMaxAlt.Z / 2.0 + m_pntMinAlt.Z / 2.0).ToString("0.0");
                buttonAnalyse_Click(null, null);
            }
        }

        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe != null && m_polygon3D != null)
            {
                double dAlt = Convert.ToDouble(textBoxDestAlt.Text);
                //交给系统处理，传入值为面，高度，返回为挖的高度，填的高度，挖的区域，填的区域，全部的面积，最高点，最低点，最后两项默认false，0
                globeControl1.Globe.Analysis3D.DigFillAnalyse(m_polygon3D, dAlt, out m_dDigVolume, out m_dFillVolume,
                    out m_dDigArea, out m_dFillArea, out m_dTotalArea, out m_pntMaxAlt, out m_pntMinAlt, false, 0);

                GSOFeature altFeature = null;//创建一个空要素
                GSOFeatures tempFeatures = globeControl1.Globe.MemoryLayer.GetFeatureByName("DigFillAltPolygon", true);//要素从内存图层里获取
                if (tempFeatures.Length > 0)         //判断是否获取到
                {
                    altFeature = tempFeatures[0];   //获取到就直接赋值
                }
                //把传进来的范围面复制一个
                GSOGeoPolygon3D newPolygon = (GSOGeoPolygon3D)m_polygon3D.Clone();
                newPolygon.SetAltitude(dAlt);       //给这个面设置高度
                newPolygon.AltitudeMode = EnumAltitudeMode.Absolute;//高度类型是相对地面

                GSOExtrudeStyle extrudeStyle = new GSOExtrudeStyle();//拉伸风格
                extrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeToValue;//拉伸方式
                extrudeStyle.ExtrudeValue = m_pntMinAlt.Z;//拉伸的值
                extrudeStyle.TailPartVisible = false;     //末端是否可见

                //多边形风格，立面风格
                GSOSimplePolygonStyle3D extrudePolygonStyle = new GSOSimplePolygonStyle3D();
                extrudePolygonStyle.FillColor = Color.FromArgb(150, 0, 255, 0);//多边形填充颜色
                extrudeStyle.BodyStyle = extrudePolygonStyle;      //把风格赋给拉伸风格

                //多边形风格，顶层风格
                GSOSimplePolygonStyle3D polygonStyle = new GSOSimplePolygonStyle3D();
                polygonStyle.FillColor = Color.FromArgb(200, 0, 0, 255);//设置颜色

                newPolygon.Style = polygonStyle;    //面的顶层风格
                newPolygon.ExtrudeStyle = extrudeStyle; //棉的立面风格

                //判断如果要素为空，或者被删除
                if (m_AltFeature == null || m_AltFeature.IsDeleted)
                {
                    //新建一个要素，并且把刚才配置的要素赋值给它
                    m_AltFeature = new GSOFeature();
                    m_AltFeature.Name = "DigFillAltPolygon";
                    m_AltFeature.Geometry = newPolygon;
                    globeControl1.Globe.MemoryLayer.AddFeature(m_AltFeature);
                }
                else
                {
                    //如果原来就有，就直接赋值
                    m_AltFeature.Geometry = newPolygon;
                }
                //刷新球
                globeControl1.Globe.Refresh();

                //设置文字
                SetText();
            }
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigFillAnalysisDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_AltFeature != null)
            {
                globeControl1.Globe.MemoryLayer.RemoveFeatureByID(m_AltFeature.ID);
                globeControl1.Globe.ClearLastTrackPolygon();
                m_AltFeature = null;
                globeControl1.Refresh();
            }
        }
    }
}
