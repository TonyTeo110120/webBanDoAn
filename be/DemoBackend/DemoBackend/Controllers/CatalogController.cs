using DemoBackend.Database;
using DemoBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly DemoDbContext _context;
        public CatalogController(DemoDbContext context)
        {
            _context = context;
        }

        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var items = await _context.Categories.ToListAsync();
            return Ok(items);
        }

        [Route("product")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var items = await _context.Products.ToListAsync();
            return Ok(items);
        }
        [Route("product-by-category/{id}")]
        [HttpGet]   
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var items = await _context.Products
                .Where(x => x.CategoryId == id)
                .ToListAsync();
            return Ok(items);
        }

        [Route("product/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductsByID(int id)
        {
            var items = await _context.Products
                .Where(x => x.ProductId == id)
                .ToListAsync();
            return Ok(items);
        }


        [Route("add-product")]
            [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddModel model)
        {
            if(ModelState.IsValid)
            {
                var product = new Product()
                {
                    Avatar = model.Avatar,
                    CategoryId = model.CategoryId,
                    InStocks = model.InStocks,
                    Price = model.Price,
                    ProductName = model.ProductName,
                };
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            return BadRequest(ModelState.Values);
        }

        //edit sp
        [HttpPut("update-sanpham/{id}")]
        public async Task<IActionResult> PutSanPham(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //delete
        [HttpDelete("delete-sanpham/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }




        //search
        [Route("search/{nameData}")]
        [HttpGet]
        public async Task<IActionResult> GetProductsByName(string nameData)
        {
            var items = await _context.Products
                .Where(x => x.ProductName.Contains(nameData))
                .ToListAsync();
            return Ok(items);   
        }


        //don hang
        [Route("donhang")]
        [HttpGet]
        public async Task<IActionResult> GetDonHang()
        {
            var items = await _context.DonHang.ToListAsync();
            return Ok(items);
        }

        //dat hang
        [Route("dathang")]
        [HttpPost]
        public async Task<IActionResult> DatHang([FromBody] DatHangModel model)
        {
            if (ModelState.IsValid)
            {
                var donhang = new DonHang()
                {
                    ProductName = model.ProductName,
                    SoLuong = model.SoLuong,
                    Price = model.Price,
                    HoTen = model.HoTen,
                    DiaChi = model.DiaChi,
                    SoDienThoai = model.SoDienThoai,
                };
                _context.DonHang.Add(donhang);
                await _context.SaveChangesAsync();
                return Ok(donhang);
            }
            return BadRequest(ModelState.Values);
        }

        //delete-donhang
        [HttpDelete("delete-donhang/{id}")]
        public async Task<IActionResult> DeleteDonHang(int id)
        {
            var donhang = await _context.DonHang.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }

            _context.DonHang.Remove(donhang);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
