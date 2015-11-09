using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DataAccess
{
    partial class LoaiSP
    {
        partial void OnmaLoaiChanging(string value)
        {
            Regex r = new Regex(@"^LSP\d{1,7}$");
            if (!r.IsMatch(value))
            {
               throw new Exception("Mã phải phải bắt đầu bằng LSP và không vượt quá 10 ký tự");
            }
        }
        partial void OntenLoaiChanging(string value)
        {
            if(value==""|| value==null)
                throw new Exception("Chưa nhập tên Loại sản phẩm");
        }
    }
}
