using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
    public class clsNguyenLieu
    {
        QLCafeDataContext db;
        public List<NguyenLieu> GetAllNguyenLieu()
        {
            db = new QLCafeDataContext();

            List<NguyenLieu> lst = new List<NguyenLieu>();
            lst = db.NguyenLieus.ToList();
            return lst;
        }
        public bool AddNguyenLieu(NguyenLieu s)
        {
            try
            {
                db = new QLCafeDataContext();
                db.NguyenLieus.InsertOnSubmit(s);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateNguyenLieu(NguyenLieu l)
        {
            try
            {
                db = new QLCafeDataContext();
                NguyenLieu x = db.NguyenLieus.Where(o => o.maNL == l.maNL).FirstOrDefault();
                if (x != null)
                {
                    x.tenNL = l.tenNL;
                    x.dvtinh = l.dvtinh;
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
        public bool deleteNguyenLieu(string s)
        {
            try
            {
                db = new QLCafeDataContext();
                NguyenLieu l = db.NguyenLieus.Where(o => o.maNL == s).FirstOrDefault();
                db.NguyenLieus.DeleteOnSubmit(l);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public List<NguyenLieu> searchTheoMa(string s)
        {
            try
            {
                List<NguyenLieu> lst = new List<NguyenLieu>();
                db = new QLCafeDataContext();
                lst = db.NguyenLieus.Where(o => o.maNL == s).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<NguyenLieu> searchTheoTen(string s)
        {
            try
            {
                db = new QLCafeDataContext();
                List<NguyenLieu> lst = new List<NguyenLieu>();
                lst = db.NguyenLieus.Where(o => o.tenNL == s).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string getMaNL(string tenNL)
        {
            db = new QLCafeDataContext();
            NguyenLieu lst = new NguyenLieu();
            lst = db.NguyenLieus.Where(o => o.tenNL == tenNL).FirstOrDefault();
            return lst.maNL;
        }

        public string getDVTinh(string tenNL)
        {
            db = new QLCafeDataContext();
            NguyenLieu lst = new NguyenLieu();
            lst = db.NguyenLieus.Where(o => o.tenNL == tenNL).FirstOrDefault();
            return lst.dvtinh;
        }
    }
}
