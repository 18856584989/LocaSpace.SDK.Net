namespace 图层的添加和删除
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowD = new System.Windows.Forms.Button();
            this.btnLayerMove = new System.Windows.Forms.Button();
            this.btnAddTerrain = new System.Windows.Forms.Button();
            this.btnAddLayer = new System.Windows.Forms.Button();
            this.btnRemoveLayer = new System.Windows.Forms.Button();
            this.btnRemoveTerrain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 546);
            this.panel1.TabIndex = 0;
            // 
            // btnShowD
            // 
            this.btnShowD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowD.Location = new System.Drawing.Point(589, 192);
            this.btnShowD.Name = "btnShowD";
            this.btnShowD.Size = new System.Drawing.Size(75, 23);
            this.btnShowD.TabIndex = 1;
            this.btnShowD.Text = "显示/隐藏";
            this.btnShowD.UseVisualStyleBackColor = true;
            this.btnShowD.Click += new System.EventHandler(this.btnShowD_Click);
            // 
            // btnLayerMove
            // 
            this.btnLayerMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLayerMove.Location = new System.Drawing.Point(589, 245);
            this.btnLayerMove.Name = "btnLayerMove";
            this.btnLayerMove.Size = new System.Drawing.Size(75, 23);
            this.btnLayerMove.TabIndex = 2;
            this.btnLayerMove.Text = "图层上下移动";
            this.btnLayerMove.UseVisualStyleBackColor = true;
            this.btnLayerMove.Click += new System.EventHandler(this.btnLayerMove_Click);
            // 
            // btnAddTerrain
            // 
            this.btnAddTerrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTerrain.Location = new System.Drawing.Point(589, 299);
            this.btnAddTerrain.Name = "btnAddTerrain";
            this.btnAddTerrain.Size = new System.Drawing.Size(75, 23);
            this.btnAddTerrain.TabIndex = 3;
            this.btnAddTerrain.Text = "地形添加";
            this.btnAddTerrain.UseVisualStyleBackColor = true;
            this.btnAddTerrain.Click += new System.EventHandler(this.btnAddTerrain_Click);
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLayer.Location = new System.Drawing.Point(589, 99);
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddLayer.TabIndex = 4;
            this.btnAddLayer.Text = "添加图层";
            this.btnAddLayer.UseVisualStyleBackColor = true;
            this.btnAddLayer.Click += new System.EventHandler(this.btnAddLayer_Click);
            // 
            // btnRemoveLayer
            // 
            this.btnRemoveLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveLayer.Location = new System.Drawing.Point(589, 143);
            this.btnRemoveLayer.Name = "btnRemoveLayer";
            this.btnRemoveLayer.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveLayer.TabIndex = 4;
            this.btnRemoveLayer.Text = "删除图层";
            this.btnRemoveLayer.UseVisualStyleBackColor = true;
            this.btnRemoveLayer.Click += new System.EventHandler(this.btnRemoveLayer_Click);
            // 
            // btnRemoveTerrain
            // 
            this.btnRemoveTerrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTerrain.Location = new System.Drawing.Point(589, 346);
            this.btnRemoveTerrain.Name = "btnRemoveTerrain";
            this.btnRemoveTerrain.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTerrain.TabIndex = 3;
            this.btnRemoveTerrain.Text = "地形删除";
            this.btnRemoveTerrain.UseVisualStyleBackColor = true;
            this.btnRemoveTerrain.Click += new System.EventHandler(this.btnRemoveTerrain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 546);
            this.Controls.Add(this.btnRemoveLayer);
            this.Controls.Add(this.btnAddLayer);
            this.Controls.Add(this.btnRemoveTerrain);
            this.Controls.Add(this.btnAddTerrain);
            this.Controls.Add(this.btnLayerMove);
            this.Controls.Add(this.btnShowD);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowD;
        private System.Windows.Forms.Button btnLayerMove;
        private System.Windows.Forms.Button btnAddTerrain;
        private System.Windows.Forms.Button btnAddLayer;
        private System.Windows.Forms.Button btnRemoveLayer;
        private System.Windows.Forms.Button btnRemoveTerrain;
    }
}

