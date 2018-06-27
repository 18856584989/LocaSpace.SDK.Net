namespace 元素的添加和删除及属性样式设置
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
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.btnAddPolygon = new System.Windows.Forms.Button();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.btnRemovePoint = new System.Windows.Forms.Button();
            this.btnRemoveLine = new System.Windows.Forms.Button();
            this.btnRemovePolygon = new System.Windows.Forms.Button();
            this.btnRemoveModel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 547);
            this.panel1.TabIndex = 0;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPoint.Location = new System.Drawing.Point(552, 35);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(75, 23);
            this.btnAddPoint.TabIndex = 1;
            this.btnAddPoint.Text = "创建点";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // btnAddLine
            // 
            this.btnAddLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLine.Location = new System.Drawing.Point(552, 83);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(75, 23);
            this.btnAddLine.TabIndex = 1;
            this.btnAddLine.Text = "创建线";
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // btnAddPolygon
            // 
            this.btnAddPolygon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPolygon.Location = new System.Drawing.Point(552, 132);
            this.btnAddPolygon.Name = "btnAddPolygon";
            this.btnAddPolygon.Size = new System.Drawing.Size(75, 23);
            this.btnAddPolygon.TabIndex = 2;
            this.btnAddPolygon.Text = "创建面";
            this.btnAddPolygon.UseVisualStyleBackColor = true;
            this.btnAddPolygon.Click += new System.EventHandler(this.btnAddPolygon_Click);
            // 
            // btnAddModel
            // 
            this.btnAddModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddModel.Location = new System.Drawing.Point(552, 178);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(75, 23);
            this.btnAddModel.TabIndex = 2;
            this.btnAddModel.Text = "创建模型";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // btnRemovePoint
            // 
            this.btnRemovePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePoint.Location = new System.Drawing.Point(552, 282);
            this.btnRemovePoint.Name = "btnRemovePoint";
            this.btnRemovePoint.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePoint.TabIndex = 1;
            this.btnRemovePoint.Text = "删除点";
            this.btnRemovePoint.UseVisualStyleBackColor = true;
            this.btnRemovePoint.Click += new System.EventHandler(this.btnRemovePoint_Click);
            // 
            // btnRemoveLine
            // 
            this.btnRemoveLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveLine.Location = new System.Drawing.Point(552, 330);
            this.btnRemoveLine.Name = "btnRemoveLine";
            this.btnRemoveLine.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveLine.TabIndex = 1;
            this.btnRemoveLine.Text = "删除线";
            this.btnRemoveLine.UseVisualStyleBackColor = true;
            this.btnRemoveLine.Click += new System.EventHandler(this.btnRemoveLine_Click);
            // 
            // btnRemovePolygon
            // 
            this.btnRemovePolygon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePolygon.Location = new System.Drawing.Point(552, 379);
            this.btnRemovePolygon.Name = "btnRemovePolygon";
            this.btnRemovePolygon.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePolygon.TabIndex = 2;
            this.btnRemovePolygon.Text = "删除面";
            this.btnRemovePolygon.UseVisualStyleBackColor = true;
            this.btnRemovePolygon.Click += new System.EventHandler(this.btnRemovePolygon_Click);
            // 
            // btnRemoveModel
            // 
            this.btnRemoveModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveModel.Location = new System.Drawing.Point(552, 425);
            this.btnRemoveModel.Name = "btnRemoveModel";
            this.btnRemoveModel.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveModel.TabIndex = 2;
            this.btnRemoveModel.Text = "删除模型";
            this.btnRemoveModel.UseVisualStyleBackColor = true;
            this.btnRemoveModel.Click += new System.EventHandler(this.btnRemoveModel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 547);
            this.Controls.Add(this.btnRemoveModel);
            this.Controls.Add(this.btnAddModel);
            this.Controls.Add(this.btnRemovePolygon);
            this.Controls.Add(this.btnAddPolygon);
            this.Controls.Add(this.btnRemoveLine);
            this.Controls.Add(this.btnAddLine);
            this.Controls.Add(this.btnRemovePoint);
            this.Controls.Add(this.btnAddPoint);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.Button btnAddPolygon;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.Button btnRemovePoint;
        private System.Windows.Forms.Button btnRemoveLine;
        private System.Windows.Forms.Button btnRemovePolygon;
        private System.Windows.Forms.Button btnRemoveModel;
    }
}

