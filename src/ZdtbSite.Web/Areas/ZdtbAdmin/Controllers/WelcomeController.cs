using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class WelcomeController : BaseController
    {
        // GET: ZdtbAdmin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}