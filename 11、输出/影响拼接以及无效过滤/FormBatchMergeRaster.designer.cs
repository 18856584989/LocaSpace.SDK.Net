namespace WorldGIS
{
    partial class FormBatchMergeRaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_AddData = new System.Windows.Forms.Button();
            this.button_removeAll = new System.Windows.Forms.Button();
            this.button_removeSelect = new System.Windows.Forms.Button();
            this.button_AddDir = new System.Windows.Forms.Button();
            this.textBox_SavePath = new System.Windows.Forms.TextBox();
            this.button_SavePath = new System.Windows.Forms.Button();
            this.panel_SvaPath = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_totalProgress = new System.Windows.Forms.Label();
            this.progressBar_All = new System.Windows.Forms.ProgressBar();
            this.label_AllProcess = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.panel_NoValue = new System.Windows.Forms.Panel();
            this.comboBox_FilterPolygon = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ThresholdValue = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_setColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_B = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_G = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_R = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_SvaPath.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_NoValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(404, 170);
            this.dataGridView1.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "    数据路径";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "    投影信息";
            this.Column2.Name = "Column2";
            // 
            // button_AddData
            // 
            this.button_AddData.Location = new System.Drawing.Point(431, 6);
            this.button_AddData.Name = "button_AddData";
            this.button_AddData.Size = new System.Drawing.Size(75, 23);
            this.button_AddData.TabIndex = 11;
            this.button_AddData.Text = "添加数据";
            this.button_AddData.UseVisualStyleBackColor = true;
            this.button_AddData.Click += new System.EventHandler(this.button_AddData_Click);
            // 
            // button_removeAll
            // 
            this.button_removeAll.Location = new System.Drawing.Point(431, 153);
            this.button_removeAll.Name = "button_removeAll";
            this.button_removeAll.Size = new System.Drawing.Size(75, 23);
            this.button_removeAll.TabIndex = 14;
            this.button_removeAll.Text = "移除全部";
            this.button_removeAll.UseVisualStyleBackColor = true;
            this.button_removeAll.Click += new System.EventHandler(this.button_removeAll_Click);
            // 
            // button_removeSelect
            // 
            this.button_removeSelect.Location = new System.Drawing.Point(431, 104);
            this.button_removeSelect.Name = "button_removeSelect";
            this.button_removeSelect.Size = new System.Drawing.Size(75, 23);
            this.button_removeSelect.TabIndex = 13;
            this.button_removeSelect.Text = "移除选中";
            this.button_removeSelect.UseVisualStyleBackColor = true;
            this.button_removeSelect.Click += new System.EventHandler(this.button_removeSelect_Click);
            // 
            // button_AddDir
            // 
            this.button_AddDir.Location = new System.Drawing.Point(431, 54);
            this.button_AddDir.Name = "button_AddDir";
            this.button_AddDir.Size = new System.Drawing.Size(75, 23);
            this.button_AddDir.TabIndex = 12;
            this.button_AddDir.Text = "添加目录";
            this.button_AddDir.UseVisualStyleBackColor = true;
            this.button_AddDir.Click += new System.EventHandler(this.button_AddDir_Click);
            // 
            // textBox_SavePath
            // 
            this.textBox_SavePath.Location = new System.Drawing.Point(3, 21);
            this.textBox_SavePath.Name = "textBox_SavePath";
            this.textBox_SavePath.Size = new System.Drawing.Size(396, 21);
            this.textBox_SavePath.TabIndex = 15;
            // 
            // button_SavePath
            // 
            this.button_SavePath.Location = new System.Drawing.Point(414, 21);
            this.button_SavePath.Name = "button_SavePath";
            this.button_SavePath.Size = new System.Drawing.Size(75, 23);
            this.button_SavePath.TabIndex = 16;
            this.button_SavePath.Text = "结果路径";
            this.button_SavePath.UseVisualStyleBackColor = true;
            this.button_SavePath.Click += new System.EventHandler(this.button_SavePath_Click);
            // 
            // panel_SvaPath
            // 
            this.panel_SvaPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_SvaPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_SvaPath.Controls.Add(this.button_SavePath);
            this.panel_SvaPath.Controls.Add(this.textBox_SavePath);
            this.panel_SvaPath.Location = new System.Drawing.Point(12, 193);
            this.panel_SvaPath.Name = "panel_SvaPath";
            this.panel_SvaPath.Size = new System.Drawing.Size(494, 67);
            this.panel_SvaPath.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label_totalProgress);
            this.panel3.Controls.Add(this.progressBar_All);
            this.panel3.Controls.Add(this.label_AllProcess);
            this.panel3.Location = new System.Drawing.Point(12, 403);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(494, 76);
            this.panel3.TabIndex = 30;
            // 
            // label_totalProgress
            // 
            this.label_totalProgress.AutoSize = true;
            this.label_totalProgress.Location = new System.Drawing.Point(455, 33);
            this.label_totalProgress.Name = "label_totalProgress";
            this.label_totalProgress.Size = new System.Drawing.Size(17, 12);
            this.label_totalProgress.TabIndex = 23;
            this.label_totalProgress.Text = "0%";
            // 
            // progressBar_All
            // 
            this.progressBar_All.Location = new System.Drawing.Point(94, 26);
            this.progressBar_All.Name = "progressBar_All";
            this.progressBar_All.Size = new System.Drawing.Size(358, 23);
            this.progressBar_All.TabIndex = 21;
            // 
            // label_AllProcess
            // 
            this.label_AllProcess.AutoSize = true;
            this.label_AllProcess.Location = new System.Drawing.Point(16, 33);
            this.label_AllProcess.Name = "label_AllProcess";
            this.label_AllProcess.Size = new System.Drawing.Size(65, 12);
            this.label_AllProcess.TabIndex = 19;
            this.label_AllProcess.Text = "处理进度：";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(431, 501);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 32;
            this.button_Cancel.Text = "退出";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(326, 501);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 31;
            this.button_OK.Text = "执行";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // panel_NoValue
            // 
            this.panel_NoValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_NoValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_NoValue.Controls.Add(this.comboBox_FilterPolygon);
            this.panel_NoValue.Controls.Add(this.label7);
            this.panel_NoValue.Controls.Add(this.label6);
            this.panel_NoValue.Controls.Add(this.textBox_ThresholdValue);
            this.panel_NoValue.Controls.Add(this.checkBox1);
            this.panel_NoValue.Controls.Add(this.button_setColor);
            this.panel_NoValue.Controls.Add(this.label5);
            this.panel_NoValue.Controls.Add(this.textBox_B);
            this.panel_NoValue.Controls.Add(this.label4);
            this.panel_NoValue.Controls.Add(this.textBox_G);
            this.panel_NoValue.Controls.Add(this.label3);
            this.panel_NoValue.Controls.Add(this.textBox_R);
            this.panel_NoValue.Controls.Add(this.label2);
            this.panel_NoValue.Controls.Add(this.label1);
            this.panel_NoValue.Location = new System.Drawing.Point(12, 276);
            this.panel_NoValue.Name = "panel_NoValue";
            this.panel_NoValue.Size = new System.Drawing.Size(494, 111);
            this.panel_NoValue.TabIndex = 40;
            // 
            // comboBox_FilterPolygon
            // 
            this.comboBox_FilterPolygon.FormattingEnabled = true;
            this.comboBox_FilterPolygon.Items.AddRange(new object[] {
            "仅过滤重叠区域",
            "过滤全部区域"});
            this.comboBox_FilterPolygon.Location = new System.Drawing.Point(83, 67);
            this.comboBox_FilterPolygon.Name = "comboBox_FilterPolygon";
            this.comboBox_FilterPolygon.Size = new System.Drawing.Size(210, 20);
            this.comboBox_FilterPolygon.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "过滤区域：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(451, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "px";
            // 
            // textBox_ThresholdValue
            // 
            this.textBox_ThresholdValue.Location = new System.Drawing.Point(386, 67);
            this.textBox_ThresholdValue.Name = "textBox_ThresholdValue";
            this.textBox_ThresholdValue.Size = new System.Drawing.Size(59, 21);
            this.textBox_ThresholdValue.TabIndex = 16;
            this.textBox_ThresholdValue.Text = "10";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "启用无效值过滤";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button_setColor
            // 
            this.button_setColor.Location = new System.Drawing.Point(414, 12);
            this.button_setColor.Name = "button_setColor";
            this.button_setColor.Size = new System.Drawing.Size(75, 23);
            this.button_setColor.TabIndex = 14;
            this.button_setColor.Text = "自定义颜色";
            this.button_setColor.UseVisualStyleBackColor = true;
            this.button_setColor.Click += new System.EventHandler(this.button_setColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "阈值：";
            // 
            // textBox_B
            // 
            this.textBox_B.Location = new System.Drawing.Point(369, 14);
            this.textBox_B.Name = "textBox_B";
            this.textBox_B.Size = new System.Drawing.Size(31, 21);
            this.textBox_B.TabIndex = 13;
            this.textBox_B.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "B：";
            // 
            // textBox_G
            // 
            this.textBox_G.Location = new System.Drawing.Point(316, 14);
            this.textBox_G.Name = "textBox_G";
            this.textBox_G.Size = new System.Drawing.Size(31, 21);
            this.textBox_G.TabIndex = 12;
            this.textBox_G.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "G：";
            // 
            // textBox_R
            // 
            this.textBox_R.Location = new System.Drawing.Point(262, 14);
            this.textBox_R.Name = "textBox_R";
            this.textBox_R.Size = new System.Drawing.Size(31, 21);
            this.textBox_R.TabIndex = 4;
            this.textBox_R.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "R：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "无效值(RGB)：";
            // 
            // FormBatchMergeRaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 540);
            this.Controls.Add(this.panel_NoValue);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel_SvaPath);
            this.Controls.Add(this.button_removeAll);
            this.Controls.Add(this.button_removeSelect);
            this.Controls.Add(this.button_AddDir);
            this.Controls.Add(this.button_AddData);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormBatchMergeRaster";
            this.ShowIcon = false;
            this.Text = "影像拼接";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBatchMergeRaster_FormClosing);
            this.Load += new System.EventHandler(this.FormBatchMergeRaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_SvaPath.ResumeLayout(false);
            this.panel_SvaPath.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_NoValue.ResumeLayout(false);
            this.panel_NoValue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_AddData;
        private System.Windows.Forms.Button button_removeAll;
        private System.Windows.Forms.Button button_removeSelect;
        private System.Windows.Forms.Button button_AddDir;
        private System.Windows.Forms.TextBox textBox_SavePath;
        private System.Windows.Forms.Button button_SavePath;
        private System.Windows.Forms.Panel panel_SvaPath;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_totalProgress;
        private System.Windows.Forms.ProgressBar progressBar_All;
        private System.Windows.Forms.Label label_AllProcess;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Panel panel_NoValue;
        private System.Windows.Forms.ComboBox comboBox_FilterPolygon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ThresholdValue;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button_setColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_B;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_G;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_R;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}