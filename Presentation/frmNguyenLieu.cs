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
    public partial class frmNguyenLieu : Form
    {
        clsNguyenLieu clNL = new clsNguyenLieu();
        public frmNguyenLieu()
        {
            InitializeComponent();
        }
        public void loadFirst()
        {          
            txtMa.Enabled = true;
            txtTen.Enabled = true;
            txtDonGia.Enabled = true;
        }
        public void hide()
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            txtDonGia.Enabled = false;
        }
        public void clear()
        {
            txtTen.Clear();
            txtMa.Clear();
            txtDonGia.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                loadFirst();
                txtMa.Focus();
                btnThem.Text = "Hủy";
                txtMa.Text = "NL";
                txtDonGia.Text = "";
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
                    MessageBox.Show("Vui lòng chọn nguyên liệu cần sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            if (dataGridView1.Columns["maNL"] != null)
            {
                dataGridView1.Columns["maNL"].HeaderText = "Mã Nguyên Liệu";
                dataGridView1.Columns["maNL"].Width = 30 * w / 100;
                dataGridView1.Columns["maNL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            if (dataGridView1.Columns["tenNL"] != null)
            {
                dataGridView1.Columns["tenNL"].HeaderText = "Tên Nguyên Liệu";
                dataGridView1.Columns["tenNL"].Width = 30 * w / 100;
            }
            if (dataGridView1.Columns["dvtinh"] != null)
            {
                dataGridView1.Columns["dvtinh"].HeaderText = "Đơn vị tính";
                dataGridView1.Columns["dvtinh"].Width = 40 * w / 100;
            }
           
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnLuu.Text == "Lưu")
            {
                try
                {
                    NguyenLieu nl = new NguyenLieu();
                    nl.maNL = txtMa.Text;
                    nl.tenNL = txtTen.Text;
                    nl.dvtinh = txtDonGia.Text;
                    if (clNL.AddNguyenLieu(nl) == true)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnThem.Text = "Thêm";
                        hide();
                        capnhatData();
                        clear();
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
                        NguyenLieu nl1= new NguyenLieu();
                        nl1.maNL = txtMa.Text;
                        nl1.tenNL = txtTen.Text;
                        nl1.dvtinh = txtDonGia.Text;
                        if (clNL.UpdateNguyenLieu(nl1))
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

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            capnhatData();
        }
        public void capnhatData()
        {
            dataGridView1.DataSource = clNL.GetAllNguyenLieu();
            customgrid();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string mid = dataGridView1.SelectedRows[0].Cells["maNL"].Value.ToString();
                    if (MessageBox.Show("Bạn có muốn xóa Nguyên Liệu có mã:" + mid, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (clNL.deleteNguyenLieu(txtMa.Text))
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            capnhatData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nguyên liệu cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells["maNL"].Value.ToString();
                txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells["tenNL"].Value.ToString();
                txtDonGia.Text = dataGridView1.Rows[e.RowIndex].Cells["dvtinh"].Value.ToString();
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
                if (cbLoaiTim.Text == "Mã Nguyên Liệu")
                {
                    dataGridView1.DataSource = clNL.searchTheoMa(txtThongTin.Text);
                    customgrid();
                }
                if (cbLoaiTim.Text == "Tên Nguyên Liệu")
                {
                    dataGridView1.DataSource = clNL.searchTheoTen(txtThongTin.Text);
                    customgrid();
                }

            }
        }
    }
}
