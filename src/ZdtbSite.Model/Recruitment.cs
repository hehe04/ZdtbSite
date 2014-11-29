using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZdtbSite.Model
{
    public class Recruitment
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [MaxLength]
        public string  Description { get; set; }

        [MaxLength]
        public string  Requirement { get; set; }
    }
}
