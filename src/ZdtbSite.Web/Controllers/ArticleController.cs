using PagedList;
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
        private IRepository<Article> _articleRepository;
        private IRepository<ContentType> _contentTypeRepository;
        private IRepository<Product> _productRepository;

        public ArticleController(IRepository<Article> articleRepository, IRepository<Product> productRepository, IRepository<ContentType> contentTypeRepository)
        {
            _articleRepository = articleRepository;
            _contentTypeRepository = contentTypeRepository;
            _productRepository = productRepository;
        }
        // GET: Article
        public ActionResult Index(int? catelog, string keywords, string type, int pageIndex = 1, int pageSize = 5)
        {
            Page page = new Page(pageIndex, pageSize);

            IPagedList<Article> articles = null;
            if (catelog.HasValue)
            {
                articles = _articleRepository.GetPage(page, e => e.ContentTypeId == catelog && e.IsPublish, a => a.UpdateDateTime, true);
            }
            else
            {
                articles = _articleRepository.GetPage(page, e => e.IsPublish, a => a.UpdateDateTime, true);
            }


            return View(articles);
        }

        public ActionResult Detail(int id)
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            ViewBag.ContentTypes = _contentTypeRepository.GetManyAsNoTracking(x => x.Id == 2 || x.Id == 3);
            ViewBag.ActionName = "Index";
            return View(_articleRepository.GetById(id));
        }
    }
}