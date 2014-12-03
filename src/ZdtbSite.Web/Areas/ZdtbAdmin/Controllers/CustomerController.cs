using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: ZdtbAdmin/Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}