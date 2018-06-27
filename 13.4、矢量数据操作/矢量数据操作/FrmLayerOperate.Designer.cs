namespace LayerOperate
{
    partial class FrmLayerOperate
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
            this.btn_Move = new System.Windows.Forms.Button();
            this.btn_Scale = new System.Windows.Forms.Button();
            this.btn_Rotate = new System.Windows.Forms.Button();
            this.btn_Hang = new System.Windows.Forms.Button();
            this.btn_FeatureMove = new System.Windows.Forms.Button();
            this.btn_FeatureElevate = new System.Windows.Forms.Button();
            this.btn_Model = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 641);
            this.panel1.TabIndex = 0;
            // 
            // btn_Move
            // 
            this.btn_Move.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Move.Location = new System.Drawing.Point(735, 49);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(75, 23);
            this.btn_Move.TabIndex = 1;
            this.btn_Move.Text = "图层平移";
            this.btn_Move.UseVisualStyleBackColor = true;
            this.btn_Move.Click += new System.EventHandler(this.btn_Move_Click);
            // 
            // btn_Scale
            // 
            this.btn_Scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Scale.Location = new System.Drawing.Point(735, 249);
            this.btn_Scale.Name = "btn_Scale";
            this.btn_Scale.Size = new System.Drawing.Size(75, 23);
            this.btn_Scale.TabIndex = 1;
            this.btn_Scale.Text = "要素缩放";
            this.btn_Scale.UseVisualStyleBackColor = true;
            this.btn_Scale.Click += new System.EventHandler(this.btn_Scale_Click);
            // 
            // btn_Rotate
            // 
            this.btn_Rotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Rotate.Location = new System.Drawing.Point(735, 299);
            this.btn_Rotate.Name = "btn_Rotate";
            this.btn_Rotate.Size = new System.Drawing.Size(75, 23);
            this.btn_Rotate.TabIndex = 1;
            this.btn_Rotate.Text = "要素旋转";
            this.btn_Rotate.UseVisualStyleBackColor = true;
            this.btn_Rotate.Click += new System.EventHandler(this.btn_Rotate_Click);
            // 
            // btn_Hang
            // 
            this.btn_Hang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Hang.Location = new System.Drawing.Point(735, 99);
            this.btn_Hang.Name = "btn_Hang";
            this.btn_Hang.Size = new System.Drawing.Size(75, 23);
            this.btn_Hang.TabIndex = 1;
            this.btn_Hang.Text = "图层抬高";
            this.btn_Hang.UseVisualStyleBackColor = true;
            this.btn_Hang.Click += new System.EventHandler(this.btn_Hang_Click);
            // 
            // btn_FeatureMove
            // 
            this.btn_FeatureMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FeatureMove.Location = new System.Drawing.Point(735, 149);
            this.btn_FeatureMove.Name = "btn_FeatureMove";
            this.btn_FeatureMove.Size = new System.Drawing.Size(75, 23);
            this.btn_FeatureMove.TabIndex = 1;
            this.btn_FeatureMove.Text = "要素平移";
            this.btn_FeatureMove.UseVisualStyleBackColor = true;
            this.btn_FeatureMove.Click += new System.EventHandler(this.btn_FeatureMove_Click);
            // 
            // btn_FeatureElevate
            // 
            this.btn_FeatureElevate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FeatureElevate.Location = new System.Drawing.Point(735, 199);
            this.btn_FeatureElevate.Name = "btn_FeatureElevate";
            this.btn_FeatureElevate.Size = new System.Drawing.Size(75, 23);
            this.btn_FeatureElevate.TabIndex = 1;
            this.btn_FeatureElevate.Text = "要素升降";
            this.btn_FeatureElevate.UseVisualStyleBackColor = true;
            this.btn_FeatureElevate.Click += new System.EventHandler(this.btn_FeatureElevate_Click);
            // 
            // btn_Model
            // 
            this.btn_Model.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Model.Location = new System.Drawing.Point(735, 398);
            this.btn_Model.Name = "btn_Model";
            this.btn_Model.Size = new System.Drawing.Size(75, 23);
            this.btn_Model.TabIndex = 1;
            this.btn_Model.Text = "添加模型";
            this.btn_Model.UseVisualStyleBackColor = true;
            this.btn_Model.Click += new System.EventHandler(this.btn_Model_Click);
            // 
            // FrmLayerOperate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 641);
            this.Controls.Add(this.btn_FeatureElevate);
            this.Controls.Add(this.btn_Hang);
            this.Controls.Add(this.btn_Model);
            this.Controls.Add(this.btn_Rotate);
            this.Controls.Add(this.btn_FeatureMove);
            this.Controls.Add(this.btn_Scale);
            this.Controls.Add(this.btn_Move);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(857, 680);
            this.Name = "FrmLayerOperate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图层操作";
            this.Load += new System.EventHandler(this.FrmLayerOperate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.Button btn_Scale;
        private System.Windows.Forms.Button btn_Rotate;
        private System.Windows.Forms.Button btn_Hang;
        private System.Windows.Forms.Button btn_FeatureMove;
        private System.Windows.Forms.Button btn_FeatureElevate;
        private System.Windows.Forms.Button btn_Model;
    }
}

