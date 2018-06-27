using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraph类库
{
    public partial class Form1 : Form
    {
        GraphPane myPane;

        public Form1()
        {
            InitializeComponent();


            #region 属性设置
            zedGraphControl1.IsShowPointValues = true;
            //当鼠标悬浮到图表中的某一点上时鼠标经过图表上的点时是否气泡显示该点所对应的值.

            zedGraphControl1.IsShowCursorValues = true;//鼠标在图表上移动时是否显示鼠标所在点对应的坐标值。默认为false

            zedGraphControl1.IsShowHScrollBar = true; //是否显示横向滚动条
            //zedGraphControl1.IsShowVScrollBar = true; //是否显示纵向滚动条

            zedGraphControl1.IsEnableZoom = true;//是否允许缩放
            zedGraphControl1.IsEnableHZoom = true;//是否允许横向缩放
            //zedGraphControl1.IsEnableVZoom = true;//是否允许纵向缩放

            zedGraphControl1.IsShowContextMenu = true;// 是否显示右键菜单，如果指定了ContextMenuStrip会一直显示指定的ContextMenu。

            #endregion
        }

        #region 创建图层区域 方法一

        /// <summary>
        /// 创建图层区域 方法一
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            //在坐标(40,40)处创建一个新图形, 大小为 600x400，
            //图表区域标题为My Test Graph,X轴标题为My X Axis，Y轴标题为My Y Axis。
            myPane = new GraphPane(
                new Rectangle(40, 40, 600, 400),
                "My Test Graph",
                "My X Axis",
                "My Y Axis");
            //添加到zedGraphControl1中
            zedGraphControl1.GraphPane = myPane;
            //刷新控件
            zedGraphControl1.Refresh();
        }
        #endregion

        #region 创建图层区域  方法二
        /// <summary>
        /// 创建图层区域  方法二
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, System.EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;        //获取zedGraphControl1的图表显示区域赋值给myPane。
            myPane.Title.Text = "数据统计";             //图表区域标题
            myPane.XAxis.Title.Text = "X坐标";          //X轴标题
            myPane.YAxis.Title.Text = "Y坐标";          //Y轴标题
            //刷新控件
            zedGraphControl1.Refresh();
        }
        #endregion

        #region 图表区域颜色渐变设置
        /// <summary>
        /// 图表区域颜色渐变设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, System.EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;
            myPane.Chart.Fill = new Fill(Color.White, Color.SteelBlue, 45.0f);
            //图表显示区域颜色，渐变颜色1White，渐变颜色2SteelBlue，45.0f为渐变颜色角度

            zedGraphControl1.Refresh();
        }
        #endregion

        #region 大跨度的X,Y轴表格虚线是否显示
        /// <summary>
        /// 大跨度的X,Y轴表格虚线是否显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, System.EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;
            //大跨度的X轴表格虚线是否显示
            myPane.XAxis.MajorGrid.IsVisible = !myPane.XAxis.MajorGrid.IsVisible;
            //大跨度的Y轴表格虚线是否显示
            myPane.YAxis.MajorGrid.IsVisible = !myPane.YAxis.MajorGrid.IsVisible;

            myPane.XAxis.MajorGrid.Color = Color.LightGray;
            myPane.YAxis.MajorGrid.Color = Color.LightGray;//表格虚线颜色设置

            myPane.YAxis.MajorGrid.DashOff = 0;
            myPane.XAxis.MajorGrid.DashOff = 0;            //表格线以实线显示

            zedGraphControl1.Refresh();
        }
        #endregion

        #region X,Y轴及轴刻度
        /// <summary>
        /// X,Y轴及轴刻度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, System.EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;
            //X,Y轴及轴刻度：
            myPane.XAxis.IsVisible = false;            //X轴是否显示
            myPane.YAxis.IsVisible = false;            // Y轴是否显示

            myPane.XAxis.Scale.IsVisible = false;      //X轴刻度是否显示
            myPane.YAxis.Scale.IsVisible = false;      //Y轴刻度是否显示

            myPane.XAxis.Scale.Min = -1000;  //X轴最小刻度
            myPane.XAxis.Scale.Max = 1000;  //X轴最大刻度

            myPane.YAxis.Scale.Min = -1000;  //Y轴最小刻度
            myPane.YAxis.Scale.Max = 1000;  //Y轴最大刻度

            myPane.XAxis.Scale.BaseTic = 0;            //X轴第一个主刻度从哪里开始
            myPane.YAxis.Scale.BaseTic = 0;            //Y轴第一个主刻度从哪里开始

            zedGraphControl1.Refresh();
        }
        #endregion

        #region 图表注释
        /// <summary>
        /// 图表注释
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, System.EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;

            myPane.Legend.IsVisible = true;            //图表注释是否显示

            myPane.Legend.Position = LegendPos.Float;
            //LegendPos是一个枚举，共有13个枚举值：Top、Left、Right、Bottom、InsideTopLeft、InsideTopRight、
            //InsideBotLeft、InsideBotRight、Float、TopCenter、BottomCenter、TopFlushLeft和BottomFlushLeft。

            myPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
            //Location是指定Legend具体坐标的一个类，要注意的是，只有当LegendPos是Float时，Location才会起作用。

            myPane.Legend.FontSpec.Size = 10f;
            //FontSpec类就是一个字体类，里面是关于字体的一些相关设置

            myPane.Legend.IsHStack = false;
            //IsHStack是一个Legend的属性，是设置Legend中文字和图形的显示方式是水平还是垂直。

            zedGraphControl1.Refresh();
        }
        #endregion

        #region 通过制定（X,Y）坐标作为图表的数据源
        /// <summary>
        /// 通过制定（X,Y）坐标作为图表的数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, System.EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;

            double x, y1, y2;        //定义变量存放点的X,Y坐标
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();  // PointPair类是一个包含(X,Y)的坐标类

            for (int i = 0; i < 36; i++)
            {
                x = (double)i + 5;                          //给数据的X坐标赋值
                y1 = 1.5 + Math.Sin((double)i * 0.2);       //给数据的Y坐标赋值
                y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                list1.Add(x, y1);
                list2.Add(x, y2);   //在列表中存数每个点的X,Y坐标
            }
            LineItem myCurve = myPane.AddCurve("Porsche", list1, Color.Red, SymbolType.Diamond);
            //LineItem类是ZedGraph中的线条类. 根据数据集list1创建红色的菱形曲线，标记"Porsche"，这个函数的返回值是一个LineItem。
            //可以通过myCurve这个变量来对它进行进一步的设定。其中SymbolType是个Enum，它枚举了12个可供使用的形状，
            //包括Circle,Default,Diamond,HDash,None,Plus，Square,Star,Triangle,UserDefined,VDash,XCross.

            LineItem myCurve2 = myPane.AddCurve("Piper", list2, Color.Blue, SymbolType.Circle);
            // 根据数据集list2创建蓝色的圆形曲线, 标记"Piper"

            myCurve.Line.IsVisible = false;      //设置曲线的线不可见，则只显示各个散点 

            myPane.AddStick("采样线", list1, Color.BurlyWood);//对于数据集list1的每个点添加投影线

            myPane.AxisChange(this.CreateGraphics()); // 在数据变化时绘制图形   

            zedGraphControl1.Refresh();
        }
        #endregion

        #region 数组作为图表的数据源
        /// <summary>
        /// 数组作为图表的数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;

            double[] x = { 2, 4, 6, 8, 10, 12 };          //定义变量存储数据的X坐标
            double[] y = { 100, 115, 75, 22, 98, 40 };    //定义变量存储数据的Y坐标
            PointPairList list = new PointPairList();
            for (int i = 0; i < x.Length; i++)
            {
                list.Add(x[i], y[i]);    //将X,Y坐标保存到list中
            }
            LineItem myCurve = myPane.AddCurve("Piper", list, Color.Blue, SymbolType.Circle);
            // 根据数据集list创建蓝色的圆形曲线, 标记"Piper"

            myPane.AxisChange(this.CreateGraphics());  //刷新显示

            zedGraphControl1.Refresh();
        }
        #endregion

        #region DataTable数据源

        #region 连接数据库

        //private static readonly string path = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        ////读取配置文件中的连接字符串SqlConn

        //public static DataSet Select(string sql)
        //{//执行sql语句，返回dataset
        //    SqlConnection connection = null;  //创建连接
        //    try
        //    {
        //        using (connection = new SqlConnection(path))
        //        {
        //            DataSet ds = new DataSet();
        //            connection.Open();     //打开连接
        //            SqlDataAdapter command = new SqlDataAdapter(sql, connection);
        //            command.Fill(ds, "ds");
        //            return ds;
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        connection.Dispose();  //释放资源
        //    }
        //}

        #endregion

        /// <summary>
        /// DataTable数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            if (true)
            {
                MessageBox.Show("该示例无数据库，不可用，您可以进入后台代码自己添加数据库和查询语句进行测试");
                return;
            }

            //myPane = zedGraphControl1.GraphPane;

            //DataSet m_dataSet;                                //定义dataset，接收查询出的数据
            //string sql = "select ColumnName from TableName";
            ////查询数据sql语句,其中ColumnName为查询的列名，TableName为查询表名。
            //m_dataSet = Select(sql);                    //Select为执行sql语句的方法，将sql语句传给该方法 
            //DataTable table = m_dataSet.Tables[0];      //将查询的数据存放到datatable中
            //PointPairList list = new PointPairList();
            //for (int x = 0; x < table.Rows.Count; x++)
            //{
            //    double y = double.Parse(table.Rows[x][1].ToString());  //从查询的数据中获取Y坐标
            //    list.Add(x, y);   //将X,Y坐标存放到list中
            //}
            //LineItem myCurve = myPane.AddCurve("Piper", list, Color.Blue, SymbolType.Circle);
            //// 根据数据集list创建蓝色的圆形曲线, 标记"Piper"

            //myPane.AxisChange(this.CreateGraphics());  //刷新显示

            //zedGraphControl1.Refresh();
        }
        #endregion

        #region 柱形图表
        /// <summary>
        /// 柱形图表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;

            double[] x = { 2, 4, 6, 8, 10, 12 };          //定义变量存储数据的X坐标
            double[] y = { 100, 115, 75, 22, 98, 40 };    //定义变量存储数据的Y坐标

            BarItem myBar = myPane.AddBar("Curve 1", x, y, Color.Red);
            // BarItem它的基类ZedGraph.CurveItem里包含了Pane上单个曲线图表的数据和方法。
            //它实现了图表的属性设置，myPane.AddBar方法中的第一个参数为柱形图的注释，第二三个参数分别是数据的X,Y坐标，
            //最后一个参数为柱形图的颜色。

            myBar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
            //设置柱形图颜色，两边为Red，中间为White。

            //myPane.BarSettings.Base = BarBase.Y;       //以Y轴为基轴
            myPane.BarSettings.Base = BarBase.X;         //以X轴为基轴

            myBar = myPane.AddBar("Curve 2", null, y, Color.Blue);
            myBar.Bar.Fill = new Fill(Color.Blue, Color.White, Color.Blue);

            myPane.BarSettings.Type = BarType.Stack;
            //BarType是一个枚举，共有六项，
            //分别为Cluster、ClusterHiLow、Overlay、SortedOverlay、Stack和PercentStack,
            //Cluster和ClusterHiLow是让多个同一个基类Bar依次排开，Cluster还可以使用来自IPointList的“Z”的值来定义每一个Bar的底部,
            //Overlay和SortedOverlay就是柱形按坐标相互覆盖。
            //不同之处在于Overlay是按照哪个先画哪个在前的原则(注意这里不是按后画把先画的柱形覆盖的原则，而是正好相反按先画在前原则)。
            //SortedOverlay是按位标的大小，按小的位标在前，大的位标在后的原则来绘图的, 最后的两个Stack和PercentStack就是按先前的位标依次累积上升。

            myPane.Chart.Fill = new Fill(Color.White, Color.SteelBlue, 45.0f);
            myPane.AxisChange(this.CreateGraphics());

            zedGraphControl1.Refresh();
        }
        #endregion

        #region 饼形图表
        /// <summary>
        /// 饼形图表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;

            PieItem segment1 = myPane.AddPieSlice(20, Color.Navy, Color.White, 45.0f, 0, "North");
            PieItem segment3 = myPane.AddPieSlice(30, Color.Purple, Color.White, 45f, 0, "East");
            //六个参数分别为：在整个饼形图中占的比重，渐变颜色1，渐变颜色2，渐变颜色角度，远离中心点的距离，饼形图的文字注释。

            PieItem segment4 = myPane.AddPieSlice(10.21, Color.LimeGreen, Color.White, 45f, 0, "West");
            PieItem segment2 = myPane.AddPieSlice(40, Color.SandyBrown, Color.White, 45f, 0.2, "South");
            PieItem segment6 = myPane.AddPieSlice(250, Color.Red, Color.White, 45f, 0, "Europe");
            PieItem segment7 = myPane.AddPieSlice(50, Color.Blue, Color.White, 45f, 0.2, "Pac Rim");
            PieItem segment8 = myPane.AddPieSlice(400, Color.Green, Color.White, 45f, 0, "South America");
            PieItem segment9 = myPane.AddPieSlice(50, Color.Yellow, Color.White, 45f, 0.2, "Africa");
            segment2.LabelDetail.FontSpec.FontColor = Color.Red;     //对其中一部分的Label提示信息进行设置

            zedGraphControl1.Refresh();
        }
        #endregion

    }
}
