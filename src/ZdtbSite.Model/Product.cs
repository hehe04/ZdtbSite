using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZdtbSite.Model
{
    /// <summary>
    /// 产品，产品模块的详细数据模型
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string ImageUrl { get; set; }

        [StringLength(1024)]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// 描述:概述
        /// </summary>
        [MaxLength]
        public string Description { get; set; }

        [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 描述:标准和应用
        /// </summary>
        [MaxLength]
        public string StandardsApplication { get; set; }

        /// <summary>
        /// 描述:机械特性
        /// </summary>
        [MaxLength]
        public string MechanicalFeatures { get; set; }

        /// <summary>
        /// 描述:电气参数
        /// </summary>
        [MaxLength]
        public string ElectricalParameters { get; set; }

        /// <summary>
        /// 描述:配件和安装
        /// </summary>
        [MaxLength]
        public string FittingsInstallation { get; set; }

        public virtual ICollection<VisitLog> VisitLogs { get; set; }

        public Product()
        {
            CreateTime = DateTime.Now;
        }
    }
}
