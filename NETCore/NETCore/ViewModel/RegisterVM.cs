using NETCore.Models;
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
        [Required]
        public string NIK { get; set; }
        public string NamaLengkap { get; set; }
        [Required]
        public string FirstName { internal get; set; }
        [Required]
        public string LastName { internal get; set; }
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public int Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { internal get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string GPA { get; set; }
        [Required]
        public int UniversityId { get; set; }
        public ICollection<AccountRole> AccountRoles { get; internal set; }
        //public int RoleId { get; set; }
    }
}
