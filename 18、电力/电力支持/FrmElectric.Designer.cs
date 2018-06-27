namespace ElectricSupport
{
    partial class FrmElectric
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_addPowerLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 621);
            this.panel1.TabIndex = 0;
            // 
            // btn_addPowerLine
            // 
            this.btn_addPowerLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addPowerLine.Location = new System.Drawing.Point(726, 52);
            this.btn_addPowerLine.Name = "btn_addPowerLine";
            this.btn_addPowerLine.Size = new System.Drawing.Size(75, 23);
            this.btn_addPowerLine.TabIndex = 0;
            this.btn_addPowerLine.Text = "添加电力线";
            this.btn_addPowerLine.UseVisualStyleBackColor = true;
            this.btn_addPowerLine.Click += new System.EventHandler(this.btn_addPowerLine_Click);
            // 
            // FrmElectric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 620);
            this.Controls.Add(this.btn_addPowerLine);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(847, 659);
            this.Name = "FrmElectric";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电力支持";
            this.Load += new System.EventHandler(this.FrmElectric_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_addPowerLine;
    }
}

