using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly AccountRepository accountRepository;
        private readonly EducationRepository educationRepository;
        private readonly PersonRepository personRepository;
        private readonly ProfilingRepository profilingRepository;
        private readonly UniversityRepository universityRepository;

        public RegistersController(AccountRepository accountRepository, 
                                  EducationRepository educationRepository, 
                                  PersonRepository personRepository, 
                                  ProfilingRepository profilingRepository, 
                                  UniversityRepository universityRepository)
        {
            this.accountRepository = accountRepository;
            this.educationRepository = educationRepository;
            this.personRepository = personRepository;
            this.profilingRepository = profilingRepository;
            this.universityRepository = universityRepository;
        }

        //[HttpGet("GetRegister")]
        //public ActionResult GetRegister()
        //{
        //    var getRegister = RegisterVM();
        //}
    }
}
