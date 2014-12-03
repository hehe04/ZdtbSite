using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZdtbSite.Web.Controllers
{
    public class SupportController : BaseController
    {
        // GET: Support
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TechnologySupportIndex ()
        {
            return View();
        }

        public ActionResult TechnologySupportDetail()
        {
            return View();
        }
    }
}