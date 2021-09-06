using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    [Table("tb_m_roles")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
