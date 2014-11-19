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

        public virtual ICollection<Product> Products { get; set; }
    }
}
