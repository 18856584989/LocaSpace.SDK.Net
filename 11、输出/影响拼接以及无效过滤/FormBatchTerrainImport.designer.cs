namespace WorldGIS
{
    partial class FormBatchTerrainImport
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.panel_PolygonRestric = new System.Windows.Forms.Panel();
            this.comboBox_Model = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_polygonPath = new System.Windows.Forms.TextBox();
            this.button_polygon = new System.Windows.Forms.Button();
            this.panel_thread = new System.Windows.Forms.Panel();
            this.textBox_maxCacheSize = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_threadNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox_MulThread = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_subProgress = new System.Windows.Forms.Label();
            this.label_totalProgress = new System.Windows.Forms.Label();
            this.progressBar_Current = new System.Windows.Forms.ProgressBar();
            this.progressBar_All = new System.Windows.Forms.ProgressBar();
            this.label_CurrentProcess = new System.Windows.Forms.Label();
            this.label_AllProcess = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_SavaPath = new System.Windows.Forms.Button();
            this.checkBox_polygonRestricted = new System.Windows.Forms.CheckBox();
            this.panel_NoValue = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ThresholdValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox_B = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_G = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_R = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxNoValue = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_removeAll = new System.Windows.Forms.Button();
            this.button_removeSelect = new System.Windows.Forms.Button();
            this.button_AddDir = new System.Windows.Forms.Button();
            this.button_AddData = new System.Windows.Forms.Button();
            this.panel_PolygonRestric.SuspendLayout();
            this.panel_thread.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_NoValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(431, 506);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 33;
            this.button_Cancel.Text = "退出";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // panel_PolygonRestric
            // 
            this.panel_PolygonRestric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_PolygonRestric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_PolygonRestric.Controls.Add(this.comboBox_Model);
            this.panel_PolygonRestric.Controls.Add(this.label7);
            this.panel_PolygonRestric.Controls.Add(this.textBox_polygonPath);
            this.panel_PolygonRestric.Controls.Add(this.button_polygon);
            this.panel_PolygonRestric.Location = new System.Drawing.Point(12, 318);
            this.panel_PolygonRestric.Name = "panel_PolygonRestric";
            this.panel_PolygonRestric.Size = new System.Drawing.Size(248, 82);
            this.panel_PolygonRestric.TabIndex = 29;
            // 
            // comboBox_Model
            // 
            this.comboBox_Model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Model.FormattingEnabled = true;
            this.comboBox_Model.Items.AddRange(new object[] {
            "精确过滤",
            "粗略过滤"});
            this.comboBox_Model.Location = new System.Drawing.Point(93, 47);
            this.comboBox_Model.Name = "comboBox_Model";
            this.comboBox_Model.Size = new System.Drawing.Size(144, 20);
            this.comboBox_Model.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "过滤方式：";
            // 
            // textBox_polygonPath
            // 
            this.textBox_polygonPath.Location = new System.Drawing.Point(93, 13);
            this.textBox_polygonPath.Name = "textBox_polygonPath";
            this.textBox_polygonPath.Size = new System.Drawing.Size(144, 21);
            this.textBox_polygonPath.TabIndex = 16;
            // 
            // button_polygon
            // 
            this.button_polygon.Location = new System.Drawing.Point(7, 11);
            this.button_polygon.Name = "button_polygon";
            this.button_polygon.Size = new System.Drawing.Size(75, 23);
            this.button_polygon.TabIndex = 0;
            this.button_polygon.Text = "多边形数据";
            this.button_polygon.UseVisualStyleBackColor = true;
            // 
            // panel_thread
            // 
            this.panel_thread.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_thread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_thread.Controls.Add(this.textBox_maxCacheSize);
            this.panel_thread.Controls.Add(this.label9);
            this.panel_thread.Controls.Add(this.textBox_threadNum);
            this.panel_thread.Controls.Add(this.label8);
            this.panel_thread.Location = new System.Drawing.Point(285, 318);
            this.panel_thread.Name = "panel_thread";
            this.panel_thread.Size = new System.Drawing.Size(221, 82);
            this.panel_thread.TabIndex = 30;
            // 
            // textBox_maxCacheSize
            // 
            this.textBox_maxCacheSize.Location = new System.Drawing.Point(83, 46);
            this.textBox_maxCacheSize.Name = "textBox_maxCacheSize";
            this.textBox_maxCacheSize.Size = new System.Drawing.Size(129, 21);
            this.textBox_maxCacheSize.TabIndex = 20;
            this.textBox_maxCacheSize.Text = "100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "缓存(MB)：";
            // 
            // textBox_threadNum
            // 
            this.textBox_threadNum.Location = new System.Drawing.Point(83, 13);
            this.textBox_threadNum.Name = "textBox_threadNum";
            this.textBox_threadNum.Size = new System.Drawing.Size(129, 21);
            this.textBox_threadNum.TabIndex = 18;
            this.textBox_threadNum.Text = "30";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "线 程 数：";
            // 
            // checkBox_MulThread
            // 
            this.checkBox_MulThread.AutoSize = true;
            this.checkBox_MulThread.Checked = true;
            this.checkBox_MulThread.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_MulThread.Location = new System.Drawing.Point(285, 293);
            this.checkBox_MulThread.Name = "checkBox_MulThread";
            this.checkBox_MulThread.Size = new System.Drawing.Size(84, 16);
            this.checkBox_MulThread.TabIndex = 28;
            this.checkBox_MulThread.Text = "启用多线程";
            this.checkBox_MulThread.UseVisualStyleBackColor = true;
            this.checkBox_MulThread.CheckedChanged += new System.EventHandler(this.checkBox_MulThread_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label_subProgress);
            this.panel3.Controls.Add(this.label_totalProgress);
            this.panel3.Controls.Add(this.progressBar_Current);
            this.panel3.Controls.Add(this.progressBar_All);
            this.panel3.Controls.Add(this.label_CurrentProcess);
            this.panel3.Controls.Add(this.label_AllProcess);
            this.panel3.Location = new System.Drawing.Point(12, 409);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(494, 80);
            this.panel3.TabIndex = 31;
            // 
            // label_subProgress
            // 
            this.label_subProgress.AutoSize = true;
            this.label_subProgress.Location = new System.Drawing.Point(455, 54);
            this.label_subProgress.Name = "label_subProgress";
            this.label_subProgress.Size = new System.Drawing.Size(17, 12);
            this.label_subProgress.TabIndex = 24;
            this.label_subProgress.Text = "0%";
            // 
            // label_totalProgress
            // 
            this.label_totalProgress.AutoSize = true;
            this.label_totalProgress.Location = new System.Drawing.Point(455, 19);
            this.label_totalProgress.Name = "label_totalProgress";
            this.label_totalProgress.Size = new System.Drawing.Size(17, 12);
            this.label_totalProgress.TabIndex = 23;
            this.label_totalProgress.Text = "0%";
            // 
            // progressBar_Current
            // 
            this.progressBar_Current.Location = new System.Drawing.Point(94, 47);
            this.progressBar_Current.Name = "progressBar_Current";
            this.progressBar_Current.Size = new System.Drawing.Size(358, 23);
            this.progressBar_Current.TabIndex = 22;
            // 
            // progressBar_All
            // 
            this.progressBar_All.Location = new System.Drawing.Point(94, 12);
            this.progressBar_All.Name = "progressBar_All";
            this.progressBar_All.Size = new System.Drawing.Size(358, 23);
            this.progressBar_All.TabIndex = 21;
            // 
            // label_CurrentProcess
            // 
            this.label_CurrentProcess.AutoSize = true;
            this.label_CurrentProcess.Location = new System.Drawing.Point(9, 54);
            this.label_CurrentProcess.Name = "label_CurrentProcess";
            this.label_CurrentProcess.Size = new System.Drawing.Size(95, 12);
            this.label_CurrentProcess.TabIndex = 20;
            this.label_CurrentProcess.Text = "当前进度(0/0)：";
            // 
            // label_AllProcess
            // 
            this.label_AllProcess.AutoSize = true;
            this.label_AllProcess.Location = new System.Drawing.Point(10, 19);
            this.label_AllProcess.Name = "label_AllProcess";
            this.label_AllProcess.Size = new System.Drawing.Size(89, 12);
            this.label_AllProcess.TabIndex = 19;
            this.label_AllProcess.Text = "总进度(0.0s)：";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(320, 506);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 32;
            this.button_OK.Text = "执行";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_SavaPath
            // 
            this.button_SavaPath.Location = new System.Drawing.Point(431, 194);
            this.button_SavaPath.Name = "button_SavaPath";
            this.button_SavaPath.Size = new System.Drawing.Size(75, 23);
            this.button_SavaPath.TabIndex = 34;
            this.button_SavaPath.Text = "存储路径";
            this.button_SavaPath.UseVisualStyleBackColor = true;
            this.button_SavaPath.Click += new System.EventHandler(this.button_SavaPath_Click);
            // 
            // checkBox_polygonRestricted
            // 
            this.checkBox_polygonRestricted.AutoSize = true;
            this.checkBox_polygonRestricted.Location = new System.Drawing.Point(12, 294);
            this.checkBox_polygonRestricted.Name = "checkBox_polygonRestricted";
            this.checkBox_polygonRestricted.Size = new System.Drawing.Size(108, 16);
            this.checkBox_polygonRestricted.TabIndex = 27;
            this.checkBox_polygonRestricted.Text = "启用多边形过滤";
            this.checkBox_polygonRestricted.UseVisualStyleBackColor = true;
            this.checkBox_polygonRestricted.CheckedChanged += new System.EventHandler(this.checkBox_polygonRestricted_CheckedChanged);
            // 
            // panel_NoValue
            // 
            this.panel_NoValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_NoValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_NoValue.Controls.Add(this.label6);
            this.panel_NoValue.Controls.Add(this.textBox_ThresholdValue);
            this.panel_NoValue.Controls.Add(this.label5);
            this.panel_NoValue.Controls.Add(this.button5);
            this.panel_NoValue.Controls.Add(this.textBox_B);
            this.panel_NoValue.Controls.Add(this.label4);
            this.panel_NoValue.Controls.Add(this.textBox_G);
            this.panel_NoValue.Controls.Add(this.label3);
            this.panel_NoValue.Controls.Add(this.textBox_R);
            this.panel_NoValue.Controls.Add(this.label2);
            this.panel_NoValue.Controls.Add(this.label1);
            this.panel_NoValue.Location = new System.Drawing.Point(12, 251);
            this.panel_NoValue.Name = "panel_NoValue";
            this.panel_NoValue.Size = new System.Drawing.Size(494, 36);
            this.panel_NoValue.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(468, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "px";
            // 
            // textBox_ThresholdValue
            // 
            this.textBox_ThresholdValue.Location = new System.Drawing.Point(431, 7);
            this.textBox_ThresholdValue.Name = "textBox_ThresholdValue";
            this.textBox_ThresholdValue.Size = new System.Drawing.Size(31, 21);
            this.textBox_ThresholdValue.TabIndex = 16;
            this.textBox_ThresholdValue.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "阈值";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(281, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "自定义颜色";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox_B
            // 
            this.textBox_B.Location = new System.Drawing.Point(239, 5);
            this.textBox_B.Name = "textBox_B";
            this.textBox_B.Size = new System.Drawing.Size(31, 21);
            this.textBox_B.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "B:";
            // 
            // textBox_G
            // 
            this.textBox_G.Location = new System.Drawing.Point(173, 5);
            this.textBox_G.Name = "textBox_G";
            this.textBox_G.Size = new System.Drawing.Size(31, 21);
            this.textBox_G.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "G:";
            // 
            // textBox_R
            // 
            this.textBox_R.Location = new System.Drawing.Point(110, 5);
            this.textBox_R.Name = "textBox_R";
            this.textBox_R.Size = new System.Drawing.Size(31, 21);
            this.textBox_R.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "R:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "无效值(RGB)";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "    文件路径";
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
            // checkBoxNoValue
            // 
            this.checkBoxNoValue.AutoSize = true;
            this.checkBoxNoValue.Location = new System.Drawing.Point(13, 227);
            this.checkBoxNoValue.Name = "checkBoxNoValue";
            this.checkBoxNoValue.Size = new System.Drawing.Size(108, 16);
            this.checkBoxNoValue.TabIndex = 25;
            this.checkBoxNoValue.Text = "启用无效值过滤";
            this.checkBoxNoValue.UseVisualStyleBackColor = true;
            this.checkBoxNoValue.CheckedChanged += new System.EventHandler(this.checkBoxNoValue_CheckedChanged);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(404, 208);
            this.dataGridView1.TabIndex = 24;
            // 
            // button_removeAll
            // 
            this.button_removeAll.Location = new System.Drawing.Point(431, 150);
            this.button_removeAll.Name = "button_removeAll";
            this.button_removeAll.Size = new System.Drawing.Size(75, 23);
            this.button_removeAll.TabIndex = 23;
            this.button_removeAll.Text = "移除全部";
            this.button_removeAll.UseVisualStyleBackColor = true;
            this.button_removeAll.Click += new System.EventHandler(this.button_removeAll_Click);
            // 
            // button_removeSelect
            // 
            this.button_removeSelect.Location = new System.Drawing.Point(431, 106);
            this.button_removeSelect.Name = "button_removeSelect";
            this.button_removeSelect.Size = new System.Drawing.Size(75, 23);
            this.button_removeSelect.TabIndex = 22;
            this.button_removeSelect.Text = "移除选中";
            this.button_removeSelect.UseVisualStyleBackColor = true;
            this.button_removeSelect.Click += new System.EventHandler(this.button_removeSelect_Click);
            // 
            // button_AddDir
            // 
            this.button_AddDir.Location = new System.Drawing.Point(431, 62);
            this.button_AddDir.Name = "button_AddDir";
            this.button_AddDir.Size = new System.Drawing.Size(75, 23);
            this.button_AddDir.TabIndex = 21;
            this.button_AddDir.Text = "添加目录";
            this.button_AddDir.UseVisualStyleBackColor = true;
            this.button_AddDir.Click += new System.EventHandler(this.button_AddDir_Click);
            // 
            // button_AddData
            // 
            this.button_AddData.Location = new System.Drawing.Point(431, 18);
            this.button_AddData.Name = "button_AddData";
            this.button_AddData.Size = new System.Drawing.Size(75, 23);
            this.button_AddData.TabIndex = 20;
            this.button_AddData.Text = "添加数据";
            this.button_AddData.UseVisualStyleBackColor = true;
            this.button_AddData.Click += new System.EventHandler(this.button_AddData_Click);
            // 
            // FormBatchTerrainImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 540);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.panel_PolygonRestric);
            this.Controls.Add(this.panel_thread);
            this.Controls.Add(this.checkBox_MulThread);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_SavaPath);
            this.Controls.Add(this.checkBox_polygonRestricted);
            this.Controls.Add(this.panel_NoValue);
            this.Controls.Add(this.checkBoxNoValue);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_removeAll);
            this.Controls.Add(this.button_removeSelect);
            this.Controls.Add(this.button_AddDir);
            this.Controls.Add(this.button_AddData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormBatchTerrainImport";
            this.Text = "批量导入地形数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBatchTerrainImport_FormClosing);
            this.Load += new System.EventHandler(this.FormBatchTerrainImport_Load);
            this.panel_PolygonRestric.ResumeLayout(false);
            this.panel_PolygonRestric.PerformLayout();
            this.panel_thread.ResumeLayout(false);
            this.panel_thread.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_NoValue.ResumeLayout(false);
            this.panel_NoValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Panel panel_PolygonRestric;
        private System.Windows.Forms.ComboBox comboBox_Model;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_polygonPath;
        private System.Windows.Forms.Button button_polygon;
        private System.Windows.Forms.Panel panel_thread;
        private System.Windows.Forms.TextBox textBox_maxCacheSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_threadNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox_MulThread;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_subProgress;
        private System.Windows.Forms.Label label_totalProgress;
        private System.Windows.Forms.ProgressBar progressBar_Current;
        private System.Windows.Forms.ProgressBar progressBar_All;
        private System.Windows.Forms.Label label_CurrentProcess;
        private System.Windows.Forms.Label label_AllProcess;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_SavaPath;
        private System.Windows.Forms.CheckBox checkBox_polygonRestricted;
        private System.Windows.Forms.Panel panel_NoValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ThresholdValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox_B;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_G;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_R;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.CheckBox checkBoxNoValue;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_removeAll;
        private System.Windows.Forms.Button button_removeSelect;
        private System.Windows.Forms.Button button_AddDir;
        private System.Windows.Forms.Button button_AddData;
    }
}