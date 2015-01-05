using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "产品名称")]
        [MaxLength(32, ErrorMessage = "最长不能超过32个字符.")]
        [Required(ErrorMessage = "必须输入类型名称.")]
        public string Name { get; set; }

        [StringLength(1024)]
        [Display(Name = "产品图片")]
        public string ImageUrl { get; set; }

        [StringLength(1024)]
        [Display(Name = "产品图片缩略图URL")]
        public string ThumbnailUrl { get; set; }

        public string showImageUrl { get; set; }

        [MaxLength]
        [Display(Name = "概述")]
        public string Description { get; set; }

        [Display(Name = "产品类型")]
      
        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }

        [Display(Name = "产品添加时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 描述:标准和应用
        /// </summary>
        [MaxLength]
        [Display(Name = "标准和应用")]
        public string StandardsApplication { get; set; }

        /// <summary>
        /// 描述:机械特性
        /// </summary>
        [MaxLength]
        [Display(Name = "机械特性")]
        public string MechanicalFeatures { get; set; }

        /// <summary>
        /// 描述:电气参数
        /// </summary>
        [MaxLength]
        [Display(Name = "电气参数")]
        public string ElectricalParameters { get; set; }

        /// <summary>
        /// 描述:配件和安装
        /// </summary>
        [MaxLength]
        [Display(Name = "配件和安装")]
        public string FittingsInstallation { get; set; }

        public virtual ICollection<VisitLog> VisitLogs { get; set; }


    }
}