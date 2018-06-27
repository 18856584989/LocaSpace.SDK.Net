using System.ComponentModel;
using System.Windows.Forms;

namespace 淹没模拟.淹没模拟
{
    partial class FrmAnalysisFloodSubmerge
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
            this.labelFloodArea = new System.Windows.Forms.Label();
            this.textBoxFloodArea = new System.Windows.Forms.TextBox();
            this.labelTotalArea = new System.Windows.Forms.Label();
            this.textBoxTotalArea = new System.Windows.Forms.TextBox();
            this.labelPntMax = new System.Windows.Forms.Label();
            this.textBoxPntMax = new System.Windows.Forms.TextBox();
            this.textBoxPntMin = new System.Windows.Forms.TextBox();
            this.labelPntMin = new System.Windows.Forms.Label();
            this.textBoxWaterAlt = new System.Windows.Forms.TextBox();
            this.labelWaterAlt = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.trackBarAlt = new System.Windows.Forms.TrackBar();
            this.checkBoxExtrude = new System.Windows.Forms.CheckBox();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.labelAddPerTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFrequency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxLoopPlay = new System.Windows.Forms.CheckBox();
            this.numericUpDownAddPerTime = new System.Windows.Forms.NumericUpDown();
            this.buttonSetPlayParam = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonReplay = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlt)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAddPerTime)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFloodArea
            // 
            this.labelFloodArea.AutoSize = true;
            this.labelFloodArea.BackColor = System.Drawing.Color.Transparent;
            this.labelFloodArea.Location = new System.Drawing.Point(23, 109);
            this.labelFloodArea.Name = "labelFloodArea";
            this.labelFloodArea.Size = new System.Drawing.Size(65, 12);
            this.labelFloodArea.TabIndex = 0;
            this.labelFloodArea.Text = "淹没面积：";
            // 
            // textBoxFloodArea
            // 
            this.textBoxFloodArea.Location = new System.Drawing.Point(100, 106);
            this.textBoxFloodArea.Name = "textBoxFloodArea";
            this.textBoxFloodArea.ReadOnly = true;
            this.textBoxFloodArea.Size = new System.Drawing.Size(302, 21);
            this.textBoxFloodArea.TabIndex = 1;
            // 
            // labelTotalArea
            // 
            this.labelTotalArea.AutoSize = true;
            this.labelTotalArea.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalArea.Location = new System.Drawing.Point(23, 80);
            this.labelTotalArea.Name = "labelTotalArea";
            this.labelTotalArea.Size = new System.Drawing.Size(65, 12);
            this.labelTotalArea.TabIndex = 2;
            this.labelTotalArea.Text = "区域面积：";
            // 
            // textBoxTotalArea
            // 
            this.textBoxTotalArea.Location = new System.Drawing.Point(100, 77);
            this.textBoxTotalArea.Name = "textBoxTotalArea";
            this.textBoxTotalArea.ReadOnly = true;
            this.textBoxTotalArea.Size = new System.Drawing.Size(302, 21);
            this.textBoxTotalArea.TabIndex = 3;
            // 
            // labelPntMax
            // 
            this.labelPntMax.AutoSize = true;
            this.labelPntMax.BackColor = System.Drawing.Color.Transparent;
            this.labelPntMax.Location = new System.Drawing.Point(23, 23);
            this.labelPntMax.Name = "labelPntMax";
            this.labelPntMax.Size = new System.Drawing.Size(53, 12);
            this.labelPntMax.TabIndex = 4;
            this.labelPntMax.Text = "最高点：";
            // 
            // textBoxPntMax
            // 
            this.textBoxPntMax.Location = new System.Drawing.Point(100, 20);
            this.textBoxPntMax.Name = "textBoxPntMax";
            this.textBoxPntMax.ReadOnly = true;
            this.textBoxPntMax.Size = new System.Drawing.Size(302, 21);
            this.textBoxPntMax.TabIndex = 5;
            // 
            // textBoxPntMin
            // 
            this.textBoxPntMin.Location = new System.Drawing.Point(100, 48);
            this.textBoxPntMin.Name = "textBoxPntMin";
            this.textBoxPntMin.ReadOnly = true;
            this.textBoxPntMin.Size = new System.Drawing.Size(302, 21);
            this.textBoxPntMin.TabIndex = 7;
            // 
            // labelPntMin
            // 
            this.labelPntMin.AutoSize = true;
            this.labelPntMin.BackColor = System.Drawing.Color.Transparent;
            this.labelPntMin.Location = new System.Drawing.Point(23, 51);
            this.labelPntMin.Name = "labelPntMin";
            this.labelPntMin.Size = new System.Drawing.Size(53, 12);
            this.labelPntMin.TabIndex = 6;
            this.labelPntMin.Text = "最低点：";
            // 
            // textBoxWaterAlt
            // 
            this.textBoxWaterAlt.BackColor = System.Drawing.Color.White;
            this.textBoxWaterAlt.Location = new System.Drawing.Point(290, 315);
            this.textBoxWaterAlt.Name = "textBoxWaterAlt";
            this.textBoxWaterAlt.Size = new System.Drawing.Size(64, 21);
            this.textBoxWaterAlt.TabIndex = 9;
            this.textBoxWaterAlt.Text = "0";
            // 
            // labelWaterAlt
            // 
            this.labelWaterAlt.AutoSize = true;
            this.labelWaterAlt.Location = new System.Drawing.Point(211, 320);
            this.labelWaterAlt.Name = "labelWaterAlt";
            this.labelWaterAlt.Size = new System.Drawing.Size(65, 12);
            this.labelWaterAlt.TabIndex = 8;
            this.labelWaterAlt.Text = "水面高度：";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(33, 25);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(80, 25);
            this.buttonPlay.TabIndex = 11;
            this.buttonPlay.Text = "淹没演示";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // trackBarAlt
            // 
            this.trackBarAlt.Location = new System.Drawing.Point(33, 72);
            this.trackBarAlt.Maximum = 100;
            this.trackBarAlt.Name = "trackBarAlt";
            this.trackBarAlt.Size = new System.Drawing.Size(321, 45);
            this.trackBarAlt.TabIndex = 12;
            this.trackBarAlt.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarAlt.Scroll += new System.EventHandler(this.trackBarAlt_Scroll);
            // 
            // checkBoxExtrude
            // 
            this.checkBoxExtrude.AutoSize = true;
            this.checkBoxExtrude.Checked = true;
            this.checkBoxExtrude.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExtrude.Location = new System.Drawing.Point(52, 318);
            this.checkBoxExtrude.Name = "checkBoxExtrude";
            this.checkBoxExtrude.Size = new System.Drawing.Size(132, 16);
            this.checkBoxExtrude.TabIndex = 13;
            this.checkBoxExtrude.Text = "水面边界延伸到地面";
            this.checkBoxExtrude.UseVisualStyleBackColor = true;
            this.checkBoxExtrude.CheckedChanged += new System.EventHandler(this.checkBoxExtrude_CheckedChanged);
            // 
            // timerPlay
            // 
            this.timerPlay.Interval = 50;
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // labelAddPerTime
            // 
            this.labelAddPerTime.AutoSize = true;
            this.labelAddPerTime.BackColor = System.Drawing.Color.Transparent;
            this.labelAddPerTime.Location = new System.Drawing.Point(83, 49);
            this.labelAddPerTime.Name = "labelAddPerTime";
            this.labelAddPerTime.Size = new System.Drawing.Size(65, 12);
            this.labelAddPerTime.TabIndex = 15;
            this.labelAddPerTime.Text = "每次升高：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(247, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "米";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(362, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "米";
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.BackColor = System.Drawing.Color.White;
            this.textBoxFrequency.Location = new System.Drawing.Point(160, 18);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.Size = new System.Drawing.Size(80, 21);
            this.textBoxFrequency.TabIndex = 18;
            this.textBoxFrequency.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(83, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "播放频率：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(246, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "次/每秒";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxLoopPlay);
            this.groupBox1.Controls.Add(this.numericUpDownAddPerTime);
            this.groupBox1.Controls.Add(this.buttonSetPlayParam);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxFrequency);
            this.groupBox1.Controls.Add(this.trackBarAlt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelAddPerTime);
            this.groupBox1.Location = new System.Drawing.Point(25, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxLoopPlay
            // 
            this.checkBoxLoopPlay.AutoSize = true;
            this.checkBoxLoopPlay.Location = new System.Drawing.Point(179, 112);
            this.checkBoxLoopPlay.Name = "checkBoxLoopPlay";
            this.checkBoxLoopPlay.Size = new System.Drawing.Size(72, 16);
            this.checkBoxLoopPlay.TabIndex = 25;
            this.checkBoxLoopPlay.Text = "循环播放";
            this.checkBoxLoopPlay.UseVisualStyleBackColor = true;
            // 
            // numericUpDownAddPerTime
            // 
            this.numericUpDownAddPerTime.BackColor = System.Drawing.Color.White;
            this.numericUpDownAddPerTime.DecimalPlaces = 2;
            this.numericUpDownAddPerTime.ForeColor = System.Drawing.Color.Black;
            this.numericUpDownAddPerTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownAddPerTime.Location = new System.Drawing.Point(160, 45);
            this.numericUpDownAddPerTime.Name = "numericUpDownAddPerTime";
            this.numericUpDownAddPerTime.Size = new System.Drawing.Size(80, 21);
            this.numericUpDownAddPerTime.TabIndex = 21;
            this.numericUpDownAddPerTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownAddPerTime.ValueChanged += new System.EventHandler(this.numericUpDownAddPerTime_ValueChanged);
            // 
            // buttonSetPlayParam
            // 
            this.buttonSetPlayParam.Location = new System.Drawing.Point(265, 108);
            this.buttonSetPlayParam.Name = "buttonSetPlayParam";
            this.buttonSetPlayParam.Size = new System.Drawing.Size(64, 23);
            this.buttonSetPlayParam.TabIndex = 22;
            this.buttonSetPlayParam.Text = "推荐参数";
            this.buttonSetPlayParam.UseVisualStyleBackColor = true;
            this.buttonSetPlayParam.Click += new System.EventHandler(this.buttonSetPlayParam_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(152, 25);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(80, 25);
            this.buttonStop.TabIndex = 18;
            this.buttonStop.Text = "暂停演示";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonReplay
            // 
            this.buttonReplay.Location = new System.Drawing.Point(271, 25);
            this.buttonReplay.Name = "buttonReplay";
            this.buttonReplay.Size = new System.Drawing.Size(80, 25);
            this.buttonReplay.TabIndex = 23;
            this.buttonReplay.Text = "重新演示";
            this.buttonReplay.UseVisualStyleBackColor = true;
            this.buttonReplay.Click += new System.EventHandler(this.buttonReplay_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonReplay);
            this.groupBox2.Controls.Add(this.buttonStop);
            this.groupBox2.Controls.Add(this.buttonPlay);
            this.groupBox2.Location = new System.Drawing.Point(19, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 69);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // FrmAnalysisFloodSubmerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 466);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxExtrude);
            this.Controls.Add(this.textBoxWaterAlt);
            this.Controls.Add(this.labelWaterAlt);
            this.Controls.Add(this.textBoxPntMin);
            this.Controls.Add(this.labelPntMin);
            this.Controls.Add(this.textBoxPntMax);
            this.Controls.Add(this.labelPntMax);
            this.Controls.Add(this.textBoxTotalArea);
            this.Controls.Add(this.labelTotalArea);
            this.Controls.Add(this.textBoxFloodArea);
            this.Controls.Add(this.labelFloodArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAnalysisFloodSubmerge";
            this.Text = "淹没分析";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAnalysisFloodSubmerge_FormClosing);
            this.Load += new System.EventHandler(this.FloodSubmergeAnalysisDlg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAddPerTime)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelFloodArea;
        private TextBox textBoxFloodArea;
        private Label labelTotalArea;
        private TextBox textBoxTotalArea;
        private Label labelPntMax;
        private TextBox textBoxPntMax;
        private TextBox textBoxPntMin;
        private Label labelPntMin;
        private TextBox textBoxWaterAlt;
        private Label labelWaterAlt;
        private Button buttonPlay;
        private TrackBar trackBarAlt;
        private CheckBox checkBoxExtrude;
        private Timer timerPlay;
        private Label labelAddPerTime;
        private Label label1;
        private Label label2;
        private TextBox textBoxFrequency;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private NumericUpDown numericUpDownAddPerTime;
        private Button buttonStop;
        private Button buttonSetPlayParam;
        private Button buttonReplay;
        private GroupBox groupBox2;
        private CheckBox checkBoxLoopPlay;
    }
}