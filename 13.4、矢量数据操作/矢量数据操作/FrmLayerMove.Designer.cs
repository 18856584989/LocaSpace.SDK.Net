namespace LayerOperate
{
    partial class FrmLayerMove
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxBengin = new System.Windows.Forms.GroupBox();
            this.btn_PickBeginPoint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_BeginY = new System.Windows.Forms.TextBox();
            this.textBox_BeginX = new System.Windows.Forms.TextBox();
            this.groupBoxEnd = new System.Windows.Forms.GroupBox();
            this.btn_PickEndPoint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_EndY = new System.Windows.Forms.TextBox();
            this.textBox_EndX = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxBengin.SuspendLayout();
            this.groupBoxEnd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBengin
            // 
            this.groupBoxBengin.Controls.Add(this.btn_PickBeginPoint);
            this.groupBoxBengin.Controls.Add(this.label2);
            this.groupBoxBengin.Controls.Add(this.label1);
            this.groupBoxBengin.Controls.Add(this.textBox_BeginY);
            this.groupBoxBengin.Controls.Add(this.textBox_BeginX);
            this.groupBoxBengin.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBengin.Name = "groupBoxBengin";
            this.groupBoxBengin.Size = new System.Drawing.Size(358, 53);
            this.groupBoxBengin.TabIndex = 0;
            this.groupBoxBengin.TabStop = false;
            this.groupBoxBengin.Text = "起点";
            // 
            // btn_PickBeginPoint
            // 
            this.btn_PickBeginPoint.Location = new System.Drawing.Point(322, 19);
            this.btn_PickBeginPoint.Name = "btn_PickBeginPoint";
            this.btn_PickBeginPoint.Size = new System.Drawing.Size(30, 23);
            this.btn_PickBeginPoint.TabIndex = 1;
            this.btn_PickBeginPoint.Tag = "Begin";
            this.btn_PickBeginPoint.Text = "取";
            this.btn_PickBeginPoint.UseVisualStyleBackColor = true;
            this.btn_PickBeginPoint.Click += new System.EventHandler(this.PickBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:";
            // 
            // textBox_BeginY
            // 
            this.textBox_BeginY.Location = new System.Drawing.Point(184, 21);
            this.textBox_BeginY.Name = "textBox_BeginY";
            this.textBox_BeginY.ReadOnly = true;
            this.textBox_BeginY.Size = new System.Drawing.Size(132, 21);
            this.textBox_BeginY.TabIndex = 0;
            // 
            // textBox_BeginX
            // 
            this.textBox_BeginX.Location = new System.Drawing.Point(24, 21);
            this.textBox_BeginX.Name = "textBox_BeginX";
            this.textBox_BeginX.ReadOnly = true;
            this.textBox_BeginX.Size = new System.Drawing.Size(132, 21);
            this.textBox_BeginX.TabIndex = 0;
            // 
            // groupBoxEnd
            // 
            this.groupBoxEnd.Controls.Add(this.btn_PickEndPoint);
            this.groupBoxEnd.Controls.Add(this.label3);
            this.groupBoxEnd.Controls.Add(this.label4);
            this.groupBoxEnd.Controls.Add(this.textBox_EndY);
            this.groupBoxEnd.Controls.Add(this.textBox_EndX);
            this.groupBoxEnd.Location = new System.Drawing.Point(12, 71);
            this.groupBoxEnd.Name = "groupBoxEnd";
            this.groupBoxEnd.Size = new System.Drawing.Size(358, 53);
            this.groupBoxEnd.TabIndex = 0;
            this.groupBoxEnd.TabStop = false;
            this.groupBoxEnd.Text = "目标点";
            // 
            // btn_PickEndPoint
            // 
            this.btn_PickEndPoint.Location = new System.Drawing.Point(322, 19);
            this.btn_PickEndPoint.Name = "btn_PickEndPoint";
            this.btn_PickEndPoint.Size = new System.Drawing.Size(30, 23);
            this.btn_PickEndPoint.TabIndex = 1;
            this.btn_PickEndPoint.Tag = "End";
            this.btn_PickEndPoint.Text = "取";
            this.btn_PickEndPoint.UseVisualStyleBackColor = true;
            this.btn_PickEndPoint.Click += new System.EventHandler(this.PickBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "X:";
            // 
            // textBox_EndY
            // 
            this.textBox_EndY.Location = new System.Drawing.Point(184, 21);
            this.textBox_EndY.Name = "textBox_EndY";
            this.textBox_EndY.ReadOnly = true;
            this.textBox_EndY.Size = new System.Drawing.Size(132, 21);
            this.textBox_EndY.TabIndex = 0;
            // 
            // textBox_EndX
            // 
            this.textBox_EndX.Location = new System.Drawing.Point(24, 21);
            this.textBox_EndX.Name = "textBox_EndX";
            this.textBox_EndX.ReadOnly = true;
            this.textBox_EndX.Size = new System.Drawing.Size(132, 21);
            this.textBox_EndX.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(181, 140);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(79, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(274, 140);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(79, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmLayerMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(382, 175);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBoxEnd);
            this.Controls.Add(this.groupBoxBengin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLayerMove";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图层平移";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLayerMove_FormClosing);
            this.groupBoxBengin.ResumeLayout(false);
            this.groupBoxBengin.PerformLayout();
            this.groupBoxEnd.ResumeLayout(false);
            this.groupBoxEnd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBengin;
        private System.Windows.Forms.TextBox textBox_BeginX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_BeginY;
        private System.Windows.Forms.Button btn_PickBeginPoint;
        private System.Windows.Forms.GroupBox groupBoxEnd;
        private System.Windows.Forms.Button btn_PickEndPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_EndY;
        private System.Windows.Forms.TextBox textBox_EndX;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}