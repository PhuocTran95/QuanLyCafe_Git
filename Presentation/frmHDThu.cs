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
    public partial class frmHDThu : Form
    {
        public frmHDThu()
        {
            InitializeComponent();
        }
        clsHDThu lstHDThu = new clsHDThu();
        private void frmGDThu_Load(object sender, EventArgs e)
        {
            txtGiamGia.Enabled = false;
            txtMaHD.Enabled = false;
            txtMaNV.Enabled = false;
            txtNgayLapHD.Enabled = false;
            txtPhuThu.Enabled = false;
            txtTongTien.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtmaKH.Enabled = false;
            updateGrid();
            formatGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaHD.Text = dataGridView1.Rows[e.RowIndex].Cells["maHD"].Value.ToString();
                txtMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells["maNV"].Value.ToString();
                txtmaKH.Text = dataGridView1.Rows[e.RowIndex].Cells["maKH"].Value.ToString();
                txtNgayLapHD.Text = dataGridView1.Rows[e.RowIndex].Cells["ngaylapHD"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["giamgia"].Value!=null)
                    txtGiamGia.Text = dataGridView1.Rows[e.RowIndex].Cells["giamgia"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["phuthu"].Value!=null)
                    txtPhuThu.Text = dataGridView1.Rows[e.RowIndex].Cells["phuthu"].Value.ToString();
                txtTongTien.Text = dataGridView1.Rows[e.RowIndex].Cells["tongtien"].Value.ToString();
                dataGridView2.DataBindings.Clear();
                dataGridView2.DataSource = lstHDThu.getCTHdayMa(dataGridView1.Rows[e.RowIndex].Cells["maHD"].Value.ToString());
                formatGrid2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void btnDanhSachHD_Click(object sender, EventArgs e)
        {
            updateGrid();
            formatGrid();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataBindings.Clear();
            dataGridView1.DataSource = lstHDThu.getHdayMa(txtMaHDTK.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d;
                d = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn " + txtMaHD.Text + " trong danh sách?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (d == DialogResult.Yes)
                {
                    lstHDThu.deleteHDThu(txtMaHD.Text);
                    MessageBox.Show("Đã xóa hóa đơn " + txtMaHD.Text + " thành công", "Thông báo");
                    updateGrid();
                    formatGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
        private void formatGrid()
        {
            int w = dataGridView1.Width;
            dataGridView1.Columns["maHD"].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns["maHD"].Width = 20 * w / 100;
            dataGridView1.Columns["maNV"].HeaderText = "Mã nhân viên";
            dataGridView1.Columns["maNV"].Width = 10 * w / 100;
            dataGridView1.Columns["maKH"].HeaderText = "Mã khách hàng";
            dataGridView1.Columns["maKh"].Width = 10 * w / 100;
            dataGridView1.Columns["ngaylapHD"].HeaderText = "Ngày lập HĐ";
            dataGridView1.Columns["ngaylapHD"].Width = 25 * w / 100;
            dataGridView1.Columns["loaiHD"].Visible = false;
            dataGridView1.Columns["phuthu"].HeaderText = "Phụ thu";
            dataGridView1.Columns["phuthu"].Width = 10 * w / 100;
            dataGridView1.Columns["giamgia"].HeaderText = "Giảm giá";
            dataGridView1.Columns["giamgia"].Width = 10 * w / 100;
            dataGridView1.Columns["tongtien"].HeaderText = "Tổng tiền";
            dataGridView1.Columns["tongtien"].Width = 15 * w / 100;
            dataGridView1.Columns["NhanVien"].Visible = false;
            dataGridView1.Columns["KhachHang"].Visible = false;

        }
        private void formatGrid2()
        {
            int w = dataGridView1.Width;
            dataGridView2.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dataGridView2.Columns["TenSP"].Width = 20 * w / 100;
            dataGridView2.Columns["Soluong"].HeaderText = "Số lượng";
            dataGridView2.Columns["Soluong"].Width = 15 * w / 100;
            dataGridView2.Columns["Dongia"].HeaderText = "Đơn giá";
            dataGridView2.Columns["Dongia"].Width = 15 * w / 100;

        }
        private void updateGrid()
        {
            dataGridView1.DataBindings.Clear();
            dataGridView1.DataSource = lstHDThu.getAllHDThu();
            formatGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(btnSua.Text=="Chỉnh sửa")
            {
                btnXoa.Enabled = false;
                btnSua.Text = "Hủy";
                txtGiamGia.Enabled = true;
                txtPhuThu.Enabled = true;
                txtTongTien.Enabled = true;
                btnLuu.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = true;
                btnSua.Text = "Chỉnh sửa";
                txtGiamGia.Enabled = false;
                txtMaHD.Enabled = false;
                txtMaNV.Enabled = false;
                txtNgayLapHD.Enabled = false;
                txtPhuThu.Enabled = false;
                txtTongTien.Enabled = false;
                btnLuu.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hd = new HoaDon();
                hd.maHD = txtMaHD.Text;
                hd.maNV = txtMaNV.Text;
                hd.ngaylapHD = DateTime.Parse(txtNgayLapHD.Text);
                if (txtGiamGia.Text.Length > 0)
                    hd.giamgia = decimal.Parse(txtGiamGia.Text);
                if (txtPhuThu.Text.Length > 0)
                    hd.phuthu = decimal.Parse(txtPhuThu.Text);
                hd.tongtien = decimal.Parse(txtTongTien.Text);
                if (lstHDThu.updateHoaDon(hd))
                    MessageBox.Show("Chỉnh sửa hóa đơn thành công", "Thông báo");
                else
                    MessageBox.Show("Chỉnh sửa hóa đơn thất bại", "Lỗi");
                updateGrid();
                formatGrid();
                btnXoa.Enabled = true;
                btnSua.Text = "Chỉnh sửa";
                txtGiamGia.Enabled = false;
                txtMaHD.Enabled = false;
                txtMaNV.Enabled = false;
                txtNgayLapHD.Enabled = false;
                txtPhuThu.Enabled = false;
                txtTongTien.Enabled = false;
                btnLuu.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
                txtTongTien.Clear();
            }
        }
    }
}
