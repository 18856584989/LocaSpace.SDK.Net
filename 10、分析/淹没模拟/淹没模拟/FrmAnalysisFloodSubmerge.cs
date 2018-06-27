using System;
using System.Drawing;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
//  

namespace 淹没模拟.淹没模拟
{
    public partial class FrmAnalysisFloodSubmerge : Form
    {
        GSOGlobeControl globeControl1;
        GSOGeoPolygon3D m_polygon3D = null;
        private GSOPoint3d m_pntMaxAlt;
        private GSOPoint3d m_pntMinAlt;
        private double m_dTotalArea = 0;
        private double m_dFloodArea = 0;
        private double m_dBaseAlt = 0;
        private GSOFeature m_WaterFeature = null;

        public FrmAnalysisFloodSubmerge(GSOGlobeControl _globeControl1, GSOGeoPolygon3D _polygon3D)
        {
            InitializeComponent();
            //默认20次每秒
            textBoxFrequency.Text = "20";

            globeControl1 = _globeControl1;
            m_polygon3D = _polygon3D;
        }

        private void FloodSubmergeAnalysisDlg_Load(object sender, EventArgs e)
        {
            timerPlay.Stop();   //停止计时器
            Analysis();         //开始分析
            SetText();          //显示文字
            ShowWater();        //显示水面
            buttonSetPlayParam_Click(null, null);   //推介参数
        }

        /// <summary>
        /// 分析
        /// </summary>
        private void Analysis()
        {
            if (globeControl1.Globe != null && m_polygon3D != null)
            {
                m_dBaseAlt = Convert.ToDouble(textBoxWaterAlt.Text);
                globeControl1.Globe.Analysis3D.NoSourceFloodAnalyse(m_polygon3D, m_dBaseAlt, out m_dFloodArea, out m_dTotalArea,
                    out m_pntMaxAlt, out m_pntMinAlt, false, 0);
            }
        }

        /// <summary>
        /// 开始演示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (m_WaterFeature != null)
            {
                //水面高度
                m_dBaseAlt = Convert.ToDouble(textBoxWaterAlt.Text);
                //判断不能超过最大最小值
                if (m_dBaseAlt > m_pntMaxAlt.Z)
                {
                    m_dBaseAlt = m_pntMaxAlt.Z;
                }
                if (m_dBaseAlt < m_pntMinAlt.Z)
                {
                    m_dBaseAlt = m_pntMinAlt.Z;
                }
                textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");
                trackBarAlt.Value = Math.Min((int)m_dBaseAlt, trackBarAlt.Maximum);
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                geoWater.SetAltitude(m_dBaseAlt);

                int nF = Convert.ToInt32(textBoxFrequency.Text);
                if (nF <= 0)
                {
                    nF = 1;
                }
                timerPlay.Interval = (int)(1000.0 / nF);
                timerPlay.Start();
            }
            else
            {
                MessageBox.Show("请先进行分析！");
            }
        }
        
        /// <summary>
        /// 设置文字
        /// </summary>
        private void SetText()
        {
            textBoxPntMax.Text = m_pntMaxAlt.X.ToString("f6") + "," + m_pntMaxAlt.Y.ToString("f6") + "," + m_pntMaxAlt.Z.ToString("f2");
            textBoxPntMin.Text = m_pntMinAlt.X.ToString("f6") + "," + m_pntMinAlt.Y.ToString("f6") + "," + m_pntMinAlt.Z.ToString("f2");
            textBoxFloodArea.Text = m_dFloodArea.ToString("f2") + " 平方米";            
            textBoxTotalArea.Text = m_dTotalArea.ToString("f2") + " 平方米";
        }

        /// <summary>
        /// 显示水面
        /// </summary>
        private void ShowWater()
        {
            if (m_WaterFeature==null || m_WaterFeature.IsDeleted)
            {
                //水面高度先设置为最低点高度
                m_dBaseAlt = m_pntMinAlt.Z;
                GSOGeoWater geoWater = m_polygon3D.ConvertToGeoWater(); //根据范围绘制水面模型
                GSOExtrudeStyle extrudeStyle = new GSOExtrudeStyle();   //设置Style
                if (checkBoxExtrude.Checked)
                {
                    extrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeToValue;
                }
                else
                {
                    extrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeNone;
                }

                extrudeStyle.ExtrudeValue = m_pntMinAlt.Z;
                extrudeStyle.TailPartVisible = false;

                GSOSimplePolygonStyle3D polygonStyle = new GSOSimplePolygonStyle3D();
                polygonStyle.FillColor = Color.FromArgb(200, 0, 0, 255);

                extrudeStyle.BodyStyle = polygonStyle;

                geoWater.ExtrudeStyle = extrudeStyle;

                geoWater.AltitudeMode = EnumAltitudeMode.Absolute;  //高度类型
                geoWater.SetAltitude(m_dBaseAlt);   //设置高度
                geoWater.ReflectSky = false;        //是否反射天空
                geoWater.WaveWidth = 0.1;           //浪的高度
                geoWater.Play();                    //开始动画

                //添加水面要素
                m_WaterFeature = new GSOFeature();
                m_WaterFeature.Geometry = geoWater;
                globeControl1.Globe.MemoryLayer.AddFeature(m_WaterFeature);
                globeControl1.Globe.Refresh();

                trackBarAlt.Maximum = (int)m_pntMaxAlt.Z;
                trackBarAlt.Minimum = (int)m_pntMinAlt.Z;
                trackBarAlt.Value = trackBarAlt.Minimum;
                textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");            
            }
            else
            {
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                geoWater.SetAltitude(m_dBaseAlt);
                globeControl1.Globe.Refresh();

                trackBarAlt.Maximum = (int)m_pntMaxAlt.Z;
                trackBarAlt.Minimum = (int)m_pntMinAlt.Z;
            }            
        }

