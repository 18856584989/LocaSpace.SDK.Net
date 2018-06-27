namespace LSVSpecialEffects
{
    partial class FrmSpecialEffects
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Ocean = new System.Windows.Forms.Button();
            this.btn_CameraMovie = new System.Windows.Forms.Button();
            this.btn_Fire = new System.Windows.Forms.Button();
            this.btn_PlanMove = new System.Windows.Forms.Button();
            this.btn_Missile = new System.Windows.Forms.Button();
            this.btn_BoatTail = new System.Windows.Forms.Button();
            this.btn_HelicopterFly = new System.Windows.Forms.Button();
            this.btn_VedioProjection = new System.Windows.Forms.Button();
            this.btn_Spring = new System.Windows.Forms.Button();
            this.btn_Particle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timer_tail = new System.Windows.Forms.Timer(this.components);
            this.timer_Rotor = new System.Windows.Forms.Timer(this.components);
            this.timerPlayVideo = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 619);
            this.panel1.TabIndex = 0;
            // 
            // btn_Ocean
            // 
            this.btn_Ocean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ocean.Location = new System.Drawing.Point(15, 22);
            this.btn_Ocean.Name = "btn_Ocean";
            this.btn_Ocean.Size = new System.Drawing.Size(74, 23);
            this.btn_Ocean.TabIndex = 1;
            this.btn_Ocean.Text = "开启海水";
            this.btn_Ocean.UseVisualStyleBackColor = true;
            this.btn_Ocean.Click += new System.EventHandler(this.btn_Ocean_Click);
            // 
            // btn_CameraMovie
            // 
            this.btn_CameraMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CameraMovie.Location = new System.Drawing.Point(733, 312);
            this.btn_CameraMovie.Name = "btn_CameraMovie";
            this.btn_CameraMovie.Size = new System.Drawing.Size(74, 23);
            this.btn_CameraMovie.TabIndex = 1;
            this.btn_CameraMovie.Text = "相机动画";
            this.btn_CameraMovie.UseVisualStyleBackColor = true;
            this.btn_CameraMovie.Click += new System.EventHandler(this.btn_CameraMovie_Click);
            // 
            // btn_Fire
            // 
            this.btn_Fire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Fire.Location = new System.Drawing.Point(15, 59);
            this.btn_Fire.Name = "btn_Fire";
            this.btn_Fire.Size = new System.Drawing.Size(74, 23);
            this.btn_Fire.TabIndex = 1;
            this.btn_Fire.Text = "火";
            this.btn_Fire.UseVisualStyleBackColor = true;
            this.btn_Fire.Click += new System.EventHandler(this.btn_Fire_Click);
            // 
            // btn_PlanMove
            // 
            this.btn_PlanMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PlanMove.Location = new System.Drawing.Point(733, 348);
            this.btn_PlanMove.Name = "btn_PlanMove";
            this.btn_PlanMove.Size = new System.Drawing.Size(74, 23);
            this.btn_PlanMove.TabIndex = 1;
            this.btn_PlanMove.Text = "飞机动画";
            this.btn_PlanMove.UseVisualStyleBackColor = true;
            this.btn_PlanMove.Click += new System.EventHandler(this.btn_PlanMove_Click);
            // 
            // btn_Missile
            // 
            this.btn_Missile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Missile.Location = new System.Drawing.Point(733, 387);
            this.btn_Missile.Name = "btn_Missile";
            this.btn_Missile.Size = new System.Drawing.Size(74, 23);
            this.btn_Missile.TabIndex = 1;
            this.btn_Missile.Text = "导弹动画";
            this.btn_Missile.UseVisualStyleBackColor = true;
            this.btn_Missile.Click += new System.EventHandler(this.btn_Missile_Click);
            // 
            // btn_BoatTail
            // 
            this.btn_BoatTail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_BoatTail.Location = new System.Drawing.Point(15, 61);
            this.btn_BoatTail.Name = "btn_BoatTail";
            this.btn_BoatTail.Size = new System.Drawing.Size(74, 23);
            this.btn_BoatTail.TabIndex = 1;
            this.btn_BoatTail.Text = "船尾迹";
            this.btn_BoatTail.UseVisualStyleBackColor = true;
            this.btn_BoatTail.Click += new System.EventHandler(this.btn_BoatTail_Click);
            // 
            // btn_HelicopterFly
            // 
            this.btn_HelicopterFly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_HelicopterFly.Location = new System.Drawing.Point(15, 99);
            this.btn_HelicopterFly.Name = "btn_HelicopterFly";
            this.btn_HelicopterFly.Size = new System.Drawing.Size(74, 23);
            this.btn_HelicopterFly.TabIndex = 1;
            this.btn_HelicopterFly.Text = "直升机涡轮";
            this.btn_HelicopterFly.UseVisualStyleBackColor = true;
            this.btn_HelicopterFly.Click += new System.EventHandler(this.btn_HelicopterFly_Click);
            // 
            // btn_VedioProjection
            // 
            this.btn_VedioProjection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_VedioProjection.Location = new System.Drawing.Point(733, 427);
            this.btn_VedioProjection.Name = "btn_VedioProjection";
            this.btn_VedioProjection.Size = new System.Drawing.Size(74, 23);
            this.btn_VedioProjection.TabIndex = 1;
            this.btn_VedioProjection.Text = "视频投射";
            this.btn_VedioProjection.UseVisualStyleBackColor = true;
            this.btn_VedioProjection.Click += new System.EventHandler(this.btn_VedioProjection_Click);
            // 
            // btn_Spring
            // 
            this.btn_Spring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Spring.Location = new System.Drawing.Point(16, 95);
            this.btn_Spring.Name = "btn_Spring";
            this.btn_Spring.Size = new System.Drawing.Size(74, 23);
            this.btn_Spring.TabIndex = 1;
            this.btn_Spring.Text = "喷泉";
            this.btn_Spring.UseVisualStyleBackColor = true;
            this.btn_Spring.Click += new System.EventHandler(this.btn_Spring_Click);
            // 
            // btn_Particle
            // 
            this.btn_Particle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Particle.Location = new System.Drawing.Point(15, 23);
            this.btn_Particle.Name = "btn_Particle";
            this.btn_Particle.Size = new System.Drawing.Size(74, 23);
            this.btn_Particle.TabIndex = 1;
            this.btn_Particle.Text = "粒子系统";
            this.btn_Particle.UseVisualStyleBackColor = true;
            this.btn_Particle.Click += new System.EventHandler(this.btn_Particle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_Particle);
            this.groupBox1.Controls.Add(this.btn_Fire);
            this.groupBox1.Controls.Add(this.btn_Spring);
            this.groupBox1.Location = new System.Drawing.Point(717, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 129);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "粒子系统";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_BoatTail);
            this.groupBox2.Controls.Add(this.btn_HelicopterFly);
            this.groupBox2.Controls.Add(this.btn_Ocean);
            this.groupBox2.Location = new System.Drawing.Point(717, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(107, 136);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "海水效果";
            // 
            // timer1
            // 
            this.timer_tail.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer2
            // 
            this.timer_Rotor.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmSpecialEffects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 619);
            this.Controls.Add(this.btn_VedioProjection);
            this.Controls.Add(this.btn_Missile);
            this.Controls.Add(this.btn_PlanMove);
            this.Controls.Add(this.btn_CameraMovie);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmSpecialEffects";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "三维特效";
            this.Load += new System.EventHandler(this.FrmSpecialEffects_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Ocean;
        private System.Windows.Forms.Button btn_CameraMovie;
        private System.Windows.Forms.Button btn_Fire;
        private System.Windows.Forms.Button btn_PlanMove;
        private System.Windows.Forms.Button btn_Missile;
        private System.Windows.Forms.Button btn_BoatTail;
        private System.Windows.Forms.Button btn_HelicopterFly;
        private System.Windows.Forms.Button btn_VedioProjection;
        private System.Windows.Forms.Button btn_Spring;
        private System.Windows.Forms.Button btn_Particle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer_tail;
        private System.Windows.Forms.Timer timer_Rotor;
        private System.Windows.Forms.Timer timerPlayVideo;
    }
}

