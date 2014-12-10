using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;
using Mail = ZdtbSite.Core.Helper.EmailHelper;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class BasicInfoController : Controller
    {
        private string CurrentUrl { get { return Url.Action("Index", "BasicInfo"); } }
        private readonly IRepository<BasicInfo> BasicInfoRepository;
        private IUnitOfWork unitOfWork;
        public BasicInfoController(IRepository<BasicInfo> BasicInfoRepository, IUnitOfWork unitOfWork)
        {
            this.BasicInfoRepository = BasicInfoRepository;
            this.unitOfWork = unitOfWork;
        }
        // GET: ZdtbAdmin/BasicInfo
        public ActionResult Index()
        {
            List<Admin.BasicInfoViewModel> BasicInfoList = new List<Admin.BasicInfoViewModel>();
            try
            {
                //pageList
                var list = BasicInfoRepository.GetAll().ToList();
                BasicInfoList = AutoMapper.Mapper.Map<List<Model.BasicInfo>, List<Admin.BasicInfoViewModel>>(list);
            }
            catch (Exception)
            {
            }
            return View(BasicInfoList);
        }

        [HttpPost]
        public ActionResult Save([Bind(Prefix = "item")]Admin.BasicInfoViewModel ViewMode)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                var BasicInfoInfo = AutoMapper.Mapper.Map<Admin.BasicInfoViewModel, Model.BasicInfo>(ViewMode);
                BasicInfoRepository.Update(BasicInfoInfo);
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "企业信息更新成功！";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "企业信息失败，请重试" + ex.Message;
            }
            return Json(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Admin.BasicInfoViewModel viewModel)
        {
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            try
            {
                var BasicInfoModel = AutoMapper.Mapper.Map<Admin.BasicInfoViewModel, Model.BasicInfo>(viewModel);
                int count = BasicInfoRepository.GetAll().Where(e => e.Key == viewModel.Key).Count();
                if (count > 0)
                {
                    responseModel.Success = false;
                    responseModel.Msg = "key已经存在，请重新输入！";
                }
                else
                {
                    BasicInfoRepository.Add(BasicInfoModel);
                    unitOfWork.Commit();
                    responseModel.Success = true;
                    responseModel.Msg = "添加企业信息成功，页面即将跳转到企业信息首页";
                    responseModel.RedirectUrl = CurrentUrl;
                }
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Msg = "添加企业信息失败，请重试！" + ex.Message;
            }
            return Json(responseModel);
        }


        public ActionResult Delete(int id)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                BasicInfoRepository.Delete(BasicInfoRepository.GetById(id));
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "删除企业信息成功！";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "删除企业信息失败，请重试" + ex.Message;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult sendEmailTest()
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {                
                List<string> mailList = new List<string>();
                mailList.Add("shenxiuyun@qq.com");
                mailList.Add("289117857@qq.com");
                mailList.Add("13200652@qq.com");
                mailList.Add("jiangchun1320@163.com");
                string title = "测试邮件";
                string text = DateTime.Now + ":测试内容";
                Mail.SendEmail(mailList, "ZdtbSite", title, text);
                model.Success = true;
                model.Msg = "发送成功！";
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "邮件发送失败!" + ex.Message;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}