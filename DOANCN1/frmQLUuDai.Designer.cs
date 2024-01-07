namespace DOANCN1
{
    partial class frmQLUuDai
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvUuDai = new System.Windows.Forms.DataGridView();
            this.MaUuDai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiUuDai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenUD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DieuKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cbbLoaiUD = new System.Windows.Forms.ComboBox();
            this.txtChiTiet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDieuKien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenUD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaUD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUuDai)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.dgvUuDai);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.cbbLoaiUD);
            this.groupBox1.Controls.Add(this.txtChiTiet);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDieuKien);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTenUD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaUD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1134, 566);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(698, 144);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(96, 43);
            this.btnLamMoi.TabIndex = 19;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DOANCN1.Properties.Resources.gift;
            this.pictureBox1.Location = new System.Drawing.Point(836, 267);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // dgvUuDai
            // 
            this.dgvUuDai.AllowUserToAddRows = false;
            this.dgvUuDai.AllowUserToDeleteRows = false;
            this.dgvUuDai.ColumnHeadersHeight = 50;
            this.dgvUuDai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaUuDai,
            this.LoaiUuDai,
            this.TenUD,
            this.DieuKien,
            this.ChiTiet});
            this.dgvUuDai.Location = new System.Drawing.Point(26, 208);
            this.dgvUuDai.Name = "dgvUuDai";
            this.dgvUuDai.ReadOnly = true;
            this.dgvUuDai.RowHeadersVisible = false;
            this.dgvUuDai.Size = new System.Drawing.Size(783, 346);
            this.dgvUuDai.TabIndex = 17;
            this.dgvUuDai.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUuDai_CellClick);
            // 
            // MaUuDai
            // 
            this.MaUuDai.HeaderText = "Mã ưu đãi";
            this.MaUuDai.Name = "MaUuDai";
            this.MaUuDai.ReadOnly = true;
            this.MaUuDai.Width = 120;
            // 
            // LoaiUuDai
            // 
            this.LoaiUuDai.HeaderText = "Loại ưu đãi";
            this.LoaiUuDai.Name = "LoaiUuDai";
            this.LoaiUuDai.ReadOnly = true;
            this.LoaiUuDai.Width = 120;
            // 
            // TenUD
            // 
            this.TenUD.HeaderText = "Tên ưu đãi";
            this.TenUD.Name = "TenUD";
            this.TenUD.ReadOnly = true;
            this.TenUD.Width = 170;
            // 
            // DieuKien
            // 
            this.DieuKien.HeaderText = "Điều kiện";
            this.DieuKien.Name = "DieuKien";
            this.DieuKien.ReadOnly = true;
            this.DieuKien.Width = 110;
            // 
            // ChiTiet
            // 
            this.ChiTiet.HeaderText = "Chi tiết";
            this.ChiTiet.Name = "ChiTiet";
            this.ChiTiet.ReadOnly = true;
            this.ChiTiet.Width = 260;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(523, 144);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(96, 43);
            this.btnTimKiem.TabIndex = 16;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(354, 144);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 43);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(195, 144);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(96, 43);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(41, 144);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 43);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbbLoaiUD
            // 
            this.cbbLoaiUD.FormattingEnabled = true;
            this.cbbLoaiUD.Items.AddRange(new object[] {
            "Tặng quà",
            "Giảm giá"});
            this.cbbLoaiUD.Location = new System.Drawing.Point(244, 74);
            this.cbbLoaiUD.Name = "cbbLoaiUD";
            this.cbbLoaiUD.Size = new System.Drawing.Size(131, 30);
            this.cbbLoaiUD.TabIndex = 12;
            // 
            // txtChiTiet
            // 
            this.txtChiTiet.Location = new System.Drawing.Point(836, 74);
            this.txtChiTiet.Multiline = true;
            this.txtChiTiet.Name = "txtChiTiet";
            this.txtChiTiet.Size = new System.Drawing.Size(226, 113);
            this.txtChiTiet.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(832, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Chi tiết:";
            // 
            // txtDieuKien
            // 
            this.txtDieuKien.Location = new System.Drawing.Point(611, 73);
            this.txtDieuKien.Name = "txtDieuKien";
            this.txtDieuKien.Size = new System.Drawing.Size(131, 29);
            this.txtDieuKien.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điều kiện (>=tổng tiền):";
            // 
            // txtTenUD
            // 
            this.txtTenUD.Location = new System.Drawing.Point(424, 73);
            this.txtTenUD.Name = "txtTenUD";
            this.txtTenUD.Size = new System.Drawing.Size(131, 29);
            this.txtTenUD.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên ưu đãi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại ưu đãi:";
            // 
            // txtMaUD
            // 
            this.txtMaUD.Location = new System.Drawing.Point(67, 74);
            this.txtMaUD.Name = "txtMaUD";
            this.txtMaUD.Size = new System.Drawing.Size(131, 29);
            this.txtMaUD.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã ưu đãi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Slab", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(490, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản lý ưu đãi";
            // 
            // frmQLUuDai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 566);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Roboto Slab", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "frmQLUuDai";
            this.Text = "frmQLUuDai";
            this.Load += new System.EventHandler(this.frmQLUuDai_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUuDai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtChiTiet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDieuKien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbbLoaiUD;
        private System.Windows.Forms.DataGridView dgvUuDai;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaUuDai;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiUuDai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DieuKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiTiet;
        private System.Windows.Forms.Button btnLamMoi;
    }
}