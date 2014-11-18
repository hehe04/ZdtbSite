using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZdtbSite.Model
{
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

        [MaxLength]
        public string Description { get; set; }

        public virtual ProductType ProductType { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual ICollection<VisitLog> VisitLogs { get; set; }

        public Product()
        {
            CreateTime = DateTime.Now;
        }
    }
}
