using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class UserViewModel
    {

        [MaxLength(32)]
        public string UserName { get; set; }

        [MaxLength(64)]
        public string Email { get; set; }

        [MaxLength(64)]
        public string Password { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime LastLoginDateTime { get; set; }

        [MaxLength(64)]
        public string Mobile { get; set; }

        public bool IsActive { get; set; }
    }
}