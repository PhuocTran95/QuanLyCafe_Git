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
    public partial class frmGDThu : Form
    {
        public frmGDThu()
        {
            InitializeComponent();
        }

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
            btnXoaMH.Enabled = false;
        }
    }
}
