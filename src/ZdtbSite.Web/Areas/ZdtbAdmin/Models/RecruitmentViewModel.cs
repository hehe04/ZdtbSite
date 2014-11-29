using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class RecruitmentViewModel
    {
        public int Id { get; set; }
                
        [Display(Name = "招聘职位")]
        [MaxLength(128, ErrorMessage = "最长不能超过128个字符.")]
        [Required(ErrorMessage = "必须输入招聘职位.")]
        public string Name { get; set; }

        [MaxLength]
        [Display(Name = "职位描述")]
        [Required(ErrorMessage = "必须输入招聘职位.")]
        public string  Description { get; set; }

        [MaxLength]
        [Display(Name = "招聘要求")]
        [Required(ErrorMessage = "必须输入招聘职位.")]
        public string  Requirement { get; set; }
    }
}