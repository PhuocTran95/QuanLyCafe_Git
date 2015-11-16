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
        public List<KhachHang> getKhachHangByMa(string maKH)
        {
            da = new QLCafeDataContext();
            List<KhachHang> lstKH = da.KhachHangs.Where(o => o.maKH == maKH).ToList();
            return lstKH;
        }
        public List<KhachHang> getKhachHangByTen(string tenKH)
        {
            da = new QLCafeDataContext();
            List<KhachHang> lstKH = da.KhachHangs.Where(o => o.tenKH == tenKH).ToList();
            return lstKH;
        }
        public string getKhachHangByName(string tenKH)
        {
            da = new QLCafeDataContext();
            KhachHang lstKH = da.KhachHangs.Where(o => o.tenKH == tenKH).FirstOrDefault();
            return lstKH.maKH;
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
            catch { throw new Exception("Thêm khách hàng thất bại. Mã khách hàng đã tồn tại"); }
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
                if(kh!=null)
                {
                    kh.tenKH = KHNew.tenKH;
                    kh.thanthiet = KHNew.thanthiet;
                    kh.cmnd = KHNew.cmnd;
                    da.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch { throw new Exception("Chỉnh sửa khách hàng thất bại. Mã khách hàng đã tồn tại"); }
        }
        public string createMaKH()
        {
            da = new QLCafeDataContext();
            string id = "";

            object obj = (from hd in da.KhachHangs
                          orderby hd.maKH descending
                          select hd.maKH
                          ).FirstOrDefault();

            if (obj == null)
                id = "KH" + "00001";
            else
            {
                int num = int.Parse(obj.ToString().Substring(
                    obj.ToString().Length - 5));
                num++;
                if (num < 10)
                    id = "KH" + "0000" + num;
                else if (num >= 10 && num < 100)
                    id = "KH" + "000" + num;
                else if (num >= 100 && num < 1000)
                    id = "KH" + "00" + num;
                else if (num >= 1000 && num < 10000)
                    id = "KH" + "0" + num;
                else
                    id = "KH" + num;
            }
            return id;
        }
    }
}
