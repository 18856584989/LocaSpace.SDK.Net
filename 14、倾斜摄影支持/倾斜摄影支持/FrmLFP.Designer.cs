namespace LFPSupport
{
    partial class FrmLFP
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
            this.btn_Transform = new System.Windows.Forms.Button();
            this.btn_ModelPreDown = new System.Windows.Forms.Button();
            this.btn_ReplaceModel = new System.Windows.Forms.Button();
            this.btn_Calculate = new System.Windows.Forms.Button();
            this.btn_ConnetServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 569);
            this.panel1.TabIndex = 0;
            // 
            // btn_Transform
            // 
            this.btn_Transform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Transform.Location = new System.Drawing.Point(769, 95);
            this.btn_Transform.Name = "btn_Transform";
            this.btn_Transform.Size = new System.Drawing.Size(75, 23);
            this.btn_Transform.TabIndex = 0;
            this.btn_Transform.Text = "数据转换";
            this.btn_Transform.UseVisualStyleBackColor = true;
            this.btn_Transform.Click += new System.EventHandler(this.btn_Transform_Click);
            // 
            // btn_ModelPreDown
            // 
            this.btn_ModelPreDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ModelPreDown.Location = new System.Drawing.Point(769, 165);
            this.btn_ModelPreDown.Name = "btn_ModelPreDown";
            this.btn_ModelPreDown.Size = new System.Drawing.Size(75, 23);
            this.btn_ModelPreDown.TabIndex = 0;
            this.btn_ModelPreDown.Text = "模型压平";
            this.btn_ModelPreDown.UseVisualStyleBackColor = true;
            this.btn_ModelPreDown.Click += new System.EventHandler(this.btn_ModelPreDown_Click);
            // 
            // btn_ReplaceModel
            // 
            this.btn_ReplaceModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ReplaceModel.Location = new System.Drawing.Point(769, 235);
            this.btn_ReplaceModel.Name = "btn_ReplaceModel";
            this.btn_ReplaceModel.Size = new System.Drawing.Size(75, 23);
            this.btn_ReplaceModel.TabIndex = 0;
            this.btn_ReplaceModel.Text = "模型替换";
            this.btn_ReplaceModel.UseVisualStyleBackColor = true;
            this.btn_ReplaceModel.Click += new System.EventHandler(this.btn_ReplaceModel_Click);
            // 
            // btn_Calculate
            // 
            this.btn_Calculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Calculate.Location = new System.Drawing.Point(769, 305);
            this.btn_Calculate.Name = "btn_Calculate";
            this.btn_Calculate.Size = new System.Drawing.Size(75, 23);
            this.btn_Calculate.TabIndex = 0;
            this.btn_Calculate.Text = "方量计算";
            this.btn_Calculate.UseVisualStyleBackColor = true;
            this.btn_Calculate.Click += new System.EventHandler(this.btn_Calculate_Click);
            // 
            // btn_ConnetServer
            // 
            this.btn_ConnetServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ConnetServer.Location = new System.Drawing.Point(769, 33);
            this.btn_ConnetServer.Name = "btn_ConnetServer";
            this.btn_ConnetServer.Size = new System.Drawing.Size(75, 23);
            this.btn_ConnetServer.TabIndex = 0;
            this.btn_ConnetServer.Text = "连接服务器";
            this.btn_ConnetServer.UseVisualStyleBackColor = true;
            this.btn_ConnetServer.Click += new System.EventHandler(this.btn_ConnetServer_Click);
            // 
            // FrmLFP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 570);
            this.Controls.Add(this.btn_Calculate);
            this.Controls.Add(this.btn_ReplaceModel);
            this.Controls.Add(this.btn_ModelPreDown);
            this.Controls.Add(this.btn_ConnetServer);
            this.Controls.Add(this.btn_Transform);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(893, 609);
            this.Name = "FrmLFP";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "倾斜摄影支持";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Transform;
        private System.Windows.Forms.Button btn_ModelPreDown;
        private System.Windows.Forms.Button btn_ReplaceModel;
        private System.Windows.Forms.Button btn_Calculate;
        private System.Windows.Forms.Button btn_ConnetServer;
    }
}

