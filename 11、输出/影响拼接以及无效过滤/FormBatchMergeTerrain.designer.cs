namespace WorldGIS
{
    partial class FormBatchMergeTerrain
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
            this.button_OK = new System.Windows.Forms.Button();
            this.label_totalProgress = new System.Windows.Forms.Label();
            this.progressBar_All = new System.Windows.Forms.ProgressBar();
            this.label_AllProcess = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_removeAll = new System.Windows.Forms.Button();
            this.button_AddData = new System.Windows.Forms.Button();
            this.button_AddDir = new System.Windows.Forms.Button();
            this.button_SavePath = new System.Windows.Forms.Button();
            this.textBox_savePath = new System.Windows.Forms.TextBox();
            this.panel_SvaPath = new System.Windows.Forms.Panel();
            this.button_removeSelect = new System.Windows.Forms.Button();
            this.panel_threadHold = new System.Windows.Forms.Panel();
            this.comboBox_FilterPolygon = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Threshod = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_NoValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_SvaPath.SuspendLayout();
            this.panel_threadHold.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(325, 501);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 41;
            this.button_OK.Text = "执行";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label_totalProgress
            // 
            this.label_totalProgress.AutoSize = true;
            this.label_totalProgress.Location = new System.Drawing.Point(455, 30);
            this.label_totalProgress.Name = "label_totalProgress";
            this.label_totalProgress.Size = new System.Drawing.Size(17, 12);
            this.label_totalProgress.TabIndex = 23;
            this.label_totalProgress.Text = "0%";
            // 
            // progressBar_All
            // 
            this.progressBar_All.Location = new System.Drawing.Point(94, 23);
            this.progressBar_All.Name = "progressBar_All";
            this.progressBar_All.Size = new System.Drawing.Size(358, 23);
            this.progressBar_All.TabIndex = 21;
            // 
            // label_AllProcess
            // 
            this.label_AllProcess.AutoSize = true;
            this.label_AllProcess.Location = new System.Drawing.Point(16, 30);
            this.label_AllProcess.Name = "label_AllProcess";
            this.label_AllProcess.Size = new System.Drawing.Size(65, 12);
            this.label_AllProcess.TabIndex = 19;
            this.label_AllProcess.Text = "处理进度：";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label_totalProgress);
            this.panel3.Controls.Add(this.progressBar_All);
            this.panel3.Controls.Add(this.label_AllProcess);
            this.panel3.Location = new System.Drawing.Point(11, 403);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(494, 76);
            this.panel3.TabIndex = 40;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(430, 501);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 42;
            this.button_Cancel.Text = "退出";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(11, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(404, 170);
            this.dataGridView1.TabIndex = 33;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "    文件名称";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "    投影信息";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "    存储路径";
            this.Column3.Name = "Column3";
            // 
            // button_removeAll
            // 
            this.button_removeAll.Location = new System.Drawing.Point(430, 153);
            this.button_removeAll.Name = "button_removeAll";
            this.button_removeAll.Size = new System.Drawing.Size(75, 23);
            this.button_removeAll.TabIndex = 37;
            this.button_removeAll.Text = "移除全部";
            this.button_removeAll.UseVisualStyleBackColor = true;
            this.button_removeAll.Click += new System.EventHandler(this.button_removeAll_Click);
            // 
            // button_AddData
            // 
            this.button_AddData.Location = new System.Drawing.Point(430, 6);
            this.button_AddData.Name = "button_AddData";
            this.button_AddData.Size = new System.Drawing.Size(75, 23);
            this.button_AddData.TabIndex = 34;
            this.button_AddData.Text = "添加数据";
            this.button_AddData.UseVisualStyleBackColor = true;
            this.button_AddData.Click += new System.EventHandler(this.button_AddData_Click);
            // 
            // button_AddDir
            // 
            this.button_AddDir.Location = new System.Drawing.Point(430, 54);
            this.button_AddDir.Name = "button_AddDir";
            this.button_AddDir.Size = new System.Drawing.Size(75, 23);
            this.button_AddDir.TabIndex = 35;
            this.button_AddDir.Text = "添加目录";
            this.button_AddDir.UseVisualStyleBackColor = true;
            this.button_AddDir.Click += new System.EventHandler(this.button_AddDir_Click);
            // 
            // button_SavePath
            // 
            this.button_SavePath.Location = new System.Drawing.Point(414, 18);
            this.button_SavePath.Name = "button_SavePath";
            this.button_SavePath.Size = new System.Drawing.Size(75, 23);
            this.button_SavePath.TabIndex = 16;
            this.button_SavePath.Text = "结果路径";
            this.button_SavePath.UseVisualStyleBackColor = true;
            this.button_SavePath.Click += new System.EventHandler(this.button_SavePath_Click);
            // 
            // textBox_savePath
            // 
            this.textBox_savePath.Location = new System.Drawing.Point(3, 18);
            this.textBox_savePath.Name = "textBox_savePath";
            this.textBox_savePath.Size = new System.Drawing.Size(396, 21);
            this.textBox_savePath.TabIndex = 15;
            // 
            // panel_SvaPath
            // 
            this.panel_SvaPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_SvaPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_SvaPath.Controls.Add(this.button_SavePath);
            this.panel_SvaPath.Controls.Add(this.textBox_savePath);
            this.panel_SvaPath.Location = new System.Drawing.Point(11, 193);
            this.panel_SvaPath.Name = "panel_SvaPath";
            this.panel_SvaPath.Size = new System.Drawing.Size(494, 67);
            this.panel_SvaPath.TabIndex = 38;
            // 
            // button_removeSelect
            // 
            this.button_removeSelect.Location = new System.Drawing.Point(430, 104);
            this.button_removeSelect.Name = "button_removeSelect";
            this.button_removeSelect.Size = new System.Drawing.Size(75, 23);
            this.button_removeSelect.TabIndex = 36;
            this.button_removeSelect.Text = "移除选中";
            this.button_removeSelect.UseVisualStyleBackColor = true;
            this.button_removeSelect.Click += new System.EventHandler(this.button_removeSelect_Click);
            // 
            // panel_threadHold
            // 
            this.panel_threadHold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_threadHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_threadHold.Controls.Add(this.comboBox_FilterPolygon);
            this.panel_threadHold.Controls.Add(this.label8);
            this.panel_threadHold.Controls.Add(this.label9);
            this.panel_threadHold.Controls.Add(this.textBox_Threshod);
            this.panel_threadHold.Controls.Add(this.checkBox2);
            this.panel_threadHold.Controls.Add(this.label10);
            this.panel_threadHold.Controls.Add(this.textBox_NoValue);
            this.panel_threadHold.Controls.Add(this.label11);
            this.panel_threadHold.Location = new System.Drawing.Point(11, 276);
            this.panel_threadHold.Name = "panel_threadHold";
            this.panel_threadHold.Size = new System.Drawing.Size(494, 111);
            this.panel_threadHold.TabIndex = 43;
            // 
            // comboBox_FilterPolygon
            // 
            this.comboBox_FilterPolygon.FormattingEnabled = true;
            this.comboBox_FilterPolygon.Items.AddRange(new object[] {
            "仅过滤重叠区域",
            "过滤全部区域"});
            this.comboBox_FilterPolygon.Location = new System.Drawing.Point(95, 70);
            this.comboBox_FilterPolygon.Name = "comboBox_FilterPolygon";
            this.comboBox_FilterPolygon.Size = new System.Drawing.Size(147, 20);
            this.comboBox_FilterPolygon.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "过滤区域：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(450, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "px";
            // 
            // textBox_Threshod
            // 
            this.textBox_Threshod.Location = new System.Drawing.Point(350, 19);
            this.textBox_Threshod.Name = "textBox_Threshod";
            this.textBox_Threshod.Size = new System.Drawing.Size(94, 21);
            this.textBox_Threshod.TabIndex = 16;
            this.textBox_Threshod.Text = "0";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(26, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(108, 16);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "启用无效值过滤";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(306, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "阈 值：";
            // 
            // textBox_NoValue
            // 
            this.textBox_NoValue.Location = new System.Drawing.Point(350, 70);
            this.textBox_NoValue.Name = "textBox_NoValue";
            this.textBox_NoValue.Size = new System.Drawing.Size(94, 21);
            this.textBox_NoValue.TabIndex = 4;
            this.textBox_NoValue.Text = "-9999";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(303, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "无效值：";
            // 
            // FormBatchMergeTerrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 545);
            this.Controls.Add(this.panel_threadHold);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_removeAll);
            this.Controls.Add(this.button_AddData);
            this.Controls.Add(this.button_AddDir);
            this.Controls.Add(this.panel_SvaPath);
            this.Controls.Add(this.button_removeSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormBatchMergeTerrain";
            this.Text = "地形拼接";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBatchMergeTerrain_FormClosing);
            this.Load += new System.EventHandler(this.FormBatchMergeTerrain_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_SvaPath.ResumeLayout(false);
            this.panel_SvaPath.PerformLayout();
            this.panel_threadHold.ResumeLayout(false);
            this.panel_threadHold.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label_totalProgress;
        private System.Windows.Forms.ProgressBar progressBar_All;
        private System.Windows.Forms.Label label_AllProcess;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button_removeAll;
        private System.Windows.Forms.Button button_AddData;
        private System.Windows.Forms.Button button_AddDir;
        private System.Windows.Forms.Button button_SavePath;
        private System.Windows.Forms.TextBox textBox_savePath;
        private System.Windows.Forms.Panel panel_SvaPath;
        private System.Windows.Forms.Button button_removeSelect;
        private System.Windows.Forms.Panel panel_threadHold;
        private System.Windows.Forms.ComboBox comboBox_FilterPolygon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Threshod;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_NoValue;
        private System.Windows.Forms.Label label11;
    }
}