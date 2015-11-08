namespace Presentation
{
    partial class frmDSKhachHang
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
            this.lblDangNhap = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cbxKhachHangTT = new System.Windows.Forms.CheckBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDanhSachKH = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboLoaiTK = new System.Windows.Forms.ComboBox();
            this.lblLoaiTK = new System.Windows.Forms.Label();
            this.txtThongTinTK = new System.Windows.Forms.TextBox();
            this.lblThongTinTK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDangNhap
            // 
            this.lblDangNhap.AutoSize = true;
            this.lblDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangNhap.ForeColor = System.Drawing.Color.Blue;
            this.lblDangNhap.Location = new System.Drawing.Point(207, 9);
            this.lblDangNhap.Name = "lblDangNhap";
            this.lblDangNhap.Size = new System.Drawing.Size(384, 31);
            this.lblDangNhap.TabIndex = 0;
            this.lblDangNhap.Text = "DANH SÁCH KHÁCH HÀNG";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 223);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 232);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.cbxKhachHangTT);
            this.groupBox1.Controls.Add(this.txtCMND);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Controls.Add(this.lblCMND);
            this.groupBox1.Controls.Add(this.lblTenKH);
            this.groupBox1.Controls.Add(this.txtMaKH);
            this.groupBox1.Controls.Add(this.lblMaKH);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 174);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(344, 34);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(344, 136);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(344, 103);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Chỉnh sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(344, 69);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbxKhachHangTT
            // 
            this.cbxKhachHangTT.AutoSize = true;
            this.cbxKhachHangTT.Location = new System.Drawing.Point(118, 143);
            this.cbxKhachHangTT.Name = "cbxKhachHangTT";
            this.cbxKhachHangTT.Size = new System.Drawing.Size(137, 17);
            this.cbxKhachHangTT.TabIndex = 6;
            this.cbxKhachHangTT.Text = "Khách hàng thân thiết?";
            this.cbxKhachHangTT.UseVisualStyleBackColor = true;
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(118, 106);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(202, 20);
            this.txtCMND.TabIndex = 5;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(118, 71);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(202, 20);
            this.txtTenKH.TabIndex = 3;
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Location = new System.Drawing.Point(27, 109);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(58, 13);
            this.lblCMND.TabIndex = 4;
            this.lblCMND.Text = "Số CMND:";
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(27, 74);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(89, 13);
            this.lblTenKH.TabIndex = 2;
            this.lblTenKH.Text = "Tên khách hàng:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(118, 36);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(202, 20);
            this.txtMaKH.TabIndex = 1;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(27, 39);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(85, 13);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã khách hàng:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDanhSachKH);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.cboLoaiTK);
            this.groupBox2.Controls.Add(this.lblLoaiTK);
            this.groupBox2.Controls.Add(this.txtThongTinTK);
            this.groupBox2.Controls.Add(this.lblThongTinTK);
            this.groupBox2.Location = new System.Drawing.Point(455, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 174);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // btnDanhSachKH
            // 
            this.btnDanhSachKH.Location = new System.Drawing.Point(103, 136);
            this.btnDanhSachKH.Name = "btnDanhSachKH";
            this.btnDanhSachKH.Size = new System.Drawing.Size(127, 23);
            this.btnDanhSachKH.TabIndex = 5;
            this.btnDanhSachKH.Text = "Danh sách khách hàng";
            this.btnDanhSachKH.UseVisualStyleBackColor = true;
            this.btnDanhSachKH.Click += new System.EventHandler(this.btnDanhSachKH_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(236, 136);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cboLoaiTK
            // 
            this.cboLoaiTK.FormattingEnabled = true;
            this.cboLoaiTK.Items.AddRange(new object[] {
            "Tìm kiếm theo Mã khách hàng",
            "Tìm kiếm theo Tên khách hàng"});
            this.cboLoaiTK.Location = new System.Drawing.Point(105, 71);
            this.cboLoaiTK.Name = "cboLoaiTK";
            this.cboLoaiTK.Size = new System.Drawing.Size(202, 21);
            this.cboLoaiTK.TabIndex = 3;
            // 
            // lblLoaiTK
            // 
            this.lblLoaiTK.AutoSize = true;
            this.lblLoaiTK.Location = new System.Drawing.Point(8, 74);
            this.lblLoaiTK.Name = "lblLoaiTK";
            this.lblLoaiTK.Size = new System.Drawing.Size(71, 13);
            this.lblLoaiTK.TabIndex = 2;
            this.lblLoaiTK.Text = "Loại tìm kiếm:";
            // 
            // txtThongTinTK
            // 
            this.txtThongTinTK.Location = new System.Drawing.Point(105, 36);
            this.txtThongTinTK.Name = "txtThongTinTK";
            this.txtThongTinTK.Size = new System.Drawing.Size(202, 20);
            this.txtThongTinTK.TabIndex = 1;
            // 
            // lblThongTinTK
            // 
            this.lblThongTinTK.AutoSize = true;
            this.lblThongTinTK.Location = new System.Drawing.Point(8, 39);
            this.lblThongTinTK.Name = "lblThongTinTK";
            this.lblThongTinTK.Size = new System.Drawing.Size(96, 13);
            this.lblThongTinTK.TabIndex = 0;
            this.lblThongTinTK.Text = "Thông tin tìm kiếm:";
            // 
            // frmDSKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblDangNhap);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmDSKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách khách hàng";
            this.Load += new System.EventHandler(this.frmDSKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDangNhap;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.CheckBox cbxKhachHangTT;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cboLoaiTK;
        private System.Windows.Forms.Label lblLoaiTK;
        private System.Windows.Forms.TextBox txtThongTinTK;
        private System.Windows.Forms.Label lblThongTinTK;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDanhSachKH;
    }
}