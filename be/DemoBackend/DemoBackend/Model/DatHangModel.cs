using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBackend.Model
{
    public class DatHangModel
    {
        public string ProductName { get; set; }
        public string HoTen { get; set; }

        [Range(0,1000)]
        public int SoLuong { get; set; }
        public int Price { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public int SoDienThoai { get; set; }
    }
}
