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

using BusinessLogic;
using DataAccess;

namespace Presentation
{
    public partial class frmDSLoaiSanPham : Form
    {
        clsLoaiSP clLoai = new clsLoaiSP();
        public frmDSLoaiSanPham()
        {
            InitializeComponent();
            customgrid();
        }
    
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                txtMa.Text = "LSP";
                txtTen.Text = "";
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThem.Text = "Hủy";
                txtMa.Enabled = true;
                txtTen.Enabled = true;
                btnLuu.Enabled = true;
                btnLuu.Text = "Lưu";
            }
            else
            {
                txtMa.Clear();
                txtTen.Clear();
                btnSua.Enabled = true;
                txtMa.Enabled = false;
                txtTen.Enabled = false;
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                btnThem.Text = "Thêm";
                btnLuu.Text = "Lưu";
            }
        }
        public void CapNhatData()
        {
            dataGridView1.DataSource = clLoai.GetAllLoaiSP();
            customgrid();
        }
        public void customgrid()
        {
            int w = dataGridView1.Width;
            if (dataGridView1.Columns["maLoai"] != null)
            {
                dataGridView1.Columns["maLoai"].HeaderText = "Mã Loại Sản Phẩm";
                dataGridView1.Columns["maLoai"].Width = 20 * w / 100;
                dataGridView1.Columns["maLoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            if (dataGridView1.Columns["tenLoai"] != null)
            {
                dataGridView1.Columns["tenLoai"].HeaderText = "Tên Loại Sản Phẩm";
                dataGridView1.Columns["tenLoai"].Width = 70 * w / 100;
            }
        }

        private void frmDSLoaiMatHang_Load(object sender, EventArgs e)
        {
            CapNhatData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {         
            if (btnSua.Text == "Chỉnh Sửa")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    txtTen.Enabled = true;
                    btnSua.Text = "Hủy";
                    btnLuu.Text = "Xác nhận";
                    btnLuu.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm cần sửa","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Text = "Lưu";
                btnSua.Text = "Chỉnh Sửa";
                txtMa.Enabled = false;
                txtTen.Enabled = false;
            }

        }
      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells["maLoai"].Value.ToString();
            txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells["tenLoai"].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnLuu.Text == "Lưu")
            {
                try
                {
                    LoaiSP l = new LoaiSP();
                    l.maLoai = txtMa.Text;
                    l.tenLoai = txtTen.Text;
                    if (clLoai.AddLoaiSP(l) == true)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnThem.Text = "Thêm";
                        txtMa.Enabled = false;
                        txtTen.Enabled = false;
                        CapNhatData();
                        txtTen.Clear();
                        txtMa.Clear();
                        btnLuu.Enabled = false;
                    }
                    else
                    {

                        MessageBox.Show("Trùng mã.Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnThem.Text = "Thêm";
                        txtMa.Enabled = false;
                        txtTen.Enabled = false;
                        btnLuu.Enabled = false;
                        txtMa.Clear();
                        txtTen.Clear();
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
                        LoaiSP l2 = new LoaiSP();
                        l2.maLoai = txtMa.Text;
                        l2.tenLoai = txtTen.Text;

                        if (clLoai.UpdateLoaiSp(l2))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CapNhatData();
                            btnSua.Text = "Chỉnh sửa";
                            btnThem.Enabled = true;
                            btnXoa.Enabled = true;
                            btnSua.Enabled = true;
                            btnLuu.Enabled = false;
                            txtMa.Enabled = false;
                            txtTen.Enabled = false;
                            txtMa.Clear();
                            txtTen.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string mid = dataGridView1.SelectedRows[0].Cells["maLoai"].Value.ToString();
                    if (MessageBox.Show("Bạn có muốn xóa Loại sản phẩm có mã:" + mid, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (clLoai.deleteLoaiSP(txtMa.Text))
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CapNhatData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn Loại Sản Phẩm cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtThongTin==null ||txtThongTin.Text==""||cbLoaiTim.Text=="")
            {
                MessageBox.Show("Vui lòng nhập(chọn) thông tin cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if(cbLoaiTim.Text=="Mã Loại")
                {
                    dataGridView1.DataSource = clLoai.searchTheoMa(txtThongTin.Text);
                    customgrid();
                }
                if(cbLoaiTim.Text=="Tên Loại")
                {
                    dataGridView1.DataSource = clLoai.searchTheoTen(txtThongTin.Text);
                    customgrid();
                }

            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CapNhatData();
        }
    }
}
