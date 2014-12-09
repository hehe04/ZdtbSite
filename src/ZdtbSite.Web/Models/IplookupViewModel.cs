using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Models
{
    public class IplookupViewModel
    {
        public string ErrNum { get; set; }
        public string ErrMsg { get; set; }
        public DetailData RetData { get; set; }
    }
    public class DetailData
    {
        public string IP { get; set; }
        public string Country { get; set; }
        public string Area { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string carrier { get; set; }
    }


}