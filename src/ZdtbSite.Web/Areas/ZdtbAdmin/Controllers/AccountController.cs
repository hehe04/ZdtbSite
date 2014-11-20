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
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            ZdtbAdmin.Models.ResponseModel responseModel = new Models.ResponseModel();
            responseModel.Success = true;
            responseModel.Msg = Guid.NewGuid().ToString();
            responseModel.RedirectUrl = "/ZdtbAdmin/Account/Index";
            System.Threading.Thread.Sleep(3000);
            return Json(responseModel, JsonRequestBehavior.AllowGet);
        }
    }
}