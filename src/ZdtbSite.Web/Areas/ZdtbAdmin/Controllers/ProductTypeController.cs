﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class ProductTypeController : BaseController
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ProductType> productTypeRepository;
        private readonly IRepository<VisitLog> VisitLogRepository;
        private IUnitOfWork unitOfWork;
        private string CurrentUrl { get { return Url.Action("Index", "ProductType"); } }
        public ProductTypeController(IRepository<ProductType> productTypeRepository, IRepository<Product> productRepository, IRepository<VisitLog> VisitLogRepository, IUnitOfWork unitOfWork)
        {
            this.productTypeRepository = productTypeRepository;
            this.productRepository = productRepository;
            this.VisitLogRepository = VisitLogRepository;
            this.unitOfWork = unitOfWork;
        }

        // GET: ZdtbAdmin/ProductType
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<ProductType> pageList = productTypeRepository.GetPage(page, e => true, e => e.Id);
            return View(pageList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Admin.ProductTypeViewModel model = new Admin.ProductTypeViewModel();
            var list = productTypeRepository.GetAll().ToList();
            ViewBag.DropDownListResult = GetDownList(0, list);
            return View(model);
        }

        public Dictionary<string, string> GetDownList(int id, List<Model.ProductType> list)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            var serachList = list.Where(e => e.ParentId.Equals(id));
            foreach (var item in serachList)
            {
                Model.ProductType model = item;
                //string TypeName = "";
                int lv = 0;
                for (int i = 0; i < item.Level; i++)
                {
                    model = list.Where(e => e.Id == model.ParentId).FirstOrDefault();
                    if (model != null) lv += 1;//nameList.Add(model.TypeName);
                }
                results.Add(item.Id.ToString(), "<label style=' margin-left:" + lv * 20 + "px;'>" + item.TypeName + "</label>");
                var result = GetDownList(item.Id, list);
                foreach (var item1 in result)
                {
                    results.Add(item1.Key, item1.Value);
                }
            }
            return results;
        }


        public Dictionary<string, string> BindDropDownList(int id, List<Model.ProductType> list)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            var serachList = list.Where(e => e.ParentId.Equals(id));
            foreach (var item in serachList)
            {
                //string typeName = "";
                Model.ProductType model = item;
                List<string> nameList = new List<string>();
                for (int i = 0; i < item.Level; i++)
                {
                    model = list.Where(e => e.Id == model.ParentId).FirstOrDefault();
                    if (model != null) nameList.Add(model.TypeName);
                }
                StringBuilder currentTypeName = new StringBuilder();
                for (int i = nameList.Count; i > 0; i--)
                {
                    currentTypeName.Append(nameList[i - 1] + " > ");
                }
                results.Add(item.Id.ToString(), currentTypeName.ToString() + item.TypeName);
                var result = BindDropDownList(item.Id, list);
                foreach (var item1 in result)
                {
                    results.Add(item1.Key, item1.Value);
                }
            }
            return results;
        }

        [HttpPost]
        public ActionResult Add(Admin.ProductTypeViewModel viewmodel)
        {
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            try
            {
                var ProductTypeModel = AutoMapper.Mapper.Map<Admin.ProductTypeViewModel, Model.ProductType>(viewmodel);
                ProductTypeModel.CreateUser = "admin";
                ProductTypeModel.CreateDateTime = DateTime.Now;
                ProductTypeModel.Level = 0;
                if (viewmodel.ParentId != 0) ProductTypeModel.Level = productTypeRepository.GetById(viewmodel.ParentId).Level + 1;
                productTypeRepository.Add(ProductTypeModel);
                unitOfWork.Commit();
                responseModel.Success = true;
                responseModel.Msg = "添加产品类型成功，页面即将跳转到产品类型列表页";
                responseModel.RedirectUrl = Url.Action("Index");
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Msg = "添加产品类型失败，请重试" + ex.Message;
            }
            return Json(responseModel);
        }
        [HttpGet]
        public ActionResult Modify(int id)
        {
            ProductType ProductTypeInfo = productTypeRepository.GetById(id);
            Admin.ProductTypeViewModel viewModel = AutoMapper.Mapper.Map<Model.ProductType, Admin.ProductTypeViewModel>(ProductTypeInfo);
            var list = productTypeRepository.GetAll().ToList();
            ViewBag.DropDownListResult = GetDownList(0, list);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Modify(Admin.ProductTypeViewModel viewmodel)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                var ProductTypeInfo = AutoMapper.Mapper.Map<Admin.ProductTypeViewModel, Model.ProductType>(viewmodel);
                ProductTypeInfo.CreateDateTime = DateTime.Now;
                productTypeRepository.Update(ProductTypeInfo);
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "成功更新产品类型信息，页面即将跳转到用产品类型表页";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "更新产品类型信息失败，请重试" + ex.Message;
            }
            return Json(model);
        }

        public ActionResult Delete(int id)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                var productList = productRepository.GetAll().Where(e => e.ProductTypeId == id).ToList();
                foreach (var product in productList)
                {
                    var visitLogList = VisitLogRepository.GetAll().Where(e => e.ProductId == product.Id).ToList();
                    foreach (var visitLog in visitLogList)
                    {
                        VisitLogRepository.Delete(visitLog);
                    }
                    unitOfWork.Commit();
                    productRepository.Delete(product);
                }
                unitOfWork.Commit();
                productTypeRepository.Delete(productTypeRepository.GetById(id));
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "删除产品类型成功！";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "删除产品类型失败，请重试" + ex.Message;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}