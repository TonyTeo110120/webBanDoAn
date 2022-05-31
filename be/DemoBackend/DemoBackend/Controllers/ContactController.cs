using DemoBackend.Database;
using DemoBackend.Model;
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
    public class ContactController : ControllerBase
    {
        private readonly DemoDbContext _context;
        public ContactController(DemoDbContext context)
        {
            _context = context;
        }

        //post contact
        [Route("add-contact")]
        [HttpPost]
        public async Task<IActionResult> ContactModel([FromBody] ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact()
                {
                    HoTen = model.HoTen,
                    SoDienThoai = model.SoDienThoai,
                    DiaChiEmail = model.DiaChiEmail,
                    NoiDung = model.NoiDung,
                };
                _context.Contact.Add(contact);
                await _context.SaveChangesAsync();
                return Ok(contact);
            }
            return BadRequest(ModelState.Values);

        }

        //contact
        [Route("Contact")]
        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            var items = await _context.Contact.ToListAsync();
            return Ok(items);
        }

        //delete contact
        [HttpDelete("delete-contact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }


    }
}
