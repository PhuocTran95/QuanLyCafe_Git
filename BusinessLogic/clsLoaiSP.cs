using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class clsLoaiSP
    {
        QLCafeDataContext db;
        public List<LoaiSP> GetAllLoaiSP()
        {
            db = new QLCafeDataContext();

            List<LoaiSP> lst = new List<LoaiSP>();
            lst = db.LoaiSPs.ToList();
            return lst;
        }
        public bool AddLoaiSP(LoaiSP s)
        {
            try
            {
                db = new QLCafeDataContext();
                db.LoaiSPs.InsertOnSubmit(s);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateLoaiSp(LoaiSP l)
        {
            try
            {
                db = new QLCafeDataContext();
                LoaiSP x = db.LoaiSPs.Where(o => o.maLoai == l.maLoai).FirstOrDefault();
                if (x != null)
                {
                    x.maLoai = l.maLoai;
                    x.tenLoai = l.tenLoai;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public bool deleteLoaiSP(string s)
        {
            try
            {
                db = new QLCafeDataContext();
                LoaiSP l = db.LoaiSPs.Where(o => o.maLoai == s).FirstOrDefault();
                db.LoaiSPs.DeleteOnSubmit(l);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                throw new Exception("Không xóa được vì có sản phẩm đang sử dụng Mã: " + s);

            }
        }
        public List<LoaiSP> searchTheoMa(string s)
        {
            try
            {
                List<LoaiSP> lst = new List<LoaiSP>();
                db = new QLCafeDataContext();
                lst = db.LoaiSPs.Where(o => o.maLoai == s).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<LoaiSP> searchTheoTen(string s)
        {
            try
            {
                db = new QLCafeDataContext();
                List<LoaiSP> lst = new List<LoaiSP>();
                lst = db.LoaiSPs.Where(o => o.tenLoai == s).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
