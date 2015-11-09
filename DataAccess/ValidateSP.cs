using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DataAccess
{
    partial class SanPham
    {
        partial void OnmaSPChanging(string value)
        {      
            Regex r = new Regex(@"^SP\d{1,7}$");
            if (!r.IsMatch(value))
            {
                throw new Exception("Mã phải phải bắt đầu bằng SP và không vượt quá 10 ký tự");
            }
        }
        partial void OntenSPChanging(string value)
        {
            if (value == "" || value == null)
                throw new Exception("Chưa nhập tên sản phẩm");
        }
        partial void OndongiaChanging(decimal value)
        {
            if (value<0)
                throw new Exception("Sai giá sản phẩm");
        }
    }
}
