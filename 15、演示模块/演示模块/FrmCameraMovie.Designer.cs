namespace LSVSpecialEffects
{
    partial class FrmCameraMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCameraMovie));
            this.btn_Preview = new System.Windows.Forms.Button();
            this.btn_PickCameraState = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.numericUpDown_ConsistTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CreateFile = new System.Windows.Forms.Button();
            this.lbc_FrameCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ConsistTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Preview
            // 
            resources.ApplyResources(this.btn_Preview, "btn_Preview");
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
            // 
            // btn_PickCameraState
            // 
            resources.ApplyResources(this.btn_PickCameraState, "btn_PickCameraState");
            this.btn_PickCameraState.Name = "btn_PickCameraState";
            this.btn_PickCameraState.UseVisualStyleBackColor = true;
            this.btn_PickCameraState.Click += new System.EventHandler(this.btn_PickCameraState_Click);
            // 
            // btn_Cancel
            // 
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // numericUpDown_ConsistTime
            // 
            resources.ApplyResources(this.numericUpDown_ConsistTime, "numericUpDown_ConsistTime");
            this.numericUpDown_ConsistTime.Name = "numericUpDown_ConsistTime";
            this.numericUpDown_ConsistTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btn_CreateFile
            // 
            resources.ApplyResources(this.btn_CreateFile, "btn_CreateFile");
            this.btn_CreateFile.Name = "btn_CreateFile";
            this.btn_CreateFile.UseVisualStyleBackColor = true;
            this.btn_CreateFile.Click += new System.EventHandler(this.btn_CreateFile_Click);
            // 
            // lbc_FrameCount
            // 
            resources.ApplyResources(this.lbc_FrameCount, "lbc_FrameCount");
            this.lbc_FrameCount.Name = "lbc_FrameCount";
            // 
            // FrmCameraMovie
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.Controls.Add(this.lbc_FrameCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_ConsistTime);
            this.Controls.Add(this.btn_PickCameraState);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_CreateFile);
            this.Controls.Add(this.btn_Preview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCameraMovie";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ConsistTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.Button btn_PickCameraState;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.NumericUpDown numericUpDown_ConsistTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CreateFile;
        private System.Windows.Forms.Label lbc_FrameCount;
    }
}