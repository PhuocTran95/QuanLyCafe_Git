using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BusinessLogic;

namespace Presentation
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        NhanVien nv = new NhanVien();
        clsNhanVien clNV = new clsNhanVien();
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text != "" && txtMaNV.Text != "")
            {
                try
                {
                    nv = clNV.searchTheoMa(txtMaNV.Text);
                    if (nv.maNV != null)
                    {
                        if (nv.matkhauNV == txtMatKhau.Text)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                            frmMain.maNV = txtMaNV.Text;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sai mật khẩu", "Lỗi");
                        }
                    }
                    else
                        MessageBox.Show("Mã NV không tồn tại", "Lỗi");
                }
                catch { MessageBox.Show("Mã NV không tồn tại hoặc sai mật khẩu", "Lỗi"); }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã NV và mật khẩu","Lỗi");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
