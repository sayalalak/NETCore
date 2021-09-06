using NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.ViewModel
{
    public class PayloadVM
    {
        public string NIK { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        //public ICollection<string> Roles { get; set; }
    }
}
