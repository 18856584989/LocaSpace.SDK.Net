namespace LayerAttriTableEdit
{
    partial class FrmAttriTableEdit
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
            this.btn_OpenLayer = new System.Windows.Forms.Button();
            this.btn_EditAttriTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 651);
            this.panel1.TabIndex = 0;
            // 
            // btn_OpenLayer
            // 
            this.btn_OpenLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OpenLayer.Location = new System.Drawing.Point(719, 52);
            this.btn_OpenLayer.Name = "btn_OpenLayer";
            this.btn_OpenLayer.Size = new System.Drawing.Size(75, 23);
            this.btn_OpenLayer.TabIndex = 0;
            this.btn_OpenLayer.Text = "打开图层";
            this.btn_OpenLayer.UseVisualStyleBackColor = true;
            this.btn_OpenLayer.Click += new System.EventHandler(this.btn_OpenLayer_Click);
            // 
            // btn_EditAttriTable
            // 
            this.btn_EditAttriTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditAttriTable.Enabled = false;
            this.btn_EditAttriTable.Location = new System.Drawing.Point(719, 99);
            this.btn_EditAttriTable.Name = "btn_EditAttriTable";
            this.btn_EditAttriTable.Size = new System.Drawing.Size(75, 23);
            this.btn_EditAttriTable.TabIndex = 0;
            this.btn_EditAttriTable.Text = "打开属性表";
            this.btn_EditAttriTable.UseVisualStyleBackColor = true;
            this.btn_EditAttriTable.Click += new System.EventHandler(this.btn_EditAttriTable_Click);
            // 
            // FrmAttriTableEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 651);
            this.Controls.Add(this.btn_EditAttriTable);
            this.Controls.Add(this.btn_OpenLayer);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAttriTableEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAttriTableEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_OpenLayer;
        private System.Windows.Forms.Button btn_EditAttriTable;
    }
}

