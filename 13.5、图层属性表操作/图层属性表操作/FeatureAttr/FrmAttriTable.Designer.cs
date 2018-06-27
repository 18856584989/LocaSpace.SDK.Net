namespace LayerAttriTableEdit
{
    partial class FrmAttriTable
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_AddField = new System.Windows.Forms.Button();
            this.btn_EditTable = new System.Windows.Forms.Button();
            this.MenuStrip_FeatureEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_Locate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_DeleteFeature = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.MenuStrip_FeatureEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(158, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(610, 487);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Delete);
            this.panel1.Controls.Add(this.btn_AddField);
            this.panel1.Controls.Add(this.btn_EditTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 487);
            this.panel1.TabIndex = 1;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Enabled = false;
            this.btn_Delete.Location = new System.Drawing.Point(23, 103);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(109, 23);
            this.btn_Delete.TabIndex = 0;
            this.btn_Delete.Text = "删除字段";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_AddField
            // 
            this.btn_AddField.Enabled = false;
            this.btn_AddField.Location = new System.Drawing.Point(23, 63);
            this.btn_AddField.Name = "btn_AddField";
            this.btn_AddField.Size = new System.Drawing.Size(109, 23);
            this.btn_AddField.TabIndex = 0;
            this.btn_AddField.Text = "添加字段";
            this.btn_AddField.UseVisualStyleBackColor = true;
            this.btn_AddField.Click += new System.EventHandler(this.btn_AddField_Click);
            // 
            // btn_EditTable
            // 
            this.btn_EditTable.Location = new System.Drawing.Point(23, 24);
            this.btn_EditTable.Name = "btn_EditTable";
            this.btn_EditTable.Size = new System.Drawing.Size(109, 23);
            this.btn_EditTable.TabIndex = 0;
            this.btn_EditTable.Text = "编辑表格";
            this.btn_EditTable.UseVisualStyleBackColor = true;
            this.btn_EditTable.Click += new System.EventHandler(this.btn_EditTable_Click);
            // 
            // MenuStrip_FeatureEdit
            // 
            this.MenuStrip_FeatureEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Locate,
            this.MenuItem_DeleteFeature});
            this.MenuStrip_FeatureEdit.Name = "MenuStrip_FeatureEdit";
            this.MenuStrip_FeatureEdit.Size = new System.Drawing.Size(125, 48);
            // 
            // MenuItem_Locate
            // 
            this.MenuItem_Locate.Name = "MenuItem_Locate";
            this.MenuItem_Locate.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_Locate.Text = "定位";
            // 
            // MenuItem_DeleteFeature
            // 
            this.MenuItem_DeleteFeature.Name = "MenuItem_DeleteFeature";
            this.MenuItem_DeleteFeature.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_DeleteFeature.Text = "删除记录";
            // 
            // FrmAttriTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 487);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAttriTable";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "属性表";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.MenuStrip_FeatureEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_EditTable;
        private System.Windows.Forms.Button btn_AddField;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.ContextMenuStrip MenuStrip_FeatureEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Locate;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_DeleteFeature;
    }
}