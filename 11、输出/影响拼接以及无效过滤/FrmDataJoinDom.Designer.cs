namespace WorldGIS
{
    partial class FrmDataJoinDom
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
            this.dataGridViewDomList = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domPath_old = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddData = new System.Windows.Forms.Button();
            this.buttonAddDataByDirectory = new System.Windows.Forms.Button();
            this.buttonRemoveSelect = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.labelProcess = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxUsingFilter = new System.Windows.Forms.CheckBox();
            this.buttonOutputPath = new System.Windows.Forms.Button();
            this.textBoxOutputPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFilterSetting = new System.Windows.Forms.Panel();
            this.textBoxImageNoValue = new System.Windows.Forms.TextBox();
            this.comboBoxFilterRegion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelProcess = new System.Windows.Forms.Panel();
            this.progressBarAll = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDomList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelFilterSetting.SuspendLayout();
            this.panelProcess.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDomList
            // 
            this.dataGridViewDomList.AllowUserToAddRows = false;
            this.dataGridViewDomList.AllowUserToDeleteRows = false;
            this.dataGridViewDomList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDomList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.domPath_old,
            this.proj});
            this.dataGridViewDomList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDomList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDomList.Name = "dataGridViewDomList";
            this.dataGridViewDomList.ReadOnly = true;
            this.dataGridViewDomList.RowHeadersVisible = false;
            this.dataGridViewDomList.RowTemplate.Height = 23;
            this.dataGridViewDomList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDomList.Size = new System.Drawing.Size(542, 345);
            this.dataGridViewDomList.TabIndex = 0;
            // 
            // number
            // 
            this.number.HeaderText = "序号";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 70;
            // 
            // domPath_old
            // 
            this.domPath_old.HeaderText = "原数据路径";
            this.domPath_old.Name = "domPath_old";
            this.domPath_old.ReadOnly = true;
            this.domPath_old.Width = 300;
            // 
            // proj
            // 
            this.proj.HeaderText = "原数据投影信息";
            this.proj.Name = "proj";
            this.proj.ReadOnly = true;
            this.proj.Width = 150;
            // 
            // buttonAddData
            // 
            this.buttonAddData.Location = new System.Drawing.Point(14, 12);
            this.buttonAddData.Name = "buttonAddData";
            this.buttonAddData.Size = new System.Drawing.Size(75, 23);
            this.buttonAddData.TabIndex = 1;
            this.buttonAddData.Text = "添加数据";
            this.buttonAddData.UseVisualStyleBackColor = true;
            this.buttonAddData.Click += new System.EventHandler(this.buttonAddData_Click);
            // 
            // buttonAddDataByDirectory
            // 
            this.buttonAddDataByDirectory.Location = new System.Drawing.Point(14, 57);
            this.buttonAddDataByDirectory.Name = "buttonAddDataByDirectory";
            this.buttonAddDataByDirectory.Size = new System.Drawing.Size(75, 23);
            this.buttonAddDataByDirectory.TabIndex = 2;
            this.buttonAddDataByDirectory.Text = "添加目录";
            this.buttonAddDataByDirectory.UseVisualStyleBackColor = true;
            this.buttonAddDataByDirectory.Click += new System.EventHandler(this.buttonAddDataByDirectory_Click);
            // 
            // buttonRemoveSelect
            // 
            this.buttonRemoveSelect.Location = new System.Drawing.Point(14, 101);
            this.buttonRemoveSelect.Name = "buttonRemoveSelect";
            this.buttonRemoveSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveSelect.TabIndex = 3;
            this.buttonRemoveSelect.Text = "移除选中";
            this.buttonRemoveSelect.UseVisualStyleBackColor = true;
            this.buttonRemoveSelect.Click += new System.EventHandler(this.buttonRemoveSelect_Click);
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(14, 144);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveAll.TabIndex = 4;
            this.buttonRemoveAll.Text = "移除全部";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Location = new System.Drawing.Point(22, 7);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(65, 12);
            this.labelProcess.TabIndex = 8;
            this.labelProcess.Text = "总进度[0%]";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(325, 212);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(448, 212);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddData);
            this.panel1.Controls.Add(this.buttonAddDataByDirectory);
            this.panel1.Controls.Add(this.buttonRemoveSelect);
            this.panel1.Controls.Add(this.buttonRemoveAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(542, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 592);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxUsingFilter);
            this.panel2.Controls.Add(this.buttonOutputPath);
            this.panel2.Controls.Add(this.textBoxOutputPath);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panelFilterSetting);
            this.panel2.Controls.Add(this.panelProcess);
            this.panel2.Controls.Add(this.buttonOK);
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 345);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 247);
            this.panel2.TabIndex = 12;
            // 
            // checkBoxUsingFilter
            // 
            this.checkBoxUsingFilter.AutoSize = true;
            this.checkBoxUsingFilter.Location = new System.Drawing.Point(14, 53);
            this.checkBoxUsingFilter.Name = "checkBoxUsingFilter";
            this.checkBoxUsingFilter.Size = new System.Drawing.Size(120, 16);
            this.checkBoxUsingFilter.TabIndex = 17;
            this.checkBoxUsingFilter.Text = "启用无效数据过滤";
            this.checkBoxUsingFilter.UseVisualStyleBackColor = true;
            this.checkBoxUsingFilter.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonOutputPath
            // 
            this.buttonOutputPath.Location = new System.Drawing.Point(483, 17);
            this.buttonOutputPath.Name = "buttonOutputPath";
            this.buttonOutputPath.Size = new System.Drawing.Size(47, 23);
            this.buttonOutputPath.TabIndex = 16;
            this.buttonOutputPath.Text = "...";
            this.buttonOutputPath.UseVisualStyleBackColor = true;
            this.buttonOutputPath.Click += new System.EventHandler(this.buttonOutputPath_Click);
            // 
            // textBoxOutputPath
            // 
            this.textBoxOutputPath.Location = new System.Drawing.Point(76, 18);
            this.textBoxOutputPath.Name = "textBoxOutputPath";
            this.textBoxOutputPath.Size = new System.Drawing.Size(400, 21);
            this.textBoxOutputPath.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "输出路径:";
            // 
            // panelFilterSetting
            // 
            this.panelFilterSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilterSetting.Controls.Add(this.textBoxImageNoValue);
            this.panelFilterSetting.Controls.Add(this.comboBoxFilterRegion);
            this.panelFilterSetting.Controls.Add(this.label3);
            this.panelFilterSetting.Controls.Add(this.label1);
            this.panelFilterSetting.Enabled = false;
            this.panelFilterSetting.Location = new System.Drawing.Point(12, 75);
            this.panelFilterSetting.Name = "panelFilterSetting";
            this.panelFilterSetting.Size = new System.Drawing.Size(518, 52);
            this.panelFilterSetting.TabIndex = 13;
            // 
            // textBoxImageNoValue
            // 
            this.textBoxImageNoValue.Location = new System.Drawing.Point(374, 15);
            this.textBoxImageNoValue.Name = "textBoxImageNoValue";
            this.textBoxImageNoValue.Size = new System.Drawing.Size(100, 21);
            this.textBoxImageNoValue.TabIndex = 11;
            this.textBoxImageNoValue.Text = "0,0,0,0";
            // 
            // comboBoxFilterRegion
            // 
            this.comboBoxFilterRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterRegion.FormattingEnabled = true;
            this.comboBoxFilterRegion.Items.AddRange(new object[] {
            "仅过滤重叠区域",
            "过滤全部区域"});
            this.comboBoxFilterRegion.Location = new System.Drawing.Point(87, 15);
            this.comboBoxFilterRegion.Name = "comboBoxFilterRegion";
            this.comboBoxFilterRegion.Size = new System.Drawing.Size(148, 20);
            this.comboBoxFilterRegion.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "无效值(RGBA):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "过滤区域:";
            // 
            // panelProcess
            // 
            this.panelProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProcess.Controls.Add(this.progressBarAll);
            this.panelProcess.Controls.Add(this.labelProcess);
            this.panelProcess.Location = new System.Drawing.Point(12, 138);
            this.panelProcess.Name = "panelProcess";
            this.panelProcess.Size = new System.Drawing.Size(518, 60);
            this.panelProcess.TabIndex = 12;
            // 
            // progressBarAll
            // 
            this.progressBarAll.Location = new System.Drawing.Point(14, 22);
            this.progressBarAll.Name = "progressBarAll";
            this.progressBarAll.Size = new System.Drawing.Size(490, 23);
            this.progressBarAll.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewDomList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(542, 345);
            this.panel3.TabIndex = 13;
            // 
            // FrmDataJoinDom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 592);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDataJoinDom";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "影像拼接";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDataJoinDom_FormClosing);
            this.Load += new System.EventHandler(this.FrmDataBatchDom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDomList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelFilterSetting.ResumeLayout(false);
            this.panelFilterSetting.PerformLayout();
            this.panelProcess.ResumeLayout(false);
            this.panelProcess.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDomList;
        private System.Windows.Forms.Button buttonAddData;
        private System.Windows.Forms.Button buttonAddDataByDirectory;
        private System.Windows.Forms.Button buttonRemoveSelect;
        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBarAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn domPath_old;
        private System.Windows.Forms.DataGridViewTextBoxColumn proj;
        private System.Windows.Forms.CheckBox checkBoxUsingFilter;
        private System.Windows.Forms.Button buttonOutputPath;
        private System.Windows.Forms.TextBox textBoxOutputPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelFilterSetting;
        private System.Windows.Forms.TextBox textBoxImageNoValue;
        private System.Windows.Forms.ComboBox comboBoxFilterRegion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelProcess;
    }
}