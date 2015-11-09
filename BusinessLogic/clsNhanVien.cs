using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
    public class clsNhanVien
    {
        QLCafeDataContext db;
        public List<NhanVien> GetAllNhanVien()
        {
            db = new QLCafeDataContext();

            List<NhanVien> lst = new List<NhanVien>();
            lst = db.NhanViens.ToList();
            return lst;
        }
        public bool AddNhanVien(NhanVien s)
        {
            try
            {
                db = new QLCafeDataContext();
                db.NhanViens.InsertOnSubmit(s);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateNhanVien(NhanVien l)
        {
            try
            {
                db = new QLCafeDataContext();
                NhanVien x = db.NhanViens.Where(o => o.maNV == l.maNV).FirstOrDefault();
                if (x != null)
                {
                    x.maNV = l.maNV;
                    x.tenNV = l.tenNV;
                    x.diachi = l.diachi;
                    x.cmnd = l.cmnd;
                    x.matkhauNV = l.matkhauNV;
                    x.phai = l.phai;
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
        public bool deleteNhanVien(string s)
        {
            try
            {
                db = new QLCafeDataContext();
                NhanVien l = db.NhanViens.Where(o => o.maNV == s).FirstOrDefault();
                db.NhanViens.DeleteOnSubmit(l);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public List<NhanVien> searchTheoMaNhanVien(string s)
        {
            try
            {
                List<NhanVien> lst = new List<NhanVien>();
                db = new QLCafeDataContext();
                lst = db.NhanViens.Where(o => o.maNV == s).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NhanVien searchTheoMa(string s)
        {
            try
            {
                NhanVien lst = new NhanVien();
                db = new QLCafeDataContext();
                lst = db.NhanViens.Where(o => o.maNV == s).FirstOrDefault();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<NhanVien> searchTheoTenNhanVien(string s)
        {
            try
            {
                db = new QLCafeDataContext();
                List<NhanVien> lst = new List<NhanVien>();
                lst = db.NhanViens.Where(o => o.tenNV == s).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
