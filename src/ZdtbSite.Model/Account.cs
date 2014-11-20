using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZdtbSite.Model
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        public String Address { get; set; }

    }
}
