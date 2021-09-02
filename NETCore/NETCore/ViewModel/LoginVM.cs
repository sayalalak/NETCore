using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.ViewModel
{
    public class LoginVM
    {
        public string NIK { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string OldPassword { get; set; }
        [JsonIgnore]
        public string NewPassword { get; set; }
        [JsonIgnore]
        public string OTP { get; set; }
    }
}
