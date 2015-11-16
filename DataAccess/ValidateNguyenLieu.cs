using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace DataAccess
{
    partial class NguyenLieu
    {
        partial void OnmaNLChanging(string value)
        {
            Regex r = new Regex(@"^NL\d{1,7}$");
            if (!r.IsMatch(value))
            {
                throw new Exception("Mã phải phải bắt đầu bằng NL và không vượt quá 10 ký tự");
            }
        }
        partial void OntenNLChanging(string value)
        {
            if (value == "" || value == null)
                throw new Exception("Chưa nhập tên Nhan Vien");
        }
        partial void OndvtinhChanging(string value)
        {
            if (value == "" || value == null)
                throw new Exception("Chưa nhập đơn vị tính");
        }
    }
    }
