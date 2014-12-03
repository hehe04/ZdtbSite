using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZdtbSite.Web.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Article
        public ActionResult Index(string catelog, string keywords, int pageIndex = 1)
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}