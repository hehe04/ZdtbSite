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
    public class RecruitmentController : BaseController
    {
        private readonly IRepository<Recruitment> RecruitmentRepository;
        private IUnitOfWork unitOfWork;
        private string CurrentUrl { get { return Url.Action("Index", "Recruitment"); } }
        public RecruitmentController(IRepository<Recruitment> RecruitmentRepository, IUnitOfWork unitOfWork)
        {
            this.RecruitmentRepository = RecruitmentRepository;
            this.unitOfWork = unitOfWork;
        }
        // GET: ZdtbAdmin/Recruitment
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<Recruitment> pageList = RecruitmentRepository.GetPage(page, e => true, e => e.Id);
            //for (int i = 0; i < pageList.Count; i++)
            //{
            //    string Description = pageList[i].Description;
            //    string Requirement = pageList[i].Requirement;
            //    if (Description.Length > 50)
            //    {
            //        pageList[i].Description = Description.Substring(0, 50).Trim() + "...";
            //    }
            //    if (Requirement.Length > 50)
            //    {
            //        pageList[i].Requirement = Requirement.Substring(0, 50).Trim() + "...";
            //    }
            //}
            return View(pageList);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Admin.RecruitmentViewModel viewModel)
        {
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            try
            {
                var RecruitmentModel = AutoMapper.Mapper.Map<Admin.RecruitmentViewModel, Model.Recruitment>(viewModel);
                RecruitmentRepository.Add(RecruitmentModel);
                unitOfWork.Commit();
                responseModel.Success = true;
                responseModel.Msg = "添加招聘信息成功，页面即将跳转到人才招聘首页";
                responseModel.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Msg = "添加招聘信息失败，请重试！" + ex.Message;
                Elmah.ErrorSignal.FromContext(HttpContext.ApplicationInstance.Context).Raise(ex);
            }
            return Json(responseModel);
        }


        [HttpGet]
        public ActionResult Modify(int id)
        {
            Recruitment Recruitment = RecruitmentRepository.GetById(id);
            Admin.RecruitmentViewModel model = AutoMapper.Mapper.Map<Model.Recruitment, Admin.RecruitmentViewModel>(Recruitment);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(Admin.RecruitmentViewModel viewmodel)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                var Recruitment = AutoMapper.Mapper.Map<Admin.RecruitmentViewModel, Model.Recruitment>(viewmodel);
                RecruitmentRepository.Update(Recruitment);
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "成功更新招聘信息，页面即将跳转到人才招聘列表页面";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "更新招聘信息失败，请重试" + ex.Message;
                Elmah.ErrorSignal.FromContext(HttpContext.ApplicationInstance.Context).Raise(ex);
            }
            return Json(model);
        }

        public ActionResult Delete(int id)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                RecruitmentRepository.Delete(RecruitmentRepository.GetById(id));
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "删除招聘信息成功！";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "删除招聘信息失败，请重试" + ex.Message;
                Elmah.ErrorSignal.FromContext(HttpContext.ApplicationInstance.Context).Raise(ex);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}