using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.ViewModel
{
    public class LoginVM
    {
        public string NIK { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string OldPassword { internal get; set; }
        public string NewPassword { internal get; set; }
        public string OTP { internal get; set; }
    }
}
