using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    [Table("tb_tr_accountroles")]
    public class AccountRole
    {
        public string NIK { get; set; }
        public int RoleId { get; set; }
        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}
