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
    }
}