using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }

        public string TypeName { get; set; }

        public int ParentId { get; set; }

        public string CreateUser { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}