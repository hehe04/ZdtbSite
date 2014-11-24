using PagedList;
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
    public class ProductController : Controller
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
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<Product> pageList = productRepository.GetPage(page, e => true, e => e.Id);
            return View(pageList);
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


        [HttpGet]
        public ActionResult Modify(int id)
        {
            Product ProductInfo = productRepository.GetById(id);
            Admin.ProductViewModel model = AutoMapper.Mapper.Map<Model.Product, Admin.ProductViewModel>(ProductInfo);
            var list = productTypeRepository.GetAll().ToList();
            ViewBag.DropDownListResult = new ProductTypeController(productTypeRepository, unitOfWork).BindDropDownList(0, list);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(Admin.ProductViewModel viewmodel)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                var ProductInfo = AutoMapper.Mapper.Map<Admin.ProductViewModel, Model.Product>(viewmodel);
                ProductInfo.CreateTime = DateTime.Now;
                ProductInfo.ProductType = productTypeRepository.GetById(viewmodel.ProductType_Id);
                bool flg = TryUpdateModel<Model.Product>(ProductInfo);
                productRepository.Update(ProductInfo);
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "成功更新产品信息，页面即将跳转到用产品表页";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "更新产品信息失败，请重试" + ex.Message;
            }
            return Json(model);
        }

        public ActionResult Delete(int id)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                productRepository.Delete(productRepository.GetById(id));
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "删除产品成功！";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "删除产品失败，请重试" + ex.Message;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}