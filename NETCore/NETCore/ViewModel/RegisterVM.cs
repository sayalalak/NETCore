using NETCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static NETCore.Models.Person;

namespace NETCore.ViewModel
{
    public class RegisterVM
    {
        [Key]
        [Required]
        public string NIK { get; set; }
        public string NamaLengkap { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
        [Required]
        public int Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string GPA { get; set; }
        public int UniversityId { get; set; }
        public string UniversityName { get; internal set; }
        public ICollection<AccountRole> AccountRoles { get; internal set; }
        
        //public int RoleId { get; set; }
    }
}
