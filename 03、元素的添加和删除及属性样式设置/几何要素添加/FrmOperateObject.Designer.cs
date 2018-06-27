namespace OperateObject
{
    partial class FrmOperateObject
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
            this.btn_Sphere = new System.Windows.Forms.Button();
            this.btn_NotchEllipsolid = new System.Windows.Forms.Button();
            this.btn_Box = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_EllipseFrustum = new System.Windows.Forms.Button();
            this.btn_Frustum = new System.Windows.Forms.Button();
            this.btn_Ellipsolid = new System.Windows.Forms.Button();
            this.btn_Circle = new System.Windows.Forms.Button();
            this.btn_EllipsePie = new System.Windows.Forms.Button();
            this.btn_Ellipse = new System.Windows.Forms.Button();
            this.btn_Polygon = new System.Windows.Forms.Button();
            this.btn_Rect = new System.Windows.Forms.Button();
            this.btn_point = new System.Windows.Forms.Button();
            this.btn_Polyline = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Water = new System.Windows.Forms.Button();
            this.btn_MoveObj = new System.Windows.Forms.Button();
            this.btn_DynamicMarker = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(588, 620);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_Sphere);
            this.groupBox1.Controls.Add(this.btn_NotchEllipsolid);
            this.groupBox1.Controls.Add(this.btn_Box);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_EllipseFrustum);
            this.groupBox1.Controls.Add(this.btn_Frustum);
            this.groupBox1.Controls.Add(this.btn_Ellipsolid);
            this.groupBox1.Controls.Add(this.btn_Circle);
            this.groupBox1.Controls.Add(this.btn_EllipsePie);
            this.groupBox1.Controls.Add(this.btn_Ellipse);
            this.groupBox1.Controls.Add(this.btn_Polygon);
            this.groupBox1.Controls.Add(this.btn_Rect);
            this.groupBox1.Controls.Add(this.btn_point);
            this.groupBox1.Controls.Add(this.btn_Polyline);
            this.groupBox1.Location = new System.Drawing.Point(592, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 454);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "几何对象";
            // 
            // btn_Sphere
            // 
            this.btn_Sphere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sphere.Location = new System.Drawing.Point(20, 237);
            this.btn_Sphere.Name = "btn_Sphere";
            this.btn_Sphere.Size = new System.Drawing.Size(75, 23);
            this.btn_Sphere.TabIndex = 0;
            this.btn_Sphere.Text = "球";
            this.btn_Sphere.UseVisualStyleBackColor = true;
            this.btn_Sphere.Click += new System.EventHandler(this.btn_Sphere_Click);
            // 
            // btn_NotchEllipsolid
            // 
            this.btn_NotchEllipsolid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NotchEllipsolid.Location = new System.Drawing.Point(20, 299);
            this.btn_NotchEllipsolid.Name = "btn_NotchEllipsolid";
            this.btn_NotchEllipsolid.Size = new System.Drawing.Size(75, 23);
            this.btn_NotchEllipsolid.TabIndex = 0;
            this.btn_NotchEllipsolid.Text = "缺口椭球";
            this.btn_NotchEllipsolid.UseVisualStyleBackColor = true;
            this.btn_NotchEllipsolid.Click += new System.EventHandler(this.btn_NotchEllipsolid_Click);
            // 
            // btn_Box
            // 
            this.btn_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Box.Location = new System.Drawing.Point(20, 423);
            this.btn_Box.Name = "btn_Box";
            this.btn_Box.Size = new System.Drawing.Size(75, 23);
            this.btn_Box.TabIndex = 0;
            this.btn_Box.Text = "立方体";
            this.btn_Box.UseVisualStyleBackColor = true;
            this.btn_Box.Click += new System.EventHandler(this.btn_Box_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(20, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "缺口台柱";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_NotchFrustum_Click);
            // 
            // btn_EllipseFrustum
            // 
            this.btn_EllipseFrustum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EllipseFrustum.Location = new System.Drawing.Point(20, 361);
            this.btn_EllipseFrustum.Name = "btn_EllipseFrustum";
            this.btn_EllipseFrustum.Size = new System.Drawing.Size(75, 23);
            this.btn_EllipseFrustum.TabIndex = 0;
            this.btn_EllipseFrustum.Text = "椭圆台柱";
            this.btn_EllipseFrustum.UseVisualStyleBackColor = true;
            this.btn_EllipseFrustum.Click += new System.EventHandler(this.btn_EllipseFrustum_Click);
            // 
            // btn_Frustum
            // 
            this.btn_Frustum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Frustum.Location = new System.Drawing.Point(20, 330);
            this.btn_Frustum.Name = "btn_Frustum";
            this.btn_Frustum.Size = new System.Drawing.Size(75, 23);
            this.btn_Frustum.TabIndex = 0;
            this.btn_Frustum.Text = "普通台柱";
            this.btn_Frustum.UseVisualStyleBackColor = true;
            this.btn_Frustum.Click += new System.EventHandler(this.btn_Frustum_Click);
            // 
            // btn_Ellipsolid
            // 
            this.btn_Ellipsolid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ellipsolid.Location = new System.Drawing.Point(20, 268);
            this.btn_Ellipsolid.Name = "btn_Ellipsolid";
            this.btn_Ellipsolid.Size = new System.Drawing.Size(75, 23);
            this.btn_Ellipsolid.TabIndex = 0;
            this.btn_Ellipsolid.Text = "椭球";
            this.btn_Ellipsolid.UseVisualStyleBackColor = true;
            this.btn_Ellipsolid.Click += new System.EventHandler(this.btn_Ellipsolid_Click);
            // 
            // btn_Circle
            // 
            this.btn_Circle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Circle.Location = new System.Drawing.Point(20, 144);
            this.btn_Circle.Name = "btn_Circle";
            this.btn_Circle.Size = new System.Drawing.Size(75, 23);
            this.btn_Circle.TabIndex = 0;
            this.btn_Circle.Text = "圆";
            this.btn_Circle.UseVisualStyleBackColor = true;
            this.btn_Circle.Click += new System.EventHandler(this.btn_Circle_Click);
            // 
            // btn_EllipsePie
            // 
            this.btn_EllipsePie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EllipsePie.Location = new System.Drawing.Point(20, 206);
            this.btn_EllipsePie.Name = "btn_EllipsePie";
            this.btn_EllipsePie.Size = new System.Drawing.Size(75, 23);
            this.btn_EllipsePie.TabIndex = 0;
            this.btn_EllipsePie.Text = "椭圆饼";
            this.btn_EllipsePie.UseVisualStyleBackColor = true;
            this.btn_EllipsePie.Click += new System.EventHandler(this.btn_EllipsePie_Click);
            // 
            // btn_Ellipse
            // 
            this.btn_Ellipse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ellipse.Location = new System.Drawing.Point(20, 175);
            this.btn_Ellipse.Name = "btn_Ellipse";
            this.btn_Ellipse.Size = new System.Drawing.Size(75, 23);
            this.btn_Ellipse.TabIndex = 0;
            this.btn_Ellipse.Text = "椭圆";
            this.btn_Ellipse.UseVisualStyleBackColor = true;
            this.btn_Ellipse.Click += new System.EventHandler(this.btn_Ellipse_Click);
            // 
            // btn_Polygon
            // 
            this.btn_Polygon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Polygon.Location = new System.Drawing.Point(20, 82);
            this.btn_Polygon.Name = "btn_Polygon";
            this.btn_Polygon.Size = new System.Drawing.Size(75, 23);
            this.btn_Polygon.TabIndex = 0;
            this.btn_Polygon.Text = "面";
            this.btn_Polygon.UseVisualStyleBackColor = true;
            this.btn_Polygon.Click += new System.EventHandler(this.btn_Polygon_Click);
            // 
            // btn_Rect
            // 
            this.btn_Rect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Rect.Location = new System.Drawing.Point(20, 113);
            this.btn_Rect.Name = "btn_Rect";
            this.btn_Rect.Size = new System.Drawing.Size(75, 23);
            this.btn_Rect.TabIndex = 0;
            this.btn_Rect.Text = "矩形";
            this.btn_Rect.UseVisualStyleBackColor = true;
            this.btn_Rect.Click += new System.EventHandler(this.btn_Rect_Click);
            // 
            // btn_point
            // 
            this.btn_point.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_point.Location = new System.Drawing.Point(20, 20);
            this.btn_point.Name = "btn_point";
            this.btn_point.Size = new System.Drawing.Size(75, 23);
            this.btn_point.TabIndex = 0;
            this.btn_point.Text = "点";
            this.btn_point.UseVisualStyleBackColor = true;
            this.btn_point.Click += new System.EventHandler(this.btn_point_Click);
            // 
            // btn_Polyline
            // 
            this.btn_Polyline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Polyline.Location = new System.Drawing.Point(20, 51);
            this.btn_Polyline.Name = "btn_Polyline";
            this.btn_Polyline.Size = new System.Drawing.Size(75, 23);
            this.btn_Polyline.TabIndex = 0;
            this.btn_Polyline.Text = "线";
            this.btn_Polyline.UseVisualStyleBackColor = true;
            this.btn_Polyline.Click += new System.EventHandler(this.btn_Polyline_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_Water);
            this.groupBox2.Controls.Add(this.btn_MoveObj);
            this.groupBox2.Controls.Add(this.btn_DynamicMarker);
            this.groupBox2.Location = new System.Drawing.Point(592, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 106);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "动态对象";
            // 
            // btn_Water
            // 
            this.btn_Water.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Water.Location = new System.Drawing.Point(20, 77);
            this.btn_Water.Name = "btn_Water";
            this.btn_Water.Size = new System.Drawing.Size(75, 23);
            this.btn_Water.TabIndex = 0;
            this.btn_Water.Text = "水面";
            this.btn_Water.UseVisualStyleBackColor = true;
            this.btn_Water.Click += new System.EventHandler(this.btn_Water_Click);
            // 
            // btn_MoveObj
            // 
            this.btn_MoveObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MoveObj.Location = new System.Drawing.Point(20, 48);
            this.btn_MoveObj.Name = "btn_MoveObj";
            this.btn_MoveObj.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveObj.TabIndex = 0;
            this.btn_MoveObj.Text = "运动对象";
            this.btn_MoveObj.UseVisualStyleBackColor = true;
            this.btn_MoveObj.Click += new System.EventHandler(this.btn_MoveObj_Click);
            // 
            // btn_DynamicMarker
            // 
            this.btn_DynamicMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DynamicMarker.Location = new System.Drawing.Point(20, 20);
            this.btn_DynamicMarker.Name = "btn_DynamicMarker";
            this.btn_DynamicMarker.Size = new System.Drawing.Size(75, 23);
            this.btn_DynamicMarker.TabIndex = 0;
            this.btn_DynamicMarker.Text = "动态标注";
            this.btn_DynamicMarker.UseVisualStyleBackColor = true;
            this.btn_DynamicMarker.Click += new System.EventHandler(this.btn_DynamicMarker_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear.Location = new System.Drawing.Point(612, 587);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 1;
            this.btn_Clear.Text = "清除要素";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // FrmOperateObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 620);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(736, 616);
            this.Name = "FrmOperateObject";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对象操作";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_point;
        private System.Windows.Forms.Button btn_Sphere;
        private System.Windows.Forms.Button btn_Ellipsolid;
        private System.Windows.Forms.Button btn_Circle;
        private System.Windows.Forms.Button btn_Ellipse;
        private System.Windows.Forms.Button btn_Polygon;
        private System.Windows.Forms.Button btn_Rect;
        private System.Windows.Forms.Button btn_NotchEllipsolid;
        private System.Windows.Forms.Button btn_EllipseFrustum;
        private System.Windows.Forms.Button btn_Frustum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_DynamicMarker;
        private System.Windows.Forms.Button btn_MoveObj;
        private System.Windows.Forms.Button btn_Water;
        private System.Windows.Forms.Button btn_EllipsePie;
        private System.Windows.Forms.Button btn_Polyline;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Box;
        private System.Windows.Forms.Button btn_Clear;
    }
}

