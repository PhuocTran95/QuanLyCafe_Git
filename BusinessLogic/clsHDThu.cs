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
        public List<HoaDon> getAllHDThu(){
            da = new QLCafeDataContext();
            List<HoaDon> lst = da.HoaDons.Where(o=>o.loaiHD==true).ToList();
            return lst;
        }
        public List<CT_HoaDonThu> getCTHDByMa(string mahd)
        {
            da = new QLCafeDataContext();
            List<CT_HoaDonThu> lst = da.CT_HoaDonThus.Where(o => o.maHDT == mahd).ToList();
            return lst;
        }
        public List<HoaDon> getHDByMa(string mahd)
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
                return false;
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
                    hd = HDNew;
                    da.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch { throw new Exception("Chỉnh sửa Hóa đơn thất bại"); }
        }
    }
}
