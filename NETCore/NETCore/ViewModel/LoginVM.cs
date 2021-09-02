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
        public string OldPassword { internal get; set; }
        public string NewPassword { internal get; set; }
        public string OTP { internal get; set; }
    }
}
