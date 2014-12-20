using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository<ProductType> productTypeRepository;
        private readonly IRepository<Product> productRepository;
        private IUnitOfWork unitOfWork;

        public HomeController(IRepository<ProductType> productTypeRepository, IUnitOfWork unitOfWork, IRepository<Product> productRepository)
        {
            this.productTypeRepository = productTypeRepository;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(productRepository);
            return View();
        }
    }
}