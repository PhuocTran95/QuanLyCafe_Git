namespace Presentation
{
    partial class frmLogin
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.lbl_matkhau = new System.Windows.Forms.Label();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.lbl_dangnhap = new System.Windows.Forms.Label();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.txt_manv = new System.Windows.Forms.TextBox();
            this.lbl_manv = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(145, 132);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Hiện mật khẩu";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txt_matkhau.Location = new System.Drawing.Point(145, 98);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.Size = new System.Drawing.Size(200, 26);
            this.txt_matkhau.TabIndex = 14;
            this.txt_matkhau.UseSystemPasswordChar = true;
            // 
            // lbl_matkhau
            // 
            this.lbl_matkhau.AutoSize = true;
            this.lbl_matkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_matkhau.Location = new System.Drawing.Point(28, 101);
            this.lbl_matkhau.Name = "lbl_matkhau";
            this.lbl_matkhau.Size = new System.Drawing.Size(81, 20);
            this.lbl_matkhau.TabIndex = 13;
            this.lbl_matkhau.Text = "Mật khẩu:";
            // 
            // btn_thoat
            // 
            this.btn_thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_thoat.Location = new System.Drawing.Point(198, 172);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(147, 56);
            this.btn_thoat.TabIndex = 17;
            this.btn_thoat.Text = "THOÁT";
            this.btn_thoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_thoat.UseVisualStyleBackColor = true;
            // 
            // lbl_dangnhap
            // 
            this.lbl_dangnhap.AutoSize = true;
            this.lbl_dangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dangnhap.ForeColor = System.Drawing.Color.Blue;
            this.lbl_dangnhap.Location = new System.Drawing.Point(18, 14);
            this.lbl_dangnhap.Name = "lbl_dangnhap";
            this.lbl_dangnhap.Size = new System.Drawing.Size(345, 31);
            this.lbl_dangnhap.TabIndex = 8;
            this.lbl_dangnhap.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_dangnhap.Location = new System.Drawing.Point(32, 172);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(147, 56);
            this.btn_dangnhap.TabIndex = 16;
            this.btn_dangnhap.Text = "ĐĂNG NHẬP";
            this.btn_dangnhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_dangnhap.UseVisualStyleBackColor = true;
            // 
            // txt_manv
            // 
            this.txt_manv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txt_manv.Location = new System.Drawing.Point(145, 66);
            this.txt_manv.Name = "txt_manv";
            this.txt_manv.Size = new System.Drawing.Size(200, 26);
            this.txt_manv.TabIndex = 11;
            // 
            // lbl_manv
            // 
            this.lbl_manv.AutoSize = true;
            this.lbl_manv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_manv.Location = new System.Drawing.Point(28, 69);
            this.lbl_manv.Name = "lbl_manv";
            this.lbl_manv.Size = new System.Drawing.Size(111, 20);
            this.lbl_manv.TabIndex = 10;
            this.lbl_manv.Text = "Mã nhân viên:";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 242);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txt_matkhau);
            this.Controls.Add(this.lbl_matkhau);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.lbl_dangnhap);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.txt_manv);
            this.Controls.Add(this.lbl_manv);
            this.MaximumSize = new System.Drawing.Size(396, 281);
            this.MinimumSize = new System.Drawing.Size(396, 281);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.Label lbl_matkhau;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Label lbl_dangnhap;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.TextBox txt_manv;
        private System.Windows.Forms.Label lbl_manv;

    }
}