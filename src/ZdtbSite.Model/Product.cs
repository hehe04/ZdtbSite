using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(512)]
        public string ImageUrl { get; set; }

        [StringLength(512)]
        public string ThumbnailUrl { get; set; }

        public string Description { get; set; }

        public virtual ProductType ProductType { get; set; }

        public DateTime CreateTime { get; set; }

        public Product()
        {
            CreateTime = DateTime.Now;
        }
    }
}
