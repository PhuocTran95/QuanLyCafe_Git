using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Collections;

namespace BusinessLogic
{
    public class clsHDThu
    {
        QLCafeDataContext da;
        public clsHDThu() { da = new QLCafeDataContext(); }
        public List<HoaDon> getAllHDThu()
        {
            da = new QLCafeDataContext();
            List<HoaDon> lst = da.HoaDons.Where(o => o.loaiHD == true).ToList();
            return lst;
        }
        public List<clsCTHD> getCTHdayMa(string mahd)
        {
            da = new QLCafeDataContext();
            var qr = da.CT_HoaDonThus.Join(da.SanPhams, hd => hd.maSP, sp => sp.tenSP, (hd, sp) => new clsCTHD
            {
                TenSP = sp.tenSP,
                Soluong = hd.soluong,
                Dongia = decimal.Parse(hd.dongia.ToString())
            });
            List<clsCTHD> lst = qr.ToList();
            return lst;
        }
        public List<HoaDon> getHdayMa(string mahd)
        {
            da = new QLCafeDataContext();
            List<HoaDon> lst = da.HoaDons.Where(o => o.maHD == mahd).ToList();
            return lst;
        }
        public bool addHDThu(HoaDon hdthu)
        {
            try
            {
                da = new QLCafeDataContext();
                da.HoaDons.InsertOnSubmit(hdthu);
                da.SubmitChanges();
                return true;
            }
            catch { throw new Exception("Thêm Hóa đơn thất bại"); }
        }
        public bool deleteHDThu(string maHD)
        {
            try
            {
                da = new QLCafeDataContext();

                HoaDon hd = da.HoaDons.Where(o => o.maHD == maHD).FirstOrDefault();
                da.HoaDons.DeleteOnSubmit(hd);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                throw new Exception("Cần xóa hết các chi tiết trong hóa đơn trước khi xóa hóa đơn!"); ;
            }
        }
        public bool updateHoaDon(HoaDon HDNew)
        {
            try
            {
                da = new QLCafeDataContext();
                HoaDon hd = da.HoaDons.Where(o => o.maHD == HDNew.maHD).FirstOrDefault();
                if (hd != null)
                {
                    hd.giamgia = HDNew.giamgia;
                    hd.phuthu = HDNew.phuthu;
                    hd.tongtien = HDNew.tongtien;
                    da.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch { throw new Exception("Chỉnh sửa Hóa đơn thất bại"); }
        }
        public string createMaHD()
        {
            da = new QLCafeDataContext();
            DateTime dd = DateTime.Now;
            string time = "" + dd.Year +
                (dd.Month < 10 ? "0" + dd.Month.ToString() : dd.Month.ToString())
                + (dd.Day < 10 ? "0" + dd.Day.ToString() : dd.Day.ToString());
            string id = "";

            object obj = (from hd in da.HoaDons
                          where hd.loaiHD == true
                          orderby hd.maHD descending
                          select hd.maHD
                          ).FirstOrDefault();

            if (obj == null)
                id = "HDT_" + time + "001";
            else
            {
                int num = int.Parse(obj.ToString().Substring(
                    obj.ToString().Length - 3));
                num++;
                if (num < 10)
                    id = "HDT_" + time + "00" + num;
                else if (num >= 10 && num < 100)
                    id = "HDT_" + time + "0" + num;
                else
                    id = "HDT_" + time + num;
            }
            return id;
        }
        public bool deleteCTHDThu(string maHD, string maSP)
        {
            try
            {
                da = new QLCafeDataContext();

                CT_HoaDonThu hd = da.CT_HoaDonThus.Where(o => o.maHDT == maHD && o.maSP == maSP).FirstOrDefault();
                da.CT_HoaDonThus.DeleteOnSubmit(hd);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
