using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Controllers
{
    public class AboutController : BaseController
    {
        private IRepository<Product> _productRepository;
        private IRepository<ContentType> _contentType;
        public AboutController(IRepository<Product> productRepository, IRepository<ContentType> contentType)
        {
            _productRepository = productRepository;
            _contentType = contentType;
        }

        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TechnologySupportIndex(string catelog, int pageIndex = 1, int pageSize = 2)
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            ViewBag.ContentType = _contentType.GetManyAsNoTracking(x => x.PrentId == 1);
            return View();
        }

        public ActionResult TechnologySupportDetail()
        {
            return View();
        }
    }
}