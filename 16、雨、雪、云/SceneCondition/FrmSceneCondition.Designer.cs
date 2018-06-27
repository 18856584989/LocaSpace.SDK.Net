namespace SceneCondition
{
    partial class FrmSceneCondition
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
            this.checkBox_Rain = new System.Windows.Forms.CheckBox();
            this.checkBox_Snow = new System.Windows.Forms.CheckBox();
            this.checkBox_cloud = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 563);
            this.panel1.TabIndex = 0;
            // 
            // checkBox_Rain
            // 
            this.checkBox_Rain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Rain.AutoSize = true;
            this.checkBox_Rain.Location = new System.Drawing.Point(772, 57);
            this.checkBox_Rain.Name = "checkBox_Rain";
            this.checkBox_Rain.Size = new System.Drawing.Size(36, 16);
            this.checkBox_Rain.TabIndex = 2;
            this.checkBox_Rain.Text = "雨";
            this.checkBox_Rain.UseVisualStyleBackColor = true;
            this.checkBox_Rain.CheckedChanged += new System.EventHandler(this.checkBox_Rain_CheckedChanged);
            // 
            // checkBox_Snow
            // 
            this.checkBox_Snow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Snow.AutoSize = true;
            this.checkBox_Snow.Location = new System.Drawing.Point(771, 105);
            this.checkBox_Snow.Name = "checkBox_Snow";
            this.checkBox_Snow.Size = new System.Drawing.Size(36, 16);
            this.checkBox_Snow.TabIndex = 2;
            this.checkBox_Snow.Text = "雪";
            this.checkBox_Snow.UseVisualStyleBackColor = true;
            this.checkBox_Snow.CheckedChanged += new System.EventHandler(this.checkBox_Snow_CheckedChanged);
            // 
            // checkBox_cloud
            // 
            this.checkBox_cloud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_cloud.AutoSize = true;
            this.checkBox_cloud.Location = new System.Drawing.Point(771, 162);
            this.checkBox_cloud.Name = "checkBox_cloud";
            this.checkBox_cloud.Size = new System.Drawing.Size(36, 16);
            this.checkBox_cloud.TabIndex = 2;
            this.checkBox_cloud.Text = "云";
            this.checkBox_cloud.UseVisualStyleBackColor = true;
            this.checkBox_cloud.CheckedChanged += new System.EventHandler(this.checkBox_cloud_CheckedChanged);
            // 
            // FrmSceneCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 564);
            this.Controls.Add(this.checkBox_cloud);
            this.Controls.Add(this.checkBox_Snow);
            this.Controls.Add(this.checkBox_Rain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSceneCondition";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "三维场景";
            this.Load += new System.EventHandler(this.FrmSceneCondition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox_Rain;
        private System.Windows.Forms.CheckBox checkBox_Snow;
        private System.Windows.Forms.CheckBox checkBox_cloud;
    }
}

