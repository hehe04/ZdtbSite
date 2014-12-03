using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZdtbSite.Model
{
    /// <summary>
    /// 产品类型 负责产品类类型的详细数据
    /// </summary>
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string TypeName { get; set; }

        public int ParentId { get; set; }

        [StringLength(32)]
        public string CreateUser { get; set; }

        public DateTime CreateDateTime { get; set; }

        public IEnumerable<ProductType> ProductTypes { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public int Level { get; set; }
    }
}
