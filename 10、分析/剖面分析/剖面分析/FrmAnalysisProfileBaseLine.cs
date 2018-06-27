using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GeoScene.Data;
using GeoScene.Globe;
using ZedGraph;

namespace 剖面分析.剖面分析
{
    public partial class FrmAnalysisProfileBaseLine : Form
    {
        GSOGlobeControl globeControl1;
        public GSOGeoPolyline3D m_geopolyline = null;

        private GSOPoint3ds m_pnt3ds;
        private GSOPoint3d m_pntMax;
        private GSOPoint3d m_pntMin;
        private GSOPoint3d m_pntStart;
        private GSOPoint3d m_pntEnd;
        private double m_dXTotalLength = 0;
        private double m_dSpaceLength = 0;
        private double m_dSphereLength = 0;
        private double m_dGroundLength = 0;
        private double m_dBaseAlt = 0;
        private Boolean m_bXYSameScale = false;
        private Boolean m_bSetMinX = false;
        private Boolean m_bSetMinY = false;

        public FrmAnalysisProfileBaseLine(GSOGlobeControl _globeControl1, GSOGeoPolyline3D _geopolyline)
        {
            InitializeComponent();

            globeControl1 = _globeControl1;
            m_geopolyline = _geopolyline;
        }

        private void BaseLineProfillAnalysis_Load(object sender, EventArgs e)
        {
            //zedGraphControl1为ZedGraph控件，获取ZedGraphControl控件的图表显示区域赋值给myPane
            GraphPane myPane = zedGraphControl1.GraphPane;

            myPane.Title.Text = "剖面分析";                 //图表标题
            myPane.Title.FontSpec.Family = "黑体";          //标题字体
            myPane.Title.FontSpec.IsBold = false;           //是否粗体显示
            myPane.Title.FontSpec.Size = 18.0f;             //字体大小

            myPane.XAxis.Title.Text = "长度";               //X轴标题
            myPane.XAxis.Title.FontSpec.Family = "黑体";
            myPane.XAxis.Title.FontSpec.IsBold = false;
            myPane.XAxis.Title.FontSpec.Size = 18.0f;

            myPane.YAxis.Title.Text = "高程";               //Y轴标题
            myPane.YAxis.Title.FontSpec.Family = "黑体";
            myPane.YAxis.Title.FontSpec.IsBold = false;
            myPane.YAxis.Title.FontSpec.Size = 18.0f;

            //图表显示区域颜色，渐变颜色1White，渐变颜色2LightGray
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            //获取线的地表长度  输入：dRadius：半径
            double lineLength = m_geopolyline.GetSphereLength(6378137);


            textBoxPointCount.Text = "100";
            textBoxJianJu.Text = (lineLength / 99.0).ToString("0.0");
            buttonAnalyse_Click(null, null);
        }

        /// <summary>
        /// 开始分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            //判断球和分析线不为空
            if (m_geopolyline != null && globeControl1.Globe != null)
            {
                //获取线的地表长度  输入：半径
                m_dSphereLength = m_geopolyline.GetSphereLength(6378137.0);

                //获取线的空间长度  输入: 是否忽略Z值 ，半径
                m_dSpaceLength = m_geopolyline.GetSpaceLength(false, 6378137.0);

                //获取地标距离  输入：分析线，false，0
                m_dGroundLength = globeControl1.Globe.Analysis3D.GetGroundLength(m_geopolyline, false, 0);
                //采样间距
                float jianJu = (float)textBoxJianJu.Value;
                //采样数量
                int pointCount = (int)(m_dSphereLength / jianJu);
                GSOPoint3d pntMax, pntMin, pntStart, pntEnd;
                GSOPoint3ds pnt3ds;
                double dLineLength;

                //获取分析结果 输入：分析线，采样数量
                //输出：点集合，线长度，最大点，最小点，开始点，结束点
                globeControl1.Globe.Analysis3D.ProfileAnalyse(m_geopolyline, pointCount, out pnt3ds, out dLineLength, out pntMax, out pntMin, out pntStart, out pntEnd);

                //开始根据数据整理成到DataGridView中
                try
                {
                    m_pnt3ds = pnt3ds;
                    m_pntMax = pntMax;
                    m_pntMin = pntMin;
                    m_pntStart = pntStart;
                    m_pntEnd = pntEnd;
                    m_dXTotalLength = dLineLength;
                    dataGridViewPoints.Rows.Clear();
                    int index = 1;
                    for (int i = 0; i < m_pnt3ds.Count; i++)
                    {
                        GSOPoint3d pt = m_pnt3ds[i];
                        if (pt != null)
                        {
                            int rowIndex = dataGridViewPoints.Rows.Add();
                            dataGridViewPoints.Rows[rowIndex].Cells[0].Value = index.ToString();
                            dataGridViewPoints.Rows[rowIndex].Cells[1].Value = pt.X.ToString("0.0000000");
                            dataGridViewPoints.Rows[rowIndex].Cells[2].Value = pt.Y.ToString("0.0000000");
                            dataGridViewPoints.Rows[rowIndex].Cells[3].Value = pt.Z.ToString("0.00");
                            index++;
                        }
                    }
                    //设置文字
                    SetLableText();
                    //画出图
                    DrawCurveGraph();
                }
                catch (Exception ext)
                {

                    MessageBox.Show("数据异常，参考信息：" + ext.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SetLableText()
        {
            labelStartLon.Text = "起点经度： " + m_pntStart.X.ToString("f6");
            labelStartLat.Text = "起点纬度： " + m_pntStart.Y.ToString("f6");
            labelEndLon.Text = "终点经度： " + m_pntEnd.X.ToString("f6");
            labelEndLat.Text = "终点纬度： " + m_pntEnd.Y.ToString("f6");
            labelStartAlt.Text = "起点高程： " + m_pntStart.Z.ToString("f2");
            labelEndAlt.Text = "终点高程： " + m_pntEnd.Z.ToString("f2");
            labelMaxAlt.Text = "最大高程： " + m_pntMax.Z.ToString("f2");
            labelMinAlt.Text = "最小高程： " + m_pntMin.Z.ToString("f2");
            labelSphereLenth.Text = "投影距离： " + m_dSphereLength.ToString("f2");
            labelGroundLenth.Text = "地表距离： " + m_dGroundLength.ToString("f2");
            labelSpaceLenth.Text = "直线距离： " + m_dSpaceLength.ToString("f2");
            labelPointNum.Text = "采样点数： " + m_pnt3ds.Count;

            textBoxPointCount.Text = m_pnt3ds.Count.ToString();
        }

        /// <summary>
        /// 绘图事件
        /// </summary>
        private void DrawCurveGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);
            m_dBaseAlt = Convert.ToDouble(textBoxBaseAlt.Text);
            myPane.Legend.IsVisible = false;
            PointPairList listHLAbove = new PointPairList();
            PointPairList listAbove = new PointPairList();
            PointPairList listHLBelow = new PointPairList();
            PointPairList listBelow = new PointPairList();
            PointPairList listEqual = new PointPairList();
            PointPairList listBase = new PointPairList();

            ArrayList arryHLAbove = new ArrayList();
            ArrayList arryHLBelow = new ArrayList();
            ArrayList arryAbove = new ArrayList();
            ArrayList arryBelow = new ArrayList();

            int nPointCount = m_pnt3ds.Count;
            double dOneSegLen = m_dXTotalLength / (nPointCount - 1);

            int nSegmentType = -1; //0=m_dBaseAlt,1=above,2=below
            for (int i = 0; i < m_pnt3ds.Count; i++)
            {
                double x = i * dOneSegLen;
                double y = (int)(Math.Round(m_pnt3ds[i].Z * 100)) / 100.0; // 精确到厘米就行了                
                if (y > m_dBaseAlt)
                {
                    // 如果当前段是基准线下面的段
                    if (nSegmentType == 2)
                    {
                        arryHLBelow.Add(listHLBelow);
                        arryBelow.Add(listBelow);
                        listHLBelow = new PointPairList();
                        listBelow = new PointPairList();
                    }
                    nSegmentType = 1;
                    listAbove.Add(x, y);
                    listHLAbove.Add(x, y, m_dBaseAlt);
                }
                else if (y < m_dBaseAlt)
                {
                    if (nSegmentType == 1)
                    {
                        arryHLAbove.Add(listHLAbove);
                        arryAbove.Add(listAbove);
                        listHLAbove = new PointPairList();
                        listAbove = new PointPairList();
                    }
                    nSegmentType = 2;
                    listBelow.Add(x, y);
                    listHLBelow.Add(x, m_dBaseAlt, y);
                }
                else
                {
                    if (nSegmentType == 2)
                    {
                        arryHLBelow.Add(listHLBelow);
                        arryBelow.Add(listBelow);
                        listHLBelow = new PointPairList();
                        listBelow = new PointPairList();
                    }
                    else if (nSegmentType == 1)
                    {
                        arryHLAbove.Add(listHLAbove);
                        arryAbove.Add(listAbove);
                        listHLAbove = new PointPairList();
                        listAbove = new PointPairList();
                    }
                    nSegmentType = 0;
                    listEqual.Add(x, y, m_dBaseAlt);
                }
            }
            if (nSegmentType == 2)
            {
                arryHLBelow.Add(listHLBelow);
                arryBelow.Add(listBelow);
            }
            else if (nSegmentType == 1)
            {
                arryHLAbove.Add(listHLAbove);
                arryAbove.Add(listAbove);
            }
            listBase.Add(0, m_dBaseAlt);
            listBase.Add(m_dXTotalLength, m_dBaseAlt);

            LineItem myCurveBase = myPane.AddCurve("基线剖面", listBase, Color.Blue, SymbolType.None);
            myCurveBase.Line.IsAntiAlias = true;
            myCurveBase.Line.Width = 2;


            int k = 0;
            for (k = 0; k < arryHLAbove.Count; k++)
            {
                LineItem myCurveAbove = myPane.AddCurve("高于基线剖面", (PointPairList)arryAbove[k], Color.Red, SymbolType.None);
                myCurveAbove.Line.IsAntiAlias = true;
                myCurveAbove.Line.Width = 2;
                myCurveAbove.Line.IsSmooth = true;

                HiLowBarItem hlAboveItem = myPane.AddHiLowBar("高于基线", (PointPairList)arryHLAbove[k], Color.Red);
                hlAboveItem.Bar.Border.Color = Color.Red;
            }
            for (k = 0; k < arryHLBelow.Count; k++)
            {
                LineItem myCurveBelow = myPane.AddCurve("低于基线剖面", (PointPairList)arryBelow[k], Color.Green, SymbolType.None);
                myCurveBelow.Line.IsAntiAlias = true;
                myCurveBelow.Line.Width = 2;
                myCurveBelow.Line.IsSmooth = true;

                HiLowBarItem hlBolowItem = myPane.AddHiLowBar("低于基线", (PointPairList)arryHLBelow[k], Color.Green);
                hlBolowItem.Bar.Border.Color = Color.Green;
            }

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.IsAxisSegmentVisible = true;
            if (m_bSetMinX)
            {
                myPane.XAxis.Scale.Min = 0;
            }
            if (m_bSetMinY)
            {
                myPane.YAxis.Scale.Min = m_pntMin.Z;
            }

            //myPane.XAxis.Scale.Min = 0;

            myPane.YAxis.MajorGrid.IsVisible = true;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            //myPane.YAxis.Scale.Min = -1000;
            // myPane.YAxis.Scale.Max = 1000;

            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Enable scrollbars if needed
            //zedGraphControl1.IsShowHScrollBar = true;
            //zedGraphControl1.IsShowVScrollBar = true;
            zedGraphControl1.IsAutoScrollRange = true;

            // 是否显示点的X,Y坐标
            zedGraphControl1.IsShowPointValues = true;
            //鼠标悬浮到曲线上某一点时出发的事件
            zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

            // 添加ZedGraph缩放事件
            zedGraphControl1.ZoomEvent += new ZedGraphControl.ZoomEventHandler(MyZoomEvent);

            zedGraphControl1.AxisChange();

            if (m_bXYSameScale)
            {
                graphPane_AxisChangeEvent();
            }
            // Make sure the Graph gets redrawn
            zedGraphControl1.Invalidate();
        }

        /// <summary>
        /// Display customized tooltips when the mouse hovers over a point
        /// </summary>
        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane,
                        CurveItem curve, int iPt)
        {
            // Get the PointPair that is under the mouse
            PointPair pt = curve[iPt];
            return "(" + pt.X.ToString("f2") + "," + pt.Y.ToString("f2") + ")";
        }


        // Respond to a Zoom Event
        private void MyZoomEvent(ZedGraphControl control, ZoomState oldState,
                    ZoomState newState)
        {
            // Here we get notification everytime the user zooms
        }
        private void graphPane_AxisChangeEvent()
        {
            GraphPane graphPane = zedGraphControl1.GraphPane;
            // Correct the scale so that the two axes are 1:1 aspect ratio
            double scalex2 = (graphPane.XAxis.Scale.Max - graphPane.XAxis.Scale.Min) / graphPane.Rect.Width;
            double scaley2 = (graphPane.YAxis.Scale.Max - graphPane.YAxis.Scale.Min) / graphPane.Rect.Height;
            if (scalex2 > scaley2)
            {
                double diff = graphPane.YAxis.Scale.Max - graphPane.YAxis.Scale.Min;
                double new_diff = graphPane.Rect.Height * scalex2;

                graphPane.YAxis.Scale.Max = graphPane.YAxis.Scale.Min + new_diff;


                //graphPane.YAxis.Scale.Min -= (new_diff - diff) / 2.0;
                //graphPane.YAxis.Scale.Max += (new_diff - diff) / 2.0;
            }
            else if (scaley2 > scalex2)
            {
                double diff = graphPane.XAxis.Scale.Max - graphPane.XAxis.Scale.Min;
                double new_diff = graphPane.Rect.Width * scaley2;
                // graphPane.XAxis.Scale.Min -= (new_diff - diff) / 2.0;
                //graphPane.XAxis.Scale.Max += (new_diff - diff) / 2.0;
                graphPane.XAxis.Scale.Max = graphPane.XAxis.Scale.Min + new_diff;
            }
            // Recompute the grid lines
            float scaleFactor = graphPane.CalcScaleFactor();
            Graphics g = zedGraphControl1.CreateGraphics();
            graphPane.XAxis.Scale.PickScale(graphPane, g, scaleFactor);
            graphPane.YAxis.Scale.PickScale(graphPane, g, scaleFactor);
        }

        private void BaseLineProfillAnalysis_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (globeControl1.Globe != null)
            {
                globeControl1.Globe.ClearLastTrackPolyline();
            }
        }
    }
}
