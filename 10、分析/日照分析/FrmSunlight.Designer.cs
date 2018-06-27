namespace Sunlight
{
    partial class FrmSunlight
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
            this.btn_sunLight = new System.Windows.Forms.Button();
            this.btn_Time = new System.Windows.Forms.Button();
            this.btn_ConnectServer = new System.Windows.Forms.Button();
            this.btn_RealtimePos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 553);
            this.panel1.TabIndex = 0;
            // 
            // btn_sunLight
            // 
            this.btn_sunLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sunLight.Location = new System.Drawing.Point(676, 105);
            this.btn_sunLight.Name = "btn_sunLight";
            this.btn_sunLight.Size = new System.Drawing.Size(75, 23);
            this.btn_sunLight.TabIndex = 1;
            this.btn_sunLight.Text = "打开日照";
            this.btn_sunLight.UseVisualStyleBackColor = true;
            this.btn_sunLight.Click += new System.EventHandler(this.btn_sunLight_Click);
            // 
            // btn_Time
            // 
            this.btn_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Time.Location = new System.Drawing.Point(676, 165);
            this.btn_Time.Name = "btn_Time";
            this.btn_Time.Size = new System.Drawing.Size(75, 23);
            this.btn_Time.TabIndex = 1;
            this.btn_Time.Text = "调整日照时间";
            this.btn_Time.UseVisualStyleBackColor = true;
            this.btn_Time.Click += new System.EventHandler(this.btn_Time_Click);
            // 
            // btn_ConnectServer
            // 
            this.btn_ConnectServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ConnectServer.Location = new System.Drawing.Point(676, 48);
            this.btn_ConnectServer.Name = "btn_ConnectServer";
            this.btn_ConnectServer.Size = new System.Drawing.Size(75, 23);
            this.btn_ConnectServer.TabIndex = 1;
            this.btn_ConnectServer.Text = "加载模型";
            this.btn_ConnectServer.UseVisualStyleBackColor = true;
            this.btn_ConnectServer.Click += new System.EventHandler(this.btn_ConnectServer_Click);
            // 
            // btn_RealtimePos
            // 
            this.btn_RealtimePos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RealtimePos.Location = new System.Drawing.Point(676, 224);
            this.btn_RealtimePos.Name = "btn_RealtimePos";
            this.btn_RealtimePos.Size = new System.Drawing.Size(75, 23);
            this.btn_RealtimePos.TabIndex = 1;
            this.btn_RealtimePos.Text = "实时光照";
            this.btn_RealtimePos.UseVisualStyleBackColor = true;
            this.btn_RealtimePos.Click += new System.EventHandler(this.btn_RealtimePos_Click);
            // 
            // FrmSunlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 554);
            this.Controls.Add(this.btn_Time);
            this.Controls.Add(this.btn_ConnectServer);
            this.Controls.Add(this.btn_RealtimePos);
            this.Controls.Add(this.btn_sunLight);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSunlight";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日照分析";
            this.Load += new System.EventHandler(this.FrmSunlight_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_sunLight;
        private System.Windows.Forms.Button btn_Time;
        private System.Windows.Forms.Button btn_ConnectServer;
        private System.Windows.Forms.Button btn_RealtimePos;
    }
}

