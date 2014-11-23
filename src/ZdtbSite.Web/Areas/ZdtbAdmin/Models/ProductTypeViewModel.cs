using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "类型名称")]
        [MaxLength(32, ErrorMessage = "最长不能超过32个字符.")]
        [Required(ErrorMessage = "必须输入类型名称.")]
        public string TypeName { get; set; }

        [Display(Name = "父节点")]
        public int ParentId { get; set; }

        [Display(Name = "创建人")]
        public string CreateUser { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateDateTime { get; set; }

        //public IEnumerable<ProductTypeViewModel> ProductTypes { get; set; }
    }
}