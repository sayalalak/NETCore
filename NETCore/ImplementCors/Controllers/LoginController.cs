using ImplementCors.Base.Controllers;
using ImplementCors.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementCors.Controllers
{
    [Route("[controller]")]
    public class LoginController : BaseController<Account, LoginRepository, string>
    {
        private readonly LoginRepository repository;

        public LoginController(LoginRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        [HttpPost("CekLogin")]
        public async Task<IActionResult> Auth(string email, string password )
        {
            var login = new LoginVM { Email = email, Password = password };
            var jwtToken = await repository.Auth(login);
            var token = jwtToken.Token;

            if (token == null)
            {
                return RedirectToAction("index");
            }

            HttpContext.Session.SetString("JWToken", token);
            //HttpContext.Session.SetString("Name", jwtHandler.GetName(token));
            //HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");

            return RedirectToAction("index", "Home");
        }
        [HttpGet("Login")]
        public IActionResult Index()
        {
            //if Logged in
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }
        [Authorize]
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}
