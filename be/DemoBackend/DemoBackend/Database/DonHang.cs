using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBackend.Database
{
    public class DonHang
    {
        [Key]
        public int DonHangId { get; set; }
        public string ProductName { get; set; }
        public int SoLuong { get; set; }
        public int Price { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int SoDienThoai { get; set; }
    }
}
