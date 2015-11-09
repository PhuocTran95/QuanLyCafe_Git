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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        clsHDThu lstHDThu = new clsHDThu();
        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSKhachHang frmKhachHang = new frmDSKhachHang();
            this.Hide();
            frmKhachHang.ShowDialog();
            this.Show();
        }
        private void loadTreeView()
        {
            clsSanPham lstSP = new clsSanPham();
            List < SanPham > dsSP= lstSP.GetAllSP();
            treeView1.Nodes.Clear();
            TreeNode nodecha = new TreeNode("DANH SÁCH SẢN PHẨM");
            foreach (SanPham c in dsSP)
            {
                TreeNode nodecon = new TreeNode(c.loaiSP);
                nodecon.Tag = c.maSP;//lưu mã số nhà cung cấp vào thuộc tính Tag
                nodecon.Nodes.Add(c.tenSP);//thêm node con là địa chỉ trong nodeCon
                nodecha.Nodes.Add(nodecon);//thêm nodecon vào node con
            }
            treeView1.Nodes.Add(nodecha);//thêm nodecha vào TreeView
        }

        private void thêmLoạiMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSLoaiSanPham frmdsloaisanpham = new frmDSLoaiSanPham();
            this.Hide();
            frmdsloaisanpham.ShowDialog();
            this.Show();
        }

        private void thêmMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham frmsanpham = new frmSanPham();
            this.Hide();
            frmsanpham.ShowDialog();
            this.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            resetForm();
            loadTreeView();
        }

        private void resetForm()
        {
            txtMaHD.Enabled = false;
            txt_nhanviengd.Enabled = false;
            txtKhachHang.Text = "Unknown";
            btnLuu.Enabled = false;
            btnThemMH.Enabled = false;
            btnKiemTra.Enabled = false;
            btnXoaMH.Enabled = false;
            txtMaHD.Text = lstHDThu.createMaHD();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(btnThem.Text=="Thêm")
            {
                btnThem.Text = "Hủy";
                txtKhachHang.Text = "Unknown";
                btnLuu.Enabled = true;
                btnThemMH.Enabled = true;
                btnKiemTra.Enabled = true;
                btnXoaMH.Enabled = true;
            }
            else
            {
                resetForm();
                btnThem.Text = "Thêm";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tongtien = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    tongtien = decimal.Parse(dataGridView1.Rows[i].Cells["dongia"].Value.ToString());
                }
                txtTongTien.Text = tongtien.ToString();
                HoaDon hd = new HoaDon();
                hd.maHD = txtMaHD.Text;
                hd.maNV = txt_nhanviengd.Text;
                hd.ngaylapHD = DateTime.Now;
                hd.phuthu = decimal.Parse(txtPhuThu.Text);
                hd.giamgia = decimal.Parse(txtGiamGia.Text);
                hd.tongtien = tongtien - hd.giamgia + hd.phuthu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
            resetForm();
            btnThem.Text = "Thêm";
        }

        private void thuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHDThu frmgdthu = new frmHDThu();
            this.Hide();
            frmgdthu.ShowDialog();
            this.Show();
        }

        private void nguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNguyenLieu frmnguyenlieu = new frmNguyenLieu();
            this.Hide();
            frmnguyenlieu.ShowDialog();
            this.Show();
        }

        private void nhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frmnhanvien = new frmNhanVien();
            this.Hide();
            frmnhanvien.ShowDialog();
            this.Show();
        }
    }
}
