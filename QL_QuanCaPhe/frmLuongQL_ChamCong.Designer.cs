
namespace QL_QuanCaPhe
{
    partial class frmLuongQL_ChamCong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.btnXoaChamCong = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.data_gv_ChamCong = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuuChamCong = new System.Windows.Forms.Button();
            this.txtGhiChu_ChamCong = new DevExpress.XtraEditors.TextEdit();
            this.label34 = new System.Windows.Forms.Label();
            this.txtNgayLam_QL = new DevExpress.XtraEditors.DateEdit();
            this.cbox_MaCC = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_gv_ChamCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu_ChamCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLam_QL.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLam_QL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label35);
            this.panel3.Controls.Add(this.btnXoaChamCong);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.btnLuuChamCong);
            this.panel3.Controls.Add(this.txtGhiChu_ChamCong);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Controls.Add(this.txtNgayLam_QL);
            this.panel3.Controls.Add(this.cbox_MaCC);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(871, 340);
            this.panel3.TabIndex = 48;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(16, 88);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(73, 21);
            this.label35.TabIndex = 59;
            this.label35.Text = "Ghi chú:";
            // 
            // btnXoaChamCong
            // 
            this.btnXoaChamCong.BackColor = System.Drawing.Color.White;
            this.btnXoaChamCong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaChamCong.Image = global::QL_QuanCaPhe.Properties.Resources.icon_remove;
            this.btnXoaChamCong.Location = new System.Drawing.Point(612, 34);
            this.btnXoaChamCong.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaChamCong.Name = "btnXoaChamCong";
            this.btnXoaChamCong.Size = new System.Drawing.Size(81, 41);
            this.btnXoaChamCong.TabIndex = 29;
            this.btnXoaChamCong.Text = "Xóa";
            this.btnXoaChamCong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaChamCong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaChamCong.UseVisualStyleBackColor = false;
            this.btnXoaChamCong.Click += new System.EventHandler(this.btnXoaChamCong_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.data_gv_ChamCong);
            this.groupBox3.Location = new System.Drawing.Point(17, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(844, 215);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chấm công lương";
            // 
            // data_gv_ChamCong
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.data_gv_ChamCong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.data_gv_ChamCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_gv_ChamCong.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.data_gv_ChamCong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.data_gv_ChamCong.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.data_gv_ChamCong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_gv_ChamCong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.data_gv_ChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_gv_ChamCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_gv_ChamCong.DefaultCellStyle = dataGridViewCellStyle3;
            this.data_gv_ChamCong.EnableHeadersVisualStyles = false;
            this.data_gv_ChamCong.Location = new System.Drawing.Point(6, 19);
            this.data_gv_ChamCong.Name = "data_gv_ChamCong";
            this.data_gv_ChamCong.ReadOnly = true;
            this.data_gv_ChamCong.RowHeadersWidth = 45;
            this.data_gv_ChamCong.RowTemplate.Height = 30;
            this.data_gv_ChamCong.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.data_gv_ChamCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_gv_ChamCong.Size = new System.Drawing.Size(835, 177);
            this.data_gv_ChamCong.TabIndex = 34;
            this.data_gv_ChamCong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_gv_ChamCong_CellClick);
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "MACHAMCONG";
            this.Column15.HeaderText = "Mã chấm công";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "MABANGLUONG";
            this.Column16.HeaderText = "Bảng lương";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "HOTEN";
            this.Column17.HeaderText = "Mã nhân viên";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "MACA";
            this.Column18.HeaderText = "Ca làm";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "NGAYLAM";
            this.Column19.HeaderText = "Ngày làm";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "GHICHU";
            this.Column20.HeaderText = "Ghi chú";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            // 
            // btnLuuChamCong
            // 
            this.btnLuuChamCong.BackColor = System.Drawing.Color.White;
            this.btnLuuChamCong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuChamCong.Image = global::QL_QuanCaPhe.Properties.Resources.icon_save;
            this.btnLuuChamCong.Location = new System.Drawing.Point(511, 34);
            this.btnLuuChamCong.Margin = new System.Windows.Forms.Padding(2);
            this.btnLuuChamCong.Name = "btnLuuChamCong";
            this.btnLuuChamCong.Size = new System.Drawing.Size(83, 41);
            this.btnLuuChamCong.TabIndex = 41;
            this.btnLuuChamCong.Text = "Lưu";
            this.btnLuuChamCong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuChamCong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuChamCong.UseVisualStyleBackColor = false;
            this.btnLuuChamCong.Click += new System.EventHandler(this.btnLuuChamCong_Click);
            // 
            // txtGhiChu_ChamCong
            // 
            this.txtGhiChu_ChamCong.Location = new System.Drawing.Point(145, 89);
            this.txtGhiChu_ChamCong.Name = "txtGhiChu_ChamCong";
            this.txtGhiChu_ChamCong.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu_ChamCong.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu_ChamCong.Size = new System.Drawing.Size(347, 22);
            this.txtGhiChu_ChamCong.TabIndex = 58;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(16, 60);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 21);
            this.label34.TabIndex = 56;
            this.label34.Text = "Ngày làm:";
            // 
            // txtNgayLam_QL
            // 
            this.txtNgayLam_QL.EditValue = null;
            this.txtNgayLam_QL.Location = new System.Drawing.Point(145, 61);
            this.txtNgayLam_QL.Name = "txtNgayLam_QL";
            this.txtNgayLam_QL.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayLam_QL.Properties.Appearance.Options.UseFont = true;
            this.txtNgayLam_QL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgayLam_QL.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgayLam_QL.Properties.DisplayFormat.FormatString = "";
            this.txtNgayLam_QL.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtNgayLam_QL.Properties.EditFormat.FormatString = "";
            this.txtNgayLam_QL.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtNgayLam_QL.Properties.Mask.EditMask = "";
            this.txtNgayLam_QL.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtNgayLam_QL.Size = new System.Drawing.Size(347, 22);
            this.txtNgayLam_QL.TabIndex = 57;
            // 
            // cbox_MaCC
            // 
            this.cbox_MaCC.Enabled = false;
            this.cbox_MaCC.FormattingEnabled = true;
            this.cbox_MaCC.Location = new System.Drawing.Point(145, 34);
            this.cbox_MaCC.Name = "cbox_MaCC";
            this.cbox_MaCC.Size = new System.Drawing.Size(347, 21);
            this.cbox_MaCC.TabIndex = 54;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(13, 34);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(125, 21);
            this.label31.TabIndex = 53;
            this.label31.Text = "Mã chấm công:";
            // 
            // frmLuongQL_ChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 364);
            this.Controls.Add(this.panel3);
            this.Name = "frmLuongQL_ChamCong";
            this.Text = "frmLuongQL_ChamCong";
            this.Load += new System.EventHandler(this.frmLuongQL_ChamCong_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_gv_ChamCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu_ChamCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLam_QL.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLam_QL.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btnXoaChamCong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView data_gv_ChamCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.Button btnLuuChamCong;
        private DevExpress.XtraEditors.TextEdit txtGhiChu_ChamCong;
        private System.Windows.Forms.Label label34;
        private DevExpress.XtraEditors.DateEdit txtNgayLam_QL;
        private System.Windows.Forms.ComboBox cbox_MaCC;
        private System.Windows.Forms.Label label31;
    }
}