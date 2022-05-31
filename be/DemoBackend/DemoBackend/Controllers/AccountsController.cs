using DemoBackend.Database;
using DemoBackend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DemoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountsController : ControllerBase
    {
        private readonly DemoDbContext _context;
        public AccountsController(DemoDbContext context)
        {
            _context = context;
        }

        private string issuer;
        private DateTime notBefore;

        //register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterModel([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var account = new Account()
                {
                    Username = model.Username,
                    Password = model.Password,
                    Hoten = model.Hoten,
                    Email = model.Email
                };
                _context.Account.Add(account);
                await _context.SaveChangesAsync();
                return Ok(account);
            }
            return BadRequest(ModelState.Values);
        }

        //account
        [HttpGet]
        [Route("Account")]
        public async Task<IActionResult> Account()
        {
            var items = await _context.Account.ToListAsync();
            return Ok(items);
        }

        [Authorize(AuthenticationSchemes = "AuthKey")]
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { state = 1 });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Username == model.Password )
            {
               //get token
                string secret = "g2sL6RLQh6dVRSSnCRjvEqP971-V2DGpFoUleIfKrIc";
                string iss = "dcaea177e8d14f1fb863059dde75ca3b";
                string audience = "Demo Backend";

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim(ClaimTypes.NameIdentifier, model.Username),
                        new Claim(ClaimTypes.Email, "toannguyen.thudientu@gmail.com"),
                        new Claim("FirstName", "Toan"),
                        new Claim("LastName", "Nguyen"),
                        new Claim("Role", model.Username)
                    };

                var jwt = new JwtSecurityToken
                (
                issuer = iss,
                audience = audience,
                claims = claims,
                notBefore = DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(60 * 60),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                access_token = jwtToken,
                exprires = DateTime.UtcNow.AddSeconds(60 * 60),
                role = model.Username
            });

        }
        return BadRequest(new { state = "invalid username or password"});
        }
    }

}
