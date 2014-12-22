using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Models
{
    public class PayViewModel
    {
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "必须输入姓名.")]
        public string Name { get; set; }

        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "必须输入邮箱.")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [RegularExpression("[\\d\\w]+@[\\d\\w]+\\.[\\d\\w]+", ErrorMessage = "请输入正确的邮箱地址")]
        public string Email { get; set; }

        [Display(Name = "联系方式")]
        [Required(ErrorMessage = "必须输入联系方式.")]
        public string Phone { get; set; }

        [Display(Name = "预付款")]
        [Required(ErrorMessage = "必须输入联系预付款.")]
        public decimal Amount { get; set; }

        public string AttachData { get; set; }
    }
}