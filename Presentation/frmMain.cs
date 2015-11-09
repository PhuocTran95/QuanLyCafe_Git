using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSKhachHang frmKhachHang = new frmDSKhachHang();
            this.Hide();
            frmKhachHang.ShowDialog();
            this.Show();
        }
        private void loadTreeView()
        {
            //nccdao = new NhaCungCapDAO();//khởi tạo danh sách            
            //lstNCC = nccdao.GetAllNhaCungCap();//đọc ds nhà cung cấp vào list
            //treeView1.Nodes.Clear();//xóa tất cả các node trước khi load dữ liệu vào tree
            ////load dữ liệu lên TreeView
            //TreeNode nodecha = new TreeNode("DANH SÁCH NHÀ CUNG CẤP");
            //foreach (NhaCungCap c in lstNCC)
            //{
            //    TreeNode nodecon = new TreeNode(c.TenNCC);
            //    nodecon.Tag = c.MsNCC;//lưu mã số nhà cung cấp vào thuộc tính Tag
            //    nodecon.Nodes.Add(c.DiachiNCC);//thêm node con là địa chỉ trong nodeCon
            //    nodecon.Nodes.Add(c.SodtNCC);//thêm node con là điện thoại trong nodeCon
            //    nodecha.Nodes.Add(nodecon);//thêm nodecon vào node con
            //}
            //treeView1.Nodes.Add(nodecha);//thêm nodecha vào TreeView
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
    }
}
