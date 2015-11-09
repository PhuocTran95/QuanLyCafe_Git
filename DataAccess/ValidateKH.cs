using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DataAccess
{
    partial class KhachHang
    {
        partial void OncmndChanging(string value)
        {
            Regex regex=new Regex(@"^\d{9}$");
            if(!regex.IsMatch(value))
                throw new Exception("Số CMND không hợp lệ. (CMND gồm 9 chữ số)");
        }
        partial void OnmaKHChanging(string value)
        {
            Regex regex = new Regex(@"^KH\d+");
            if (!regex.IsMatch(value))
                throw new Exception("Mã khách hàng không hợp lệ. (VD: KH00001)");
        }
        partial void OntenKHChanging(string value)
        {
            Regex regex = new Regex(@"^[A-Z][a-z]+");
            if (!regex.IsMatch(value))
                throw new Exception("Tên khách hàng không hợp lệ.");
        }
    }
}
