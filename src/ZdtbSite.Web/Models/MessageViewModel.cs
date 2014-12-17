using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Models
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "!")]
        public string Email { get; set; }
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "!")]
        public string Message { get; set; }
    }
}