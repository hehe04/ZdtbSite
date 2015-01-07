using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Controllers
{
    public class DocumentController : BaseController
    {
        IRepository<Document> _documentRepository;
        IRepository<Product> _productRepository;
        public DocumentController(IRepository<Document> documentRepository, IRepository<Product> productRepository)
        {
            _documentRepository = documentRepository;
            _productRepository = productRepository;
        }

        // GET: File
        public ActionResult Index()
        {
            var model = _documentRepository.GetAllAsNoTracking();
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            return View(model);
        }
    }
}