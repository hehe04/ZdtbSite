using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public string Description { get; set; }

        public string ProductTypeName{ get; set; }

        public int ProductTypeId { get; set; }

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 描述:标准和应用
        /// </summary>
        public string StandardsApplication { get; set; }

        /// <summary>
        /// 描述:机械特性
        /// </summary>
        public string MechanicalFeatures { get; set; }

        /// <summary>
        /// 描述:电气参数
        /// </summary>
        public string ElectricalParameters { get; set; }

        /// <summary>
        /// 描述:配件和安装
        /// </summary>
        public string FittingsInstallation { get; set; }
    }
}