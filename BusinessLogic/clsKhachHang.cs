using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Linq;

namespace BusinessLogic
{
    public class clsKhachHang
    {
        QLCafeDataContext da;
        public clsKhachHang() { da = new QLCafeDataContext(); }
        public List<KhachHang> getAllKhachHang()
        {
            da = new QLCafeDataContext();
            List<KhachHang> lstKH = da.KhachHangs.ToList();
            return lstKH;
        }
        public bool addKhachHang(KhachHang kh)
        {
            try
            {
                if (da.KhachHangs.Where(o => o.cmnd == kh.cmnd).FirstOrDefault() == null)
                {
                    da = new QLCafeDataContext();
                    da.KhachHangs.InsertOnSubmit(kh);
                    da.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public bool deleteKhachHang(string maKH)
        {
            try
            {
                da = new QLCafeDataContext();

                KhachHang kh = da.KhachHangs.Where(o => o.maKH == maKH).FirstOrDefault();
                da.KhachHangs.DeleteOnSubmit(kh);
                da.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateKhachHang(KhachHang KHNew)
        {
            try
            {
                da = new QLCafeDataContext();
                KhachHang kh = da.KhachHangs.Where(o => o.maKH == KHNew.maKH).FirstOrDefault();
                if(kh!=null && da.KhachHangs.Where(o=>o.cmnd==KHNew.cmnd).FirstOrDefault()==null)
                {
                    kh.maKH = KHNew.maKH;
                    kh.tenKH = KHNew.tenKH;
                    kh.cmnd = KHNew.cmnd;
                    kh.thanthiet = KHNew.thanthiet;
                    da.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
