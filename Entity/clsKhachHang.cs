using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class clsKhachHang
    {
        private string maKH;
        private string tenKH;
        private string cmnd;
        private bool thanthiet;

        public clsKhachHang() { }
        public clsKhachHang(string ma, string ten, string cmnd, bool thanthiet)
        {
            this.maKH = ma;
            this.tenKH = ten;
            this.cmnd = cmnd;
            this.thanthiet = thanthiet;
        }

        public bool Thanthiet
        {
            get { return thanthiet; }
            set { thanthiet = value; }
        }

        public string Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
    }
}
