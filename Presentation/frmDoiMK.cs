using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace Presentation
{
    public partial class frmDoiMK : Form
    {
        public frmDoiMK()
        {
            InitializeComponent();
        }
        NhanVien nv = new NhanVien();
        clsNhanVien clNV = new clsNhanVien();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text != "" && txtMKC.Text != "")
            {
                nv = clNV.searchTheoMa(frmMain.maNV);
                if (nv.matkhauNV == txtMKC.Text)
                {
                    nv.matkhauNV=txtMatKhau.Text;
                    clNV.UpdateNhanVien(nv);
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẫu cũ không chính xác", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu cũ và Mật khẩu mới", "Lỗi");
            }
        }
    }
}
