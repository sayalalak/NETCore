using ImplementCors.Base.Urls;
using Microsoft.AspNetCore.Http;
using NETCore.Models;
using NETCore.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCors.Repositories.Data
{
    
    public class PersonRepository : GeneralRepository<Person, string >
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public PersonRepository(Address address, string request = "Persons/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<List<RegisterVM>> GetAllProfile()
        {
            List<RegisterVM> registers = new List<RegisterVM>();

            using (var response = await httpClient.GetAsync(request + "GetRegister"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                registers = JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return registers;
        }
        public async Task<RegisterVM> GetById(string nik)
        {
            RegisterVM entity = new RegisterVM();

            using (var response = await httpClient.GetAsync(request + "GetRegister/" + nik))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<RegisterVM>(apiResponse);
            }
            return entity;
        }
        public String PostRegister(RegisterVM register)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(request + "Register", content).Result.Content.ReadAsStringAsync().Result;
            return response;
        }
    }
}
