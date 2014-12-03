using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class BasicInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "值")]
        [Required(ErrorMessage = "值不能为空！")]
        public string Value { get; set; }

        [Display(Name = "键")]
        [Required(ErrorMessage = "键不能为空！")]
        public string Key { get; set; }
    }
}