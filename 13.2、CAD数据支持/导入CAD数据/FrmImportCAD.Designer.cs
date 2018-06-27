namespace ImportCAD
{
    partial class FrmImportCAD
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
            this.btn_ImportCAD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 544);
            this.panel1.TabIndex = 0;
            // 
            // btn_ImportCAD
            // 
            this.btn_ImportCAD.Location = new System.Drawing.Point(620, 64);
            this.btn_ImportCAD.Name = "btn_ImportCAD";
            this.btn_ImportCAD.Size = new System.Drawing.Size(82, 23);
            this.btn_ImportCAD.TabIndex = 1;
            this.btn_ImportCAD.Text = "导入CAD文件";
            this.btn_ImportCAD.UseVisualStyleBackColor = true;
            this.btn_ImportCAD.Click += new System.EventHandler(this.btn_ImportCAD_Click);
            // 
            // FrmImportCAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 545);
            this.Controls.Add(this.btn_ImportCAD);
            this.Controls.Add(this.panel1);
            this.Name = "FrmImportCAD";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAD文件支持";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ImportCAD;
    }
}

