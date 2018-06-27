using System.ComponentModel;
using System.Windows.Forms;
using ZedGraphControl = ZedGraph.ZedGraphControl;

namespace 剖面分析.剖面分析
{
    partial class FrmAnalysisProfileBaseLine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelPointNum = new System.Windows.Forms.Label();
            this.labelSpaceLenth = new System.Windows.Forms.Label();
            this.labelGroundLenth = new System.Windows.Forms.Label();
            this.labelSphereLenth = new System.Windows.Forms.Label();
            this.labelEndAlt = new System.Windows.Forms.Label();
            this.labelMinAlt = new System.Windows.Forms.Label();
            this.labelMaxAlt = new System.Windows.Forms.Label();
            this.labelStartAlt = new System.Windows.Forms.Label();
            this.labelEndLat = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.labelEndLon = new System.Windows.Forms.Label();
            this.labelStartLat = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelStartLon = new System.Windows.Forms.Label();
            this.buttonAnalyse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewPoints = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxBaseAlt = new System.Windows.Forms.NumericUpDown();
            this.textBoxJianJu = new System.Windows.Forms.NumericUpDown();
            this.textBoxPointCount = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxBaseAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxJianJu)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPointNum
            // 
            this.labelPointNum.AutoSize = true;
            this.labelPointNum.Location = new System.Drawing.Point(368, 79);
            this.labelPointNum.Name = "labelPointNum";
            this.labelPointNum.Size = new System.Drawing.Size(65, 12);
            this.labelPointNum.TabIndex = 14;
            this.labelPointNum.Text = "采样点数：";
            // 
            // labelSpaceLenth
            // 
            this.labelSpaceLenth.AutoSize = true;
            this.labelSpaceLenth.Location = new System.Drawing.Point(368, 58);
            this.labelSpaceLenth.Name = "labelSpaceLenth";
            this.labelSpaceLenth.Size = new System.Drawing.Size(65, 12);
            this.labelSpaceLenth.TabIndex = 12;
            this.labelSpaceLenth.Text = "直线距离：";
            // 
            // labelGroundLenth
            // 
            this.labelGroundLenth.AutoSize = true;
            this.labelGroundLenth.Location = new System.Drawing.Point(368, 37);
            this.labelGroundLenth.Name = "labelGroundLenth";
            this.labelGroundLenth.Size = new System.Drawing.Size(65, 12);
            this.labelGroundLenth.TabIndex = 11;
            this.labelGroundLenth.Text = "地表距离：";
            // 
            // labelSphereLenth
            // 
            this.labelSphereLenth.AutoSize = true;
            this.labelSphereLenth.Location = new System.Drawing.Point(368, 17);
            this.labelSphereLenth.Name = "labelSphereLenth";
            this.labelSphereLenth.Size = new System.Drawing.Size(65, 12);
            this.labelSphereLenth.TabIndex = 10;
            this.labelSphereLenth.Text = "投影距离：";
            // 
            // labelEndAlt
            // 
            this.labelEndAlt.AutoSize = true;
            this.labelEndAlt.Location = new System.Drawing.Point(205, 37);
            this.labelEndAlt.Name = "labelEndAlt";
            this.labelEndAlt.Size = new System.Drawing.Size(65, 12);
            this.labelEndAlt.TabIndex = 8;
            this.labelEndAlt.Text = "终点高程：";
            // 
            // labelMinAlt
            // 
            this.labelMinAlt.AutoSize = true;
            this.labelMinAlt.Location = new System.Drawing.Point(205, 79);
            this.labelMinAlt.Name = "labelMinAlt";
            this.labelMinAlt.Size = new System.Drawing.Size(65, 12);
            this.labelMinAlt.TabIndex = 7;
            this.labelMinAlt.Text = "最小高程：";
            // 
            // labelMaxAlt
            // 
            this.labelMaxAlt.AutoSize = true;
            this.labelMaxAlt.Location = new System.Drawing.Point(205, 58);
            this.labelMaxAlt.Name = "labelMaxAlt";
            this.labelMaxAlt.Size = new System.Drawing.Size(65, 12);
            this.labelMaxAlt.TabIndex = 6;
            this.labelMaxAlt.Text = "最大高程：";
            // 
            // labelStartAlt
            // 
            this.labelStartAlt.AutoSize = true;
            this.labelStartAlt.Location = new System.Drawing.Point(205, 17);
            this.labelStartAlt.Name = "labelStartAlt";
            this.labelStartAlt.Size = new System.Drawing.Size(65, 12);
            this.labelStartAlt.TabIndex = 5;
            this.labelStartAlt.Text = "起点高程：";
            // 
            // labelEndLat
            // 
            this.labelEndLat.AutoSize = true;
            this.labelEndLat.Location = new System.Drawing.Point(40, 79);
            this.labelEndLat.Name = "labelEndLat";
            this.labelEndLat.Size = new System.Drawing.Size(65, 12);
            this.labelEndLat.TabIndex = 4;
            this.labelEndLat.Text = "终点纬度：";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(11, 10);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(502, 238);
            this.zedGraphControl1.TabIndex = 3;
            // 
            // labelEndLon
            // 
            this.labelEndLon.AutoSize = true;
            this.labelEndLon.Location = new System.Drawing.Point(40, 58);
            this.labelEndLon.Name = "labelEndLon";
            this.labelEndLon.Size = new System.Drawing.Size(65, 12);
            this.labelEndLon.TabIndex = 3;
            this.labelEndLon.Text = "终点经度：";
            // 
            // labelStartLat
            // 
            this.labelStartLat.AutoSize = true;
            this.labelStartLat.Location = new System.Drawing.Point(40, 37);
            this.labelStartLat.Name = "labelStartLat";
            this.labelStartLat.Size = new System.Drawing.Size(65, 12);
            this.labelStartLat.TabIndex = 2;
            this.labelStartLat.Text = "起点纬度：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.labelPointNum);
            this.groupBox1.Controls.Add(this.labelSpaceLenth);
            this.groupBox1.Controls.Add(this.labelGroundLenth);
            this.groupBox1.Controls.Add(this.labelSphereLenth);
            this.groupBox1.Controls.Add(this.labelEndAlt);
            this.groupBox1.Controls.Add(this.labelMinAlt);
            this.groupBox1.Controls.Add(this.labelMaxAlt);
            this.groupBox1.Controls.Add(this.labelStartAlt);
            this.groupBox1.Controls.Add(this.labelEndLat);
            this.groupBox1.Controls.Add(this.labelEndLon);
            this.groupBox1.Controls.Add(this.labelStartLat);
            this.groupBox1.Controls.Add(this.labelStartLon);
            this.groupBox1.Location = new System.Drawing.Point(11, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 105);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // labelStartLon
            // 
            this.labelStartLon.AutoSize = true;
            this.labelStartLon.Location = new System.Drawing.Point(40, 17);
            this.labelStartLon.Name = "labelStartLon";
            this.labelStartLon.Size = new System.Drawing.Size(65, 12);
            this.labelStartLon.TabIndex = 1;
            this.labelStartLon.Text = "起点经度：";
            // 
            // buttonAnalyse
            // 
            this.buttonAnalyse.Location = new System.Drawing.Point(454, 368);
            this.buttonAnalyse.Name = "buttonAnalyse";
            this.buttonAnalyse.Size = new System.Drawing.Size(59, 20);
            this.buttonAnalyse.TabIndex = 6;
            this.buttonAnalyse.Text = "分析";
            this.buttonAnalyse.UseVisualStyleBackColor = true;
            this.buttonAnalyse.Click += new System.EventHandler(this.buttonAnalyse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "基线高程";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(132, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "米";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(278, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "米";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(158, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "采样间距";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(427, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "个";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(304, 372);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "采样点数";
            // 
            // dataGridViewPoints
            // 
            this.dataGridViewPoints.AllowUserToAddRows = false;
            this.dataGridViewPoints.AllowUserToDeleteRows = false;
            this.dataGridViewPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.lon,
            this.lat,
            this.alt});
            this.dataGridViewPoints.Location = new System.Drawing.Point(14, 395);
            this.dataGridViewPoints.Name = "dataGridViewPoints";
            this.dataGridViewPoints.ReadOnly = true;
            this.dataGridViewPoints.RowTemplate.Height = 23;
            this.dataGridViewPoints.Size = new System.Drawing.Size(499, 129);
            this.dataGridViewPoints.TabIndex = 18;
            // 
            // number
            // 
            this.number.HeaderText = "序号";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            // 
            // lon
            // 
            this.lon.HeaderText = "经度";
            this.lon.Name = "lon";
            this.lon.ReadOnly = true;
            // 
            // lat
            // 
            this.lat.HeaderText = "纬度";
            this.lat.Name = "lat";
            this.lat.ReadOnly = true;
            // 
            // alt
            // 
            this.alt.HeaderText = "高程";
            this.alt.Name = "alt";
            this.alt.ReadOnly = true;
            // 
            // textBoxBaseAlt
            // 
            this.textBoxBaseAlt.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.textBoxBaseAlt.Location = new System.Drawing.Point(67, 367);
            this.textBoxBaseAlt.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxBaseAlt.Name = "textBoxBaseAlt";
            this.textBoxBaseAlt.Size = new System.Drawing.Size(63, 21);
            this.textBoxBaseAlt.TabIndex = 15;
            // 
            // textBoxJianJu
            // 
            this.textBoxJianJu.DecimalPlaces = 2;
            this.textBoxJianJu.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.textBoxJianJu.Location = new System.Drawing.Point(213, 367);
            this.textBoxJianJu.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textBoxJianJu.Name = "textBoxJianJu";
            this.textBoxJianJu.Size = new System.Drawing.Size(63, 21);
            this.textBoxJianJu.TabIndex = 20;
            // 
            // textBoxPointCount
            // 
            this.textBoxPointCount.Enabled = false;
            this.textBoxPointCount.Location = new System.Drawing.Point(360, 366);
            this.textBoxPointCount.Name = "textBoxPointCount";
            this.textBoxPointCount.Size = new System.Drawing.Size(63, 21);
            this.textBoxPointCount.TabIndex = 15;
            // 
            // FrmAnalysisProfileBaseLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 536);
            this.Controls.Add(this.textBoxPointCount);
            this.Controls.Add(this.textBoxJianJu);
            this.Controls.Add(this.textBoxBaseAlt);
            this.Controls.Add(this.dataGridViewPoints);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnalyse);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAnalysisProfileBaseLine";
            this.Text = "基线剖面分析";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseLineProfillAnalysis_FormClosed);
            this.Load += new System.EventHandler(this.BaseLineProfillAnalysis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxBaseAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxJianJu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelPointNum;
        private Label labelSpaceLenth;
        private Label labelGroundLenth;
        private Label labelSphereLenth;
        private Label labelEndAlt;
        private Label labelMinAlt;
        private Label labelMaxAlt;
        private Label labelStartAlt;
        private Label labelEndLat;
        private ZedGraphControl zedGraphControl1;
        private Label labelEndLon;
        private Label labelStartLat;
        private GroupBox groupBox1;
        private Label labelStartLon;
        private Button buttonAnalyse;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dataGridViewPoints;
        private DataGridViewTextBoxColumn number;
        private DataGridViewTextBoxColumn lon;
        private DataGridViewTextBoxColumn lat;
        private DataGridViewTextBoxColumn alt;
        private NumericUpDown textBoxBaseAlt;
        private NumericUpDown textBoxJianJu;
        private TextBox textBoxPointCount;
    }
}