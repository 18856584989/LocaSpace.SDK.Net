namespace LDBSupport
{
    partial class LDBSurpport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_CreateLDB = new System.Windows.Forms.Button();
            this.btn_OpenLDB = new System.Windows.Forms.Button();
            this.btn_EditLayer = new System.Windows.Forms.Button();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.btn_EditFeature = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 563);
            this.panel1.TabIndex = 0;
            // 
            // btn_CreateLDB
            // 
            this.btn_CreateLDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CreateLDB.Location = new System.Drawing.Point(651, 28);
            this.btn_CreateLDB.Name = "btn_CreateLDB";
            this.btn_CreateLDB.Size = new System.Drawing.Size(87, 23);
            this.btn_CreateLDB.TabIndex = 1;
            this.btn_CreateLDB.Text = "创建LDB文件";
            this.btn_CreateLDB.UseVisualStyleBackColor = true;
            this.btn_CreateLDB.Click += new System.EventHandler(this.btn_CreateLDB_Click);
            // 
            // btn_OpenLDB
            // 
            this.btn_OpenLDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OpenLDB.Location = new System.Drawing.Point(651, 69);
            this.btn_OpenLDB.Name = "btn_OpenLDB";
            this.btn_OpenLDB.Size = new System.Drawing.Size(87, 23);
            this.btn_OpenLDB.TabIndex = 1;
            this.btn_OpenLDB.Text = "打开LDB文件";
            this.btn_OpenLDB.UseVisualStyleBackColor = true;
            this.btn_OpenLDB.Click += new System.EventHandler(this.btn_OpenLDB_Click);
            // 
            // btn_EditLayer
            // 
            this.btn_EditLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditLayer.Enabled = false;
            this.btn_EditLayer.Location = new System.Drawing.Point(651, 109);
            this.btn_EditLayer.Name = "btn_EditLayer";
            this.btn_EditLayer.Size = new System.Drawing.Size(87, 23);
            this.btn_EditLayer.TabIndex = 1;
            this.btn_EditLayer.Text = "添加图层";
            this.btn_EditLayer.UseVisualStyleBackColor = true;
            this.btn_EditLayer.Click += new System.EventHandler(this.btn_EditLayer_Click);
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView.Location = new System.Drawing.Point(637, 306);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(114, 245);
            this.TreeView.TabIndex = 2;
            // 
            // btn_EditFeature
            // 
            this.btn_EditFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditFeature.Enabled = false;
            this.btn_EditFeature.Location = new System.Drawing.Point(651, 149);
            this.btn_EditFeature.Name = "btn_EditFeature";
            this.btn_EditFeature.Size = new System.Drawing.Size(87, 23);
            this.btn_EditFeature.TabIndex = 1;
            this.btn_EditFeature.Text = "添加要素";
            this.btn_EditFeature.UseVisualStyleBackColor = true;
            this.btn_EditFeature.Click += new System.EventHandler(this.btn_EditFeature_Click);
            // 
            // LDBSurpport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 563);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.btn_EditFeature);
            this.Controls.Add(this.btn_EditLayer);
            this.Controls.Add(this.btn_OpenLDB);
            this.Controls.Add(this.btn_CreateLDB);
            this.Controls.Add(this.panel1);
            this.Name = "LDBSurpport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LDBSupport";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_CreateLDB;
        private System.Windows.Forms.Button btn_OpenLDB;
        private System.Windows.Forms.Button btn_EditLayer;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button btn_EditFeature;
    }
}

