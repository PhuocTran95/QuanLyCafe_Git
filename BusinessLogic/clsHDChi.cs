using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class clsHDChi
    {
        QLCafeDataContext da;
        public clsHDChi() { da = new QLCafeDataContext(); }
        public List<HoaDon> getAllHDChi(){
            da = new QLCafeDataContext();
            List<HoaDon> lst = da.HoaDons.Where(o=>o.loaiHD==false).ToList();
            return lst;
        }

        public clsCTHDChi getCTHdayMa(string mahd)
        {
            da = new QLCafeDataContext();
            var qr = da.CT_HoaDonChis.Join(da.NguyenLieus, hd => hd.maNL, sp => sp.maNL, (hd, sp) => new clsCTHDChi
            {
                TenNL = sp.tenNL,
                DVTinh = sp.dvtinh,
                Soluong = hd.soluong,
                Ghichu=hd.ghichu
            });
            clsCTHDChi lst = qr.ToList().FirstOrDefault();
            return lst;
        }
        public List<HoaDon> getHdayMa(string mahd)
        {
            da = new QLCafeDataContext();
            List<HoaDon> lst = da.HoaDons.Where(o => o.maHD == mahd).ToList();
            return lst;
        }
        public bool addHDChi(HoaDon hdChi)
        {
            try
            {
                da = new QLCafeDataContext();
                da.HoaDons.InsertOnSubmit(hdChi);
                da.SubmitChanges();
                return true;
            }
            catch { throw new Exception("Thêm Hóa đơn thất bại"); }
        }
        public bool addCTHDChi(CT_HoaDonChi cthdChi)
        {
            try
            {
                da = new QLCafeDataContext();
                da.CT_HoaDonChis.InsertOnSubmit(cthdChi);
                da.SubmitChanges();
                return true;
            }
            catch(Exception ex) { throw new Exception (ex.Message); }
        }
        public bool deleteHDChi(string maHD)
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
                throw new Exception("Cần xóa hết các chi tiết trong hóa đơn trước khi xóa hóa đơn!");
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
                          where hd.loaiHD==false
                          orderby hd.maHD descending
                          select hd.maHD
                          ).FirstOrDefault();

            if (obj == null)
                id = "HDC_" + time + "001";
            else
            {
                int num = int.Parse(obj.ToString().Substring(
                    obj.ToString().Length - 3));
                num++;
                if(num<10)
                    id = "HDC_" + time + "00" + num;
                else if(num>=10&&num<100)
                    id = "HDC_" + time + "0" + num;
                else
                    id = "HDC_" + time + num;
            }
            return id;
        }
        public bool deleteCTHDChi(string maHD,string maNL)
        {
            try
            {
                da = new QLCafeDataContext();

                CT_HoaDonChi hd = da.CT_HoaDonChis.Where(o => o.maHDC == maHD && o.maNL==maNL).FirstOrDefault();
                da.CT_HoaDonChis.DeleteOnSubmit(hd);
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
