using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZdtbSite.Model
{
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
