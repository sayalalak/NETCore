using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Models;
using NETCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldController : ControllerBase
    {
        private readonly OldRepository personRepository;
        public OldController(OldRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        [HttpPost]
        public ActionResult Insert(Person person)
        {
            try
            {
                if (personRepository.Insert(person) > 0)
                {
                    return Ok(new { status = HttpStatusCode.OK, message = "Data Berhasil ditambahkan" });
                } 
                else if (personRepository.Insert(person) == 0)
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Gagal Menambahkan Data" });
                }
                else
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Sudah ada"});
                }
            }
            catch (Exception)
            {

                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Sudah ada" });
            }
            
        }
        [HttpGet]
        public ActionResult Get()
        {
            var data = personRepository.Get();
            if (data.Count()==0)
            {

                return NotFound(new { status = HttpStatusCode.NotFound, message = "Data Kosong" });
            }
            return Ok(new { status = HttpStatusCode.OK, data, message = "Data Berhasil ditampilkan" });
        }
        [HttpGet("{NIK}")]
        public ActionResult Get(string NIK)
        {
            var data = personRepository.Get(NIK);
            //Jika data yang dicari tidak ada
            if (data == null)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Kamu salah input data gaada" });
            }
            return Ok(new { status = HttpStatusCode.OK, data, message = "Data ditemukan"});
        }

        [HttpPut]
        public ActionResult Update(Person person)
        {
            var data = personRepository.Update(person);
            try
            {
                if (data != 0)
                {
                    return Ok(new { status = HttpStatusCode.OK, data, message = "Data Berhasil diupdate" });
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR :" + e.Message);
            }
            return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data tidak ditemukan" });
        }
        [HttpDelete("{NIK}")]
        public ActionResult Delete(string NIK)
        {
            var data = personRepository.Delete(NIK);
            if (data == 0)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Gagal dihapus" });
            }
            personRepository.Delete(NIK);
            return Ok(new { status = HttpStatusCode.OK, message = "Data Berhasil dihapus" });
        }
    }
}
