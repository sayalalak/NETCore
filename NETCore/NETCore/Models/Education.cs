using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    [Table("tb_tr_educations")]
    public class Education
    {
        public Education(string degree, string gPA, int universityId)
        {
            Degree = degree;
            GPA = gPA;
            UniversityId = universityId;
        }

        public int Id { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }
        public virtual University University { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profiling> Profilings { get; set; }
    }
}
