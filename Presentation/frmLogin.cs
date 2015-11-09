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
        List<NhanVien> lst = new List<NhanVien>();
        clsNhanVien clNV = new clsNhanVien();
        private void frmLogin_Load(object sender, EventArgs e)
        {
            lst = clNV.GetAllNhanVien();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text != "" && txtMaNV.Text != "")
            {

                foreach (NhanVien n in lst)
                {
                    if (n.maNV == txtMaNV.Text && n.matkhauNV == txtMatKhau.Text)
                    {
                        this.Hide();
                        frmMain frm = new frmMain();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai IP hoặc PassWord");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID hoặc Password");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
