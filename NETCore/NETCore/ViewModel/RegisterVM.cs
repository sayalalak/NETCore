using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.ViewModel
{
    public class RegisterVM
    {
        [Key]
        public string NIK { get; set; }
        public string NamaLengkap { get; set; }
        public string FirstName { internal get; set; }
        public string LastName { internal get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public string Password { internal get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }
    }
}
