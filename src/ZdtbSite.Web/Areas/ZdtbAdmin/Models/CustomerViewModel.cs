using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Display(Name="客户号")]
        [Required(ErrorMessage="客户号不能为空.")]
        public long Number { get; set; }

        [Display(Name = "网络地址")]
        [StringLength(32)]
        public string IPAddress { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "浏览次数")]
        public int Count { get; set; }

        [Display(Name = "邮箱")]
        [StringLength(32)]
        [Required(ErrorMessage = "邮箱不能为空.")]
        [RegularExpression("[\\d\\w]+@[\\d\\w]+\\.[\\d\\w]+", ErrorMessage = "请输入正确的邮箱地址")]
        public string Email { get; set; }

        [Display(Name = "联系方式")]
        [StringLength(32)]
        [Required(ErrorMessage = "联系方式不能为空.")]
        [RegularExpression(@"^\s*\+?\s*(\(\s*\d+\s*\)|\d+)(\s*-?\s*(\(\s*\d+\s*\)|\s*\d+\s*))*\s*$", ErrorMessage = "请输入正确的联系方式.")]
        public string Phone { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Display(Name = "客户姓名")]
        [Required(ErrorMessage = "客户姓名不能为空.")]
        public string ContactsName { get; set; }

        /// <summary>
        /// 头像索引
        /// </summary>
        public string HeaderPath { get; set; }

        public virtual ICollection<FeedbackViewModel> Feedbacks { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public virtual ICollection<ContractViewModel> Contracts { get; set; }

    }
}