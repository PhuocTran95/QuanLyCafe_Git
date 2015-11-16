using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Transactions;
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
        public static string maNV;
        clsHDThu lstHDThu = new clsHDThu();
        clsSanPham lstSP=new clsSanPham();
        Dictionary<string,int> lstCTHT_full = new Dictionary<string,int>();
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
            List<LoaiSP> dsSP = lstSP.GetAllSP2Grid();
            treeView1.Nodes.Clear();
            TreeNode nodecha = new TreeNode("DANH SÁCH SẢN PHẨM");
            foreach (LoaiSP c in dsSP)
            {
                TreeNode nodecon = new TreeNode(c.tenLoai);
                nodecon.Tag = c.maLoai;
                foreach (SanPham s in c.SanPhams)
                {
                    nodecon.Nodes.Add(s.tenSP);
                    
                }
                nodecha.Nodes.Add(nodecon);
            }
            treeView1.Nodes.Add(nodecha);
            treeView1.ExpandAll();
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
            loadTreeView();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin frmlogin= new frmLogin();
            this.Hide();
            frmlogin.ShowDialog();
            if(maNV!="Admin")
            {
                mToolStripMenuItem.Enabled = false;
                nhânSựToolStripMenuItem.Enabled = false;
            }
            this.Show();
            txt_nhanviengd.Text = maNV;
            resetForm();
            loadTreeView();
            this.ControlBox = false;
        }

        private void resetForm()
        {
            txtMaHD.Enabled = false;
            txt_nhanviengd.Enabled = false;
            txtKhachHang.Text = "Unknown";
            btnLuu.Enabled = false;
            btnKiemTra.Enabled = false;
            btnXoaMH.Enabled = false;
            txtKhachHang.Enabled = false;
            txtPhuThu.Enabled = false;
            txtGiamGia.Enabled = false;
            txtPhuThu.Clear();
            txtGiamGia.Clear();
            txtMaHD.Text = lstHDThu.createMaHD();
            btnThemMH.Enabled = false;
            listView1.Items.Clear();
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
                txtKhachHang.Enabled = true;
                txtPhuThu.Enabled = true;
                txtGiamGia.Enabled = true;
                btnThemMH.Enabled = true;
            }
            else
            {
                resetForm();
                btnThem.Text = "Thêm";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //using (var transaction = new TransactionScope())
            //{
                try
                {
                    txtTongTien.Text = Math.Round(updateGiaTien(), 0).ToString();
                    HoaDon hd = new HoaDon();
                    hd.maHD = txtMaHD.Text;
                    hd.maNV = txt_nhanviengd.Text;
                    hd.ngaylapHD = DateTime.Now;
                    if(txtPhuThu.Text.Length>0)
                        hd.phuthu = decimal.Parse(txtPhuThu.Text);
                    if (txtGiamGia.Text.Length > 0)
                        hd.giamgia = decimal.Parse(txtGiamGia.Text);
                    hd.tongtien=updateGiaTien();
                    if (hd.phuthu > 0)
                        hd.tongtien += hd.phuthu;
                    if (hd.giamgia > 0)
                        hd.tongtien -= hd.giamgia;
                    clsKhachHang lstkh = new clsKhachHang();
                    string kh = null;
                    kh = lstkh.getKhachHangByName(txtKhachHang.Text);
                    if (kh.Length == 0)
                    {
                        MessageBox.Show("Tên khách hàng không tồn tại.(Nếu là khách vãng lai nhập Unknown)", "Lỗi");
                        return;
                    }
                    else
                        hd.maKH = lstkh.getKhachHangByName(txtKhachHang.Text);
                    hd.loaiHD = true;
                    lstHDThu.addHDThu(hd);
                    foreach(ListViewItem x in listView1.Items)
                    {
                        CT_HoaDonThu hdt = new CT_HoaDonThu();
                        hdt.maHDT = txtMaHD.Text;
                        hdt.maSP = lstSP.getMaSP(x.SubItems[0].Text);
                        hdt.soluong = int.Parse(x.SubItems[1].Text);
                        hdt.dongia = decimal.Parse(x.SubItems[2].Text);
                        lstHDThu.addCTHDThu(hdt);
                    }
                    //transaction.Complete();
                    MessageBox.Show("Thêm hóa đơn thành công", "Thông báo");
                    resetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            //}
            resetForm();
            btnThem.Text = "Thêm";
        }

        private void thuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHDThu frmgdthu = new frmHDThu();
            this.Hide();
            frmgdthu.ShowDialog();
            this.Show();
            txtMaHD.Text = lstHDThu.createMaHD();
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

        private void btnThemMH_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
                MessageBox.Show("Chưa nhập số lượng", "Lỗi");
            else
            {
                if (treeView1.SelectedNode == null)
                    MessageBox.Show("Chưa chọn mặt hàng", "Lỗi");
                else
                {
                    foreach (ListViewItem x in listView1.Items)
                    {
                        if (x.Text == treeView1.SelectedNode.Text)
                        {
                            int sl = int.Parse(listView1.Items[x.Index].SubItems[1].Text);
                            listView1.Items[x.Index].SubItems[1].Text = (sl + numericUpDown1.Value).ToString();
                            txtTongTien.Text = Math.Round(updateGiaTien(), 0).ToString();
                            return;
                        }
                    }
                    listView1.Items.Add(treeView1.SelectedNode.Text);
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(numericUpDown1.Value.ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(""+lstSP.getDonGia(treeView1.SelectedNode.Text));
                    numericUpDown1.Value = 0;
                    txtTongTien.Text = Math.Round(updateGiaTien(), 0).ToString();
                }
            }
        }

        private void chiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHDChi frmHDChi = new frmHDChi();
            this.Hide();
            frmHDChi.ShowDialog();
            this.Show();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                clsKhachHang lstkh = new clsKhachHang();
                string kh = null;
                kh = lstkh.getKhachHangByName(txtKhachHang.Text);
                if (kh.Length == 0)
                    MessageBox.Show("Tên khách hàng không tồn tại.(Nếu là khách vãng lai nhập Unknown)", "Lỗi");
                else
                    MessageBox.Show("Tên khách hàng đã có trong hệ thống", "Thông báo");
            }
            catch { MessageBox.Show("Tên khách hàng không tồn tại.(Nếu là khách vãng lai nhập Unknown)","Lỗi");}
        }

        private void thoátKhỏiChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void đăngXuấtKhỏiHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (d == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void đổiMậtKhẩuĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMK drmdoimk = new frmDoiMK();
            this.Hide();
            drmdoimk.ShowDialog();
            this.Show();
        }

        private void btnXoaMH_Click(object sender, EventArgs e)
        {
            int index = -1;
            foreach (ListViewItem x in listView1.Items)
                if (x.Selected)
                    index = x.Index;
            if(index!=-1)
                listView1.Items.RemoveAt(index);
            txtTongTien.Text = Math.Round(updateGiaTien(),0).ToString();
        }
        private decimal updateGiaTien()
        {
            decimal tongtien=0;
            foreach (ListViewItem x in listView1.Items)
                tongtien += int.Parse(x.SubItems[1].Text) * decimal.Parse(x.SubItems[2].Text);
            return tongtien;
        }

        private void thôngTinỨngdụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutApp about = new frmAboutApp();
            about.ShowDialog();
        }
    }
}
