using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBackend.Database
{
    public class Contact
    {
            [Key] 
            public int ContactId { get; set; }
            public string HoTen { get; set; }

            public int SoDienThoai { get; set; }

            public string DiaChiEmail { get; set; }
            public string NoiDung { get; set; }
            
    }
}