        /// <summary>
        /// 创建个计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerPlay_Tick(object sender, EventArgs e)
        {
            if (m_WaterFeature!=null)
            {
                if (m_dBaseAlt>m_pntMaxAlt.Z)
                {
                    if (checkBoxLoopPlay.Checked)
                    {
                        m_dBaseAlt = m_pntMinAlt.Z;
                    }
                    else
                    {
                        timerPlay.Stop();
                    }                    
                }
                //每秒升高
                m_dBaseAlt += (double)numericUpDownAddPerTime.Value;
                globeControl1.Globe.Analysis3D.FetchNoSourceFloodAnalyseResult(m_dBaseAlt, out m_dFloodArea, out m_dTotalArea,
              out m_pntMaxAlt, out m_pntMinAlt);

                SetText();

                textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");
                trackBarAlt.Value = Math.Min((int)m_dBaseAlt, trackBarAlt.Maximum);
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                geoWater.SetAltitude(m_dBaseAlt);
            }
        }

        /// <summary>
        /// 根据水面高度变化设置高度数值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarAlt_Scroll(object sender, EventArgs e)
        {
            textBoxWaterAlt.Text = trackBarAlt.Value.ToString();
        }

        /// <summary>
        /// 每秒增加改成滑块刻度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownAddPerTime_ValueChanged(object sender, EventArgs e)
        {
            trackBarAlt.TickFrequency = Convert.ToInt32(numericUpDownAddPerTime.Value);
        }

        /// <summary>
        /// 停止模拟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerPlay.Stop();
        }

        /// <summary>
        /// 是否显示立面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxExtrude_CheckedChanged(object sender, EventArgs e)
        {
            if (m_WaterFeature != null)
            {
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                if (checkBoxExtrude.Checked)
                {   
                    geoWater.ExtrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeToValue;
                }
                else
                {
                    geoWater.ExtrudeStyle.ExtrudeType = EnumExtrudeType.ExtrudeNone;
                }               
            }
        }

        /// <summary>
        /// 推荐参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetPlayParam_Click(object sender, EventArgs e)
        {
            //播放频率
            int nF = Convert.ToInt32(textBoxFrequency.Text);
            if (nF <= 0)
            {
                nF = 1;
            }
            //最大值为最高点
            numericUpDownAddPerTime.Maximum = (decimal)m_pntMaxAlt.Z;
            numericUpDownAddPerTime.Minimum = 0;
            double dAltDiff = (m_pntMaxAlt.Z - m_pntMinAlt.Z);  //绝对高度

            numericUpDownAddPerTime.Increment = (decimal)(0.1*dAltDiff / nF); // 用10秒播放完
            numericUpDownAddPerTime.Value = numericUpDownAddPerTime.Increment;

            trackBarAlt.Maximum = (int)m_pntMaxAlt.Z;   //滑块最大为最高点
            trackBarAlt.Minimum = (int)m_pntMinAlt.Z;   //滑块最小为最低点
            trackBarAlt.Value = trackBarAlt.Minimum;    //默认为最小处

            int nTF = (int)numericUpDownAddPerTime.Increment;   //如果滑块每格的值小于1，这换成1
            if (nTF < 1)
            {
                nTF = 1;
            }
            trackBarAlt.TickFrequency = nTF;

            m_dBaseAlt = m_pntMinAlt.Z;
            textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");
        }

        /// <summary>
        /// 重播按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReplay_Click(object sender, EventArgs e)
        {            
            if (m_WaterFeature != null)
            {
                m_dBaseAlt = m_pntMinAlt.Z; //设置为最低点
                textBoxWaterAlt.Text = m_dBaseAlt.ToString("f2");
                trackBarAlt.Value = trackBarAlt.Minimum;
                GSOGeoWater geoWater = (GSOGeoWater)m_WaterFeature.Geometry;
                geoWater.SetAltitude(m_dBaseAlt);
                int nF = Convert.ToInt32(textBoxFrequency.Text);
                if (nF <= 0)
                {
                    nF = 1;
                }
                timerPlay.Interval = (int)(1000.0 / nF);
                timerPlay.Start();
            }
        }
        
        private void FrmAnalysisFloodSubmerge_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除最后的分析面
            globeControl1.Globe.ClearLastTrackPolygon();
            if (m_WaterFeature != null)
            {
                //清除水面要素
                globeControl1.Globe.MemoryLayer.RemoveFeatureByID(m_WaterFeature.ID);
                m_WaterFeature = null;
            }  
        }

    }
}
