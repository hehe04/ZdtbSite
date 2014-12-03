using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "用户名")]
        [MaxLength(32, ErrorMessage = "最长不能超过32个字符.")]
        [Required(ErrorMessage = "必须输入用户名.")]
        public string UserName { get; set; }

        [Display(Name = "邮箱")]
        [EmailAddress(ErrorMessage = "邮件格式不正确.")]
        [Required(ErrorMessage = "必须输入邮箱地址.")]
        [System.Web.Mvc.Remote("ValidateEmail", "User", HttpMethod = "post", ErrorMessage = "该邮箱已被注册")]
        public string Email { get; set; }

        [Display(Name = "密码")]
        [MaxLength(64, ErrorMessage = "密码长度不能超过64个字符")]
        [Required(ErrorMessage = "必须输入密码.")]
        public string Password { get; set; }

        [Display(Name = "确认密码")]
        [MaxLength(64, ErrorMessage = "密码长度不能超过64个字符")]
        [Required(ErrorMessage = "必须输入确认密码.")]
        [Compare("Password", ErrorMessage = "两次密码不一致，请从新输入")]
        public string ConfirmPassword { get; set; }

        public DateTime CreateDateTime { get; set; }

        [Display(Name = "手机号")]
        [RegularExpression("\\d{11}", ErrorMessage = "手机号码格式不正确")]
        [Required(ErrorMessage = "手机号码必须输入")]
        public string Mobile { get; set; }

        [Display(Name = "是否锁定")]
        public bool IsActive { get; set; }

        public int LoginErrorCount { get; set; }

        public string AuthorityUrl { get; set; }

        public DateTime LastLoginDateTime { get; set; }
    }
}