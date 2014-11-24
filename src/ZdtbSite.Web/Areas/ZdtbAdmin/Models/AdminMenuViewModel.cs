using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class AdminMenuViewModel
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public string Url { get; set; }

        public string Discretion { get; set; }

        public string Icon { get; set; }
    }
}