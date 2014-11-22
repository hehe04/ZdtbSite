using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IRepository<Model.ProductType> productTypeRepository;
        private IUnitOfWork unitOfWork;
        public ProductTypeController(IRepository<ProductType> productTypeRepository, IUnitOfWork unitOfWork)
        {
            this.productTypeRepository = productTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        // GET: ZdtbAdmin/ProductType
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}