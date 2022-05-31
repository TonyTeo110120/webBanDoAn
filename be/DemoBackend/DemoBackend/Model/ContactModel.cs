using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBackend.Model
{
    public class ContactModel
    {
            [Required(ErrorMessage = "Vui lòng nhập họ tên")]
            public string HoTen { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
            public int SoDienThoai { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập địa chỉ email")]
            public string DiaChiEmail { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập nội dung liên hệ")]
            public string NoiDung { get; set; }
        
    }
}
