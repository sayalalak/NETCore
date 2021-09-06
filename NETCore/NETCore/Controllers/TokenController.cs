//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using NETCore.Context;
//using NETCore.Models;
//using NETCore.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace NETCore.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TokenController : ControllerBase
//    {
//        public IConfiguration _configuration;
//        private readonly MyContext myContext;

//        public TokenController(IConfiguration config, MyContext myContext)
//        {
//            _configuration = config;
//            this.myContext = myContext;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post(LoginVM login)
//        {
//            //var account = myContext.Accounts.Where(e => e.NIK == person.NIK).FirstOrDefault();
//            if (login != null && login.Email != null && login.Password != null)
//            {
//                var user = await GetUser(login.Email, login.Password);

//                if (user != null)
//                {
//                    var data = (from p in myContext.Persons
//                                join a in myContext.Accounts on p.NIK equals a.NIK
//                                join ar in myContext.AccountRoles on a.NIK equals ar.NIK
//                                join r in myContext.Roles on ar.RoleId equals r.Name
//                                select new PayloadVM
//                                {
//                                    NIK = p.NIK,
//                                    Email = p.Email,
//                                    Roles = r.Name[]
//                                }).ToList();
//                    //create claims details based on the user information
//                    var claims = new[] {
//                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
//                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
//                    new Claim("NIK", login.NIK.ToString()),
//                    new Claim("Email", login.Email),
//                    new Claim("RoleName", login.RoleName)
//                   };

//                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

//                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

//                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
//                }
//                else
//                {
//                    return BadRequest("Invalid credentials");
//                }
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        private async Task<LoginVM> GetUser(string email, string password)
//        {
//            return await myContext.Persons.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
//        }
//    }
//}
