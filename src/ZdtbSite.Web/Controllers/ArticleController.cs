using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Controllers
{
    public class ArticleController : BaseController
    {
        private IRepository<Product> _productRepository;
        private IRepository<ContentType> _contentTypeRepository;

        public ArticleController(IRepository<Product> productRepository, IRepository<ContentType> contentTypeRepository)
        {
            _productRepository = productRepository;
            _contentTypeRepository = contentTypeRepository;
        }
        // GET: Article
        public ActionResult Index(string catelog, string keywords, int pageIndex = 1)
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            ViewBag.ContentTypes = _contentTypeRepository.GetAllAsNoTracking();
            return View();
        }
    }
}