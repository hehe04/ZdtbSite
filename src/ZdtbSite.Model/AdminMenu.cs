using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Model
{
    public class AdminMenu
    {
        [Key]
        public int Id { get; set; }

        public int ParentId { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        [StringLength(64)]
        public string Url { get; set; }

        [StringLength(512)]
        public string Discretion { get; set; }
    }
}
