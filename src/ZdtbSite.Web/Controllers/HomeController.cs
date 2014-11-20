using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<ProductType> productTypeRepository;
        private IUnitOfWork unitOfWork;

        public HomeController(IRepository<ProductType> productTypeRepository, IUnitOfWork unitOfWork)
        {
            this.productTypeRepository = productTypeRepository;
            this.unitOfWork = unitOfWork;
        }

        // GET: Home
        public ActionResult Index()
        {
            ProductType productType = new ProductType()
            {
                TypeName = "变压器",
                Products = new List<Product>() 
                { 
                    new Product()
                    {
                        Name = "高压开关柜1",
                        Description = "宇宙第一开关柜"
                    },
                    new Product()
                    {
                        Name = "高压开关柜2",
                        Description = "宇宙第一开关柜"
                    }

                }
            };
            productTypeRepository.Add(productType);
            unitOfWork.Commit();
            return View();
        }

        public ActionResult Detail()
        {
            var list = productTypeRepository.GetAllAsNoTracking().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}