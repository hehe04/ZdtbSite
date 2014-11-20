using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }

        public string Msg { get; set; }

        public string RedirectUrl { get; set; }
    }
}