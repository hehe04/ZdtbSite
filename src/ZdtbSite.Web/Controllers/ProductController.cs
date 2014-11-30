using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZdtbSite.Web.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductList(string catelog, string keywords, int pageIndex = 1)
        {
            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            return View();
        }
    }
}