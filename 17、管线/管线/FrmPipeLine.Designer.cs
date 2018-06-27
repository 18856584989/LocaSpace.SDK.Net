namespace PipeLineSupport
{
    partial class FrmPipeLine
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_CreatePipeLine = new System.Windows.Forms.Button();
            this.btn_LoadLayer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_FlowDerc = new System.Windows.Forms.Button();
            this.btn_VerDist = new System.Windows.Forms.Button();
            this.btn_HorizonDist = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 600);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_CreatePipeLine);
            this.groupBox1.Controls.Add(this.btn_LoadLayer);
            this.groupBox1.Location = new System.Drawing.Point(703, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 95);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "创建/显示";
            // 
            // btn_CreatePipeLine
            // 
            this.btn_CreatePipeLine.Location = new System.Drawing.Point(14, 22);
            this.btn_CreatePipeLine.Name = "btn_CreatePipeLine";
            this.btn_CreatePipeLine.Size = new System.Drawing.Size(92, 23);
            this.btn_CreatePipeLine.TabIndex = 0;
            this.btn_CreatePipeLine.Text = "创建管线";
            this.btn_CreatePipeLine.UseVisualStyleBackColor = true;
            this.btn_CreatePipeLine.Click += new System.EventHandler(this.btn_CreatePipeLine_Click);
            // 
            // btn_LoadLayer
            // 
            this.btn_LoadLayer.Location = new System.Drawing.Point(14, 60);
            this.btn_LoadLayer.Name = "btn_LoadLayer";
            this.btn_LoadLayer.Size = new System.Drawing.Size(92, 23);
            this.btn_LoadLayer.TabIndex = 0;
            this.btn_LoadLayer.Text = "加载图层";
            this.btn_LoadLayer.UseVisualStyleBackColor = true;
            this.btn_LoadLayer.Click += new System.EventHandler(this.btn_LoadLayer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_FlowDerc);
            this.groupBox2.Controls.Add(this.btn_VerDist);
            this.groupBox2.Controls.Add(this.btn_HorizonDist);
            this.groupBox2.Location = new System.Drawing.Point(703, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 122);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "管线分析";
            // 
            // btn_FlowDerc
            // 
            this.btn_FlowDerc.Location = new System.Drawing.Point(14, 87);
            this.btn_FlowDerc.Name = "btn_FlowDerc";
            this.btn_FlowDerc.Size = new System.Drawing.Size(92, 23);
            this.btn_FlowDerc.TabIndex = 0;
            this.btn_FlowDerc.Text = "显示流向分析";
            this.btn_FlowDerc.UseVisualStyleBackColor = true;
            this.btn_FlowDerc.Click += new System.EventHandler(this.btn_FlowDerc_Click);
            // 
            // btn_VerDist
            // 
            this.btn_VerDist.Location = new System.Drawing.Point(14, 53);
            this.btn_VerDist.Name = "btn_VerDist";
            this.btn_VerDist.Size = new System.Drawing.Size(92, 23);
            this.btn_VerDist.TabIndex = 0;
            this.btn_VerDist.Text = "垂直净距分析";
            this.btn_VerDist.UseVisualStyleBackColor = true;
            this.btn_VerDist.Click += new System.EventHandler(this.btn_VerDist_Click);
            // 
            // btn_HorizonDist
            // 
            this.btn_HorizonDist.Location = new System.Drawing.Point(14, 20);
            this.btn_HorizonDist.Name = "btn_HorizonDist";
            this.btn_HorizonDist.Size = new System.Drawing.Size(92, 23);
            this.btn_HorizonDist.TabIndex = 0;
            this.btn_HorizonDist.Text = "水平净距分析";
            this.btn_HorizonDist.UseVisualStyleBackColor = true;
            this.btn_HorizonDist.Click += new System.EventHandler(this.btn_HorizonDist_Click);
            // 
            // FrmPipeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 603);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(840, 642);
            this.Name = "FrmPipeLine";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管线";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_LoadLayer;
        private System.Windows.Forms.Button btn_HorizonDist;
        private System.Windows.Forms.Button btn_FlowDerc;
        private System.Windows.Forms.Button btn_VerDist;
        private System.Windows.Forms.Button btn_CreatePipeLine;
    }
}

