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
    public partial class frmNhanVien : Form
    {
        clsNhanVien clNV = new clsNhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void loadFirst()
        {
            txtCMND.Enabled = true;
            txtDiaChi.Enabled = true;
            txtMa.Enabled = true;
            txtMatKhau.Enabled = true;
            txtTen.Enabled = true;
        }
        public void hide()
        {
            txtCMND.Enabled = false;
            txtDiaChi.Enabled = false;
            txtMa.Enabled = false;
            txtMatKhau.Enabled = false;
            txtTen.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                loadFirst();
                txtMa.Focus();
                btnThem.Text = "Hủy";
                txtMa.Text = "NV";
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
            }
            else
            {
                hide();
                btnThem.Text = "Thêm";
                btnLuu.Text = "Lưu";
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                clear();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Chỉnh Sửa")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    loadFirst();
                    btnSua.Text = "Hủy";
                    btnLuu.Text = "Xác nhận";
                    btnLuu.Enabled = true;
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    txtMa.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                hide();
                btnSua.Text = "Chỉnh Sửa";
                btnLuu.Text = "Lưu";
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                clear();
            }
        }
        public void customgrid()
        {
            int w = dataGridView1.Width;
            if (dataGridView1.Columns["maNV"] != null)
            {
                dataGridView1.Columns["maNV"].HeaderText = "Mã Nhân Viên";
                dataGridView1.Columns["maNV"].Width = 10 * w / 100;
                dataGridView1.Columns["maNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            if (dataGridView1.Columns["tenNV"] != null)
            {
                dataGridView1.Columns["tenNV"].HeaderText = "Tên Nhân Viên";
                dataGridView1.Columns["tenNV"].Width = 20 * w / 100;
            }
            if (dataGridView1.Columns["phai"] != null)
            {
                dataGridView1.Columns["phai"].HeaderText = "Phái";
                dataGridView1.Columns["phai"].Width = 5 * w / 100;
            }
            if (dataGridView1.Columns["diachi"] != null)
            {
                dataGridView1.Columns["diachi"].HeaderText = "Địa Chỉ";
                dataGridView1.Columns["diachi"].Width = 20 * w / 100;
            }
            if (dataGridView1.Columns["cmnd"] != null)
            {
                dataGridView1.Columns["cmnd"].HeaderText = "CMND";
                dataGridView1.Columns["cmnd"].Width = 10 * w / 100;
            }
            if (dataGridView1.Columns["matkhauNV"] != null)
            {
                dataGridView1.Columns["matkhauNV"].HeaderText = "Mật Khẩu Nhân Viên";
                dataGridView1.Columns["matkhauNV"].Width = 30 * w / 100;
            }
        }
        public void capnhatData()
        {
            dataGridView1.DataSource = clNV.GetAllNhanVien();
            customgrid();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnLuu.Text == "Lưu")
            {
                try
                {
                    NhanVien nv = new NhanVien();
                    nv.maNV = txtMa.Text;
                    if (rdNam.Checked)
                        nv.phai = rdNam.Text;
                    else
                        nv.phai = rdNu.Text;
                    nv.tenNV = txtTen.Text;
                    nv.cmnd = txtCMND.Text;
                    nv.diachi = txtDiaChi.Text;
                    nv.matkhauNV = txtMatKhau.Text;
                    if (clNV.AddNhanVien(nv) == true)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnThem.Text = "Thêm";
                        hide();
                        capnhatData();
                        clear();
                        rdNam.Checked = false;
                        rdNu.Checked = false;
                        btnLuu.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Trùng mã.Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        NhanVien nv = new NhanVien();
                        nv.maNV = txtMa.Text;
                        if (rdNam.Checked)
                            nv.phai = rdNam.Text;
                        else
                            nv.phai = rdNu.Text;
                        nv.tenNV = txtTen.Text;
                        nv.cmnd = txtCMND.Text;
                        nv.diachi = txtDiaChi.Text;
                        nv.matkhauNV = txtMatKhau.Text;

                        if (clNV.UpdateNhanVien(nv))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            capnhatData();
                            btnSua.Text = "Chỉnh Sửa";
                            btnThem.Enabled = true;
                            btnXoa.Enabled = true;
                            btnSua.Enabled = true;
                            btnLuu.Enabled = false;
                            btnLuu.Text = "Lưu";
                            clear();
                            hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public void clear()
        {
            txtTen.Clear();
            txtMa.Clear();
            txtCMND.Clear();
            txtDiaChi.Clear();
            txtMatKhau.Clear();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            capnhatData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells["maNV"].Value.ToString();
                txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells["tenNV"].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells["diachi"].Value.ToString();
                txtMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells["matkhauNV"].Value.ToString();
                txtCMND.Text = dataGridView1.Rows[e.RowIndex].Cells["cmnd"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["phai"].Value.ToString() == "Nam")
                    rdNam.Checked = true;
                else
                    rdNu.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string mid = dataGridView1.SelectedRows[0].Cells["maNV"].Value.ToString();
                    if (MessageBox.Show("Bạn có muốn xóa Nhân Viên có mã:" + mid, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (clNV.deleteNhanVien(txtMa.Text))
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            capnhatData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn Nhân Viên cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            capnhatData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtThongTin == null || txtThongTin.Text == "" || cbLoaiTim.Text == "")
            {
                MessageBox.Show("Vui lòng nhập(chọn) thông tin cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cbLoaiTim.Text == "Mã Nhân Viên")
                {
                    dataGridView1.DataSource = clNV.searchTheoMaNhanVien(txtThongTin.Text);
                    customgrid();
                }
                if (cbLoaiTim.Text == "Tên Nhân Viên")
                {
                    dataGridView1.DataSource = clNV.searchTheoTenNhanVien(txtThongTin.Text);
                    customgrid();
                }

            }
        }

        private void btnDSNhanVien_Click(object sender, EventArgs e)
        {
            capnhatData();
        }
    }
}
