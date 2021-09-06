using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETCore.Base;
using NETCore.Repository.Data;
using NETCore.Models;
using System.Net;
using NETCore.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace NETCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : BaseController<Person, PersonRepository, string>
    {
        private readonly PersonRepository repository;
        public PersonsController(PersonRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        [HttpGet("GetRegister")]
        public ActionResult GetRegister()
        {
            var getRegister = repository.GetRegisterVMs();
            if (getRegister == null)
            {
                return NotFound(new
                {
                    status = HttpStatusCode.NotFound,
                    result = getRegister,
                    message = "Data Kosong"
                });
            }
            else
            {
                return Ok(new
                {
                    status = HttpStatusCode.OK,
                    result = getRegister,
                    message = "Success"
                });
            }
                
        }
        [HttpGet("GetRegister/{NIK}")]
        public ActionResult GetRegister(string NIK)
        {
            var getRegister = repository.GetRegister(NIK);
            if (getRegister == null)
            {
                return NotFound(new
                {
                    status = HttpStatusCode.NoContent,
                    result = getRegister,
                    message = "Data Tidak Ada"
                });
            }
            else
            {
                return Ok(new
                {
                    status = HttpStatusCode.OK,
                    result = getRegister,
                    message = "Success"
                });
            }
        }
        [HttpPost("Register")]
        public ActionResult InsertReg(RegisterVM register)
        {
            try
            {
                string val = repository.Validation(register.NIK, register.Email, register.PhoneNumber);
                if (val != "1")
                {
                    return StatusCode((int)HttpStatusCode.BadGateway, new
                    {
                        status = (int)HttpStatusCode.BadGateway,
                        message = val
                    });
                }

                if (repository.InsertReg(register) > 0)
                {
                    return Ok(new { 
                        status = HttpStatusCode.OK, 
                        message = "Data Berhasil ditambahkan" });
                }
                else if (repository.InsertReg(register) == 0)
                {
                    return BadRequest(new { 
                        status = HttpStatusCode.BadRequest, 
                        message = "Gagal Menambahkan Data" });
                }
                else
                {
                    return BadRequest(new { 
                        status = HttpStatusCode.BadRequest, 
                        message = "Data Sudah ada" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { 
                    status = HttpStatusCode.BadRequest, 
                    message = e.Message });
            }

        }
       
    }
}
