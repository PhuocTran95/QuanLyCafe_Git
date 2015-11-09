using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DataAccess
{
    partial class NhanVien
    {
        partial void OnmaNVChanging(string value)
        {
            Regex r = new Regex(@"^NV\d{1,7}$");
            if (!r.IsMatch(value))
            {
                throw new Exception("Mã phải phải bắt đầu bằng NV và không vượt quá 10 ký tự");
            }
        }
        partial void OntenNVChanging(string value)
        {
            if (value == "" || value == null)
                throw new Exception("Chưa nhập tên Nhan Vien");
        }
        partial void OnphaiChanging(string value)
        {
            if (value == "" || value == null)
                throw new Exception("Chưa chọn giới tính");
        }
        partial void OncmndChanging(string value)
        {
            Regex r = new Regex(@"^\d{9}$");
            if (!r.IsMatch(value))
            {
                throw new Exception("CMND sai. vui lòng nhập lại");
            }
        }
        partial void OnmatkhauNVChanging(string value)
        {
            if (value == "" || value == null)
                throw new Exception("Vui lòng xác nhận lại PassWord");
        }
    }
}
