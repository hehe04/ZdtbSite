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
    public class DocumentController : BaseController
    {
        private IRepository<Document> documentRepository = null;
        private IUnitOfWork unitofWork = null;
        public DocumentController(IRepository<Document> documentRepository, IUnitOfWork unitofWork)
        {
            this.documentRepository = documentRepository;
            this.unitofWork = unitofWork;
        }

        // GET: ZdtbAdmin/Document
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<Document> list = documentRepository.GetPage(page, e => true, e => e.CreateDate, true);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Admin.DocumentViewModel viewModel, HttpPostedFileBase fileElem)
        {
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            string path = string.Empty;
            if (Request.Files.Count == 1)
                UploadFile(fileElem, ref path);
            Document doc = AutoMapper.Mapper.Map<Admin.DocumentViewModel, Document>(viewModel);
            doc.Path = path;
            doc.CreateBy = LoginUserName;
            documentRepository.Add(doc);
            unitofWork.Commit();
            responseModel.Success = true;
            responseModel.Msg = "添加文档成功，页面即将跳转到产品列表页";
            responseModel.RedirectUrl = Url.Action("Index");
            return Json(responseModel, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Modify(int id)
        {
            Document doc = documentRepository.GetById(id);
            Admin.DocumentViewModel model = AutoMapper.Mapper.Map<Model.Document, Admin.DocumentViewModel>(doc);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(Admin.DocumentViewModel viewmodel, HttpPostedFileBase fileElem)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                if (Request.Files.Count == 1)
                {
                    string path = string.Empty;
                    UploadFile(fileElem, ref path);
                    viewmodel.Path = path;
                }
                viewmodel.CreateDate = DateTime.Now;
                //viewmodel.ProductType = productTypeRepository.GetById(viewmodel.ProductTypeId);
                var doc = AutoMapper.Mapper.Map<Admin.DocumentViewModel, Model.Document>(viewmodel);
                doc.CreateBy = LoginUserName;
                documentRepository.Update(doc);
                unitofWork.Commit();
                model.Success = true;
                model.Msg = "成功更新文档信息，页面即将跳转到用产品表页";
                model.RedirectUrl = Url.Action("Index");
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "更新文档信息失败，请重试" + ex.Message;
                Elmah.ErrorSignal.FromContext(HttpContext.ApplicationInstance.Context).Raise(ex);
            }
            return Json(model);
        }


        public ActionResult Delete(int id)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                documentRepository.Delete(documentRepository.GetById(id));
                unitofWork.Commit();
                model.Success = true;
                model.Msg = "删除文档成功！";
                model.RedirectUrl = Url.Action("Index");
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "删除文档失败，请重试" + ex.Message;
                Elmah.ErrorSignal.FromContext(HttpContext.ApplicationInstance.Context).Raise(ex);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}