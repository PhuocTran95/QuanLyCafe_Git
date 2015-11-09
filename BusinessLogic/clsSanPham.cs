using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
    public class clsSanPham
    {
        QLCafeDataContext db;
        public List<SanPham> GetAllSP()
        {
            db = new QLCafeDataContext();

            List<SanPham> lst = new List<SanPham>();
            lst = db.SanPhams.ToList();
            return lst;
        }
        public bool AddSP(SanPham s)
        {
            try
            {
                db = new QLCafeDataContext();
                db.SanPhams.InsertOnSubmit(s);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSP(SanPham l)
        {
            try
            {
                db = new QLCafeDataContext();
                SanPham x = db.SanPhams.Where(o => o.maSP == l.maSP).FirstOrDefault();
                if (x != null)
                {

                    x.tenSP = l.tenSP;
                    x.loaiSP = l.loaiSP;
                    x.dongia = l.dongia;
                    x.mota = l.mota;
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
        public bool deleteSP(string s)
        {
            try
            {
                db = new QLCafeDataContext();
                SanPham l = db.SanPhams.Where(o => o.maSP == s).FirstOrDefault();
                db.SanPhams.DeleteOnSubmit(l);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<SanPham> searchTheoMa(string s)
        {
            try
            {
                List<SanPham> lst = new List<SanPham>();
                db = new QLCafeDataContext();
                lst = db.SanPhams.Where(o => o.maSP == s).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<SanPham> searchTheoTen(string s)
        {
            try
            {
                db = new QLCafeDataContext();
                List<SanPham> lst = new List<SanPham>();
                lst = db.SanPhams.Where(o => o.tenSP == s).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<SanPham> searchTheoMaLoai(string s)
        {
            try
            {
                db = new QLCafeDataContext();
                List<SanPham> lst = new List<SanPham>();
                lst = db.SanPhams.Where(o => o.loaiSP == s).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
