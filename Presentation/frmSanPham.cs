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
    public partial class frmSanPham : Form
   {
        public frmSanPham()
        {
            InitializeComponent();
        }
        
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            capnhatData();
            loadCB();
        }
        clsSanPham clSP = new clsSanPham();
        clsLoaiSP clLSP = new clsLoaiSP();
        public void capnhatData()
        {
            dataGridView1.DataSource = clSP.GetAllSP();
            customgrid();
        }
        public void loadCB()
        {
            List<LoaiSP> lst = new List<LoaiSP>();
            lst = clLSP.GetAllLoaiSP();
            foreach (LoaiSP s in lst)
            {
                cbLoai.Items.Add(s.maLoai);
            }
        }
        public void customgrid()
        {
            int w = dataGridView1.Width;
            if (dataGridView1.Columns["maSP"] != null)
            {
                dataGridView1.Columns["maSP"].HeaderText = "Mã Sản phẩm";
                dataGridView1.Columns["maSP"].Width = 10 * w / 100;
            }
            if (dataGridView1.Columns["loaiSP"] != null)
            {
                dataGridView1.Columns["loaiSP"].HeaderText = "Mã Loại Sản Phẩm";
                dataGridView1.Columns["loaiSP"].Width = 10 * w / 100;
            }
           
            if (dataGridView1.Columns["tenSP"] != null)
            {
                dataGridView1.Columns["tenSP"].HeaderText = "Tên Sản phẩm";
                dataGridView1.Columns["tenSP"].Width = 20 * w / 100;
            }
            if (dataGridView1.Columns["dongia"] != null)
            {
                dataGridView1.Columns["dongia"].HeaderText = "Mã Sản phẩm";
                dataGridView1.Columns["dongia"].Width = 20 * w / 100;
            }
            if (dataGridView1.Columns["mota"] != null)
            {
                dataGridView1.Columns["mota"].HeaderText = "Mô tả";
                dataGridView1.Columns["mota"].Width = 50 * w / 100;
            }
            dataGridView1.Columns["loaiSP1"].Width = 0;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            capnhatData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (btnThem.Text == "Thêm")
            {
                txtMaSP.Text = "SP";
                txtTenSP.Text = "";
                txtDonGia.Text = "0";
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThem.Text = "Hủy";
                txtMaSP.Enabled = true;
                txtTenSP.Enabled = true;
                txtDonGia.Enabled = true;
                txtMoTa.Enabled = true;
                btnLuu.Enabled = true;
                cbLoai.Enabled = true;
                btnLuu.Text = "Lưu";
            }
            else
            {
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtDonGia.Clear();
                txtMoTa.Clear();
                txtMaSP.Enabled = false;
                txtTenSP.Enabled = false;
                txtDonGia.Enabled = false;
                txtMoTa.Enabled = false;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;      
                btnThem.Text = "Thêm";
                cbLoai.Enabled = false;
                btnLuu.Text = "Lưu";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Chỉnh Sửa")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    txtTenSP.Enabled = true;
                    txtDonGia.Enabled = true;
                    txtMoTa.Enabled = true;
                    cbLoai.Enabled = false;
                    btnSua.Text = "Hủy";
                    btnLuu.Text = "Xác nhận";
                    btnLuu.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm cần sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Text = "Lưu";
                btnSua.Text = "Chỉnh Sửa";
                txtMaSP.Enabled = false;
                txtTenSP.Enabled = false;
                txtDonGia.Enabled = false;
                txtMoTa.Enabled = false;
                cbLoai.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnLuu.Text == "Lưu")
            {
                try
                {
                    SanPham sp = new SanPham();
                    sp.loaiSP = cbLoai.Text;
                    sp.maSP = txtMaSP.Text;
                    sp.tenSP = txtTenSP.Text;
                    sp.dongia = decimal.Parse(txtDonGia.Text);
                    sp.mota = txtMoTa.Text;
                    if (clSP.AddSP(sp) == true)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnThem.Text = "Thêm";
                        txtMaSP.Enabled = false;
                        txtTenSP.Enabled = false;
                        txtDonGia.Enabled = false;
                        txtMoTa.Enabled = false;
                        capnhatData();
                        txtTenSP.Clear();
                        txtMaSP.Clear();
                        txtDonGia.Clear();
                        txtMoTa.Clear();
                        btnLuu.Enabled = false;
                        cbLoai.Enabled = false;
                    }
                    else
                    {

                        MessageBox.Show("Trùng mã.Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnThem.Text = "Thêm";
                        txtMaSP.Enabled = false;
                        txtTenSP.Enabled = false;
                        txtDonGia.Enabled = false;
                        txtMoTa.Enabled = false;
                        capnhatData();
                        txtTenSP.Clear();
                        txtMaSP.Clear();
                        txtDonGia.Clear();
                        txtMoTa.Clear();
                        btnLuu.Enabled = false;
                        cbLoai.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    try
                    {
                        SanPham sp2 = new SanPham();
                        sp2.loaiSP= cbLoai.Text;
                        sp2.maSP = txtMaSP.Text;
                        sp2.tenSP = txtTenSP.Text;
                        sp2.dongia = decimal.Parse(txtDonGia.Text);
                        sp2.mota = txtMoTa.Text;
                        if (clSP.UpdateSP(sp2))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            capnhatData();
                            btnSua.Text = "Chỉnh sửa";
                            btnThem.Enabled = true;
                            btnXoa.Enabled = true;
                            btnSua.Enabled = true;
                            btnLuu.Enabled = false;
                            txtMaSP.Enabled = false;
                            txtTenSP.Enabled = false;
                            txtDonGia.Enabled = false;
                            txtMoTa.Enabled = false;
                            capnhatData();
                            txtTenSP.Clear();
                            txtMaSP.Clear();
                            txtDonGia.Clear();
                            txtMoTa.Clear();
                            cbLoai.Enabled = false;
                            btnLuu.Text = "Lưu";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
     

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbLoai.Text = dataGridView1.Rows[e.RowIndex].Cells["loaiSP"].Value.ToString();
            txtTenSP.Text = dataGridView1.Rows[e.RowIndex].Cells["tenSP"].Value.ToString();
            txtMaSP.Text = dataGridView1.Rows[e.RowIndex].Cells["maSP"].Value.ToString();
            txtDonGia.Text = dataGridView1.Rows[e.RowIndex].Cells["dongia"].Value.ToString();
            txtMoTa.Text = dataGridView1.Rows[e.RowIndex].Cells["mota"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string mid = dataGridView1.SelectedRows[0].Cells["maSP"].Value.ToString();
                if (MessageBox.Show("Bạn có muốn xóa Sản phẩm có mã:" + mid, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clSP.deleteSP(txtMaSP.Text))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        capnhatData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Sản Phẩm cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtThongTin == null || txtThongTin.Text == "" || cbLoaiTim.Text == "")
            {
                MessageBox.Show("Vui lòng nhập(chọn) thông tin cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cbLoaiTim.Text == "Mã Sản Phẩm")
                {
                    dataGridView1.DataSource = clSP.searchTheoMa(txtThongTin.Text);
                    customgrid();
                }
                if (cbLoaiTim.Text == "Tên Sản Phẩm")
                {
                    dataGridView1.DataSource = clSP.searchTheoTen(txtThongTin.Text);
                    customgrid();
                }
                if (cbLoaiTim.Text == "Mã Loại SP")
                {
                    dataGridView1.DataSource = clSP.searchTheoMaLoai(txtThongTin.Text);
                    customgrid();
                }
            }
        }
    }
}
