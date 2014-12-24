using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: ZdtbAdmin/Error
        public ActionResult Index()
        {
            return View();
        }
    }
}