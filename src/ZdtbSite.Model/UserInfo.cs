using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Model
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(32)]
        public string UserName { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(64)]
        public string Password { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime LastLoginDateTime { get; set; }

        [StringLength(64)]
        public string Mobile { get; set; }

        public bool IsActive { get; set; }

        public int LoginErrorCount { get; set; }

        [MaxLength]
        public string AuthorityUrl { get; set; }

    }
}
