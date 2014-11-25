using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ProductType> productTypeRepository;
        private IUnitOfWork unitOfWork;
        private string CurrentUrl { get { return Url.Action("Index", "Product"); } }

        public ProductController(IRepository<Product> productRepository, IRepository<ProductType> productTypeRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.productTypeRepository = productTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        // GET: ZdtbAdmin/Product
        public ActionResult Index()
        {
            List<Admin.ProductViewModel> ProdutList = new List<Admin.ProductViewModel>();
            try
            {
                //pageList
                var list = productRepository.GetAll().ToList();
                ProdutList = AutoMapper.Mapper.Map<List<Model.Product>, List<Admin.ProductViewModel>>(list);
            }
            catch (Exception)
            {
            }
            return View(ProdutList);
        }

        public ActionResult Add()
        {
            Admin.ProductViewModel model = new Admin.ProductViewModel();
            var list = productRepository.GetAll().ToList();
            ViewBag.DropDownListResult = new ProductTypeController(productTypeRepository, unitOfWork).BindDropDownList(0, productTypeRepository.GetAll().ToList());
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Admin.ProductViewModel viewmodel)
        {
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            try
            {
                var ProductModel = AutoMapper.Mapper.Map<Admin.ProductViewModel, Model.Product>(viewmodel);
                ProductModel.CreateTime = DateTime.Now;
                ProductModel.ProductType = productTypeRepository.GetById(viewmodel.ProductType_Id);
                productRepository.Add(ProductModel);
                unitOfWork.Commit();
                responseModel.Success = true;
                responseModel.Msg = "添加产品成功，页面即将跳转到产品列表页";
                responseModel.RedirectUrl = Url.Action("Index");
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Msg = "添加产品失败，请重试" + ex.Message;
            }
            return Json(responseModel);
        }
    }
}