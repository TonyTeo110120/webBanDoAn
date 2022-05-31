using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBackend.Database
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options)
            : base(options)
        { }
        //dbset giúp maxtrinh tới cái bảng
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contact { get; set; }

        public DbSet<Account> Account { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
    }
}