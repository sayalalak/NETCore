using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    [Table("tb_m_reset_passwords")]
    public class ResetPassword
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string OTP { get; set; }
        public string NIK { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
