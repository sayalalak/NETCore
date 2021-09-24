using ImplementCors.Base.Controllers;
using ImplementCors.Repositories.Data;
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
    public class PersonsController : BaseController<Person, PersonRepository, string>
    {
        private readonly PersonRepository repository;
        public PersonsController(PersonRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet("GetById/{NIK}")]
        public async Task<JsonResult> GetById(string nik)
        {
            var result = await repository.GetById(nik);
            return Json(result);
        }
        [HttpGet("GetAllData")]
        public async Task<JsonResult> GetAllData()
        {
            var result = await repository.GetAllProfile();
            return Json(result);
        }
        [HttpPost("PostReg")]
        public JsonResult PostReg([FromBody]RegisterVM register)
        {
            var result = repository.PostRegister(register);
            return Json(result);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
