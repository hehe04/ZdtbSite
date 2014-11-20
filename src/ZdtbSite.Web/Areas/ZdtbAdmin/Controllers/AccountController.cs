using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class AccountController : Controller
    {
        // GET: ZdtbAdmin/Home
        public ActionResult Index()
        {
            ViewBag.msg = Guid.NewGuid().ToString().ToUpper();
            return View();
        }
    }
}