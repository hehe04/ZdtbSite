using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using PagedList;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IRepository<UserInfo> userInfoRepository = null;

        private string CurrentUrl { get { return Url.Action("Index", "User"); } }

        private IUnitOfWork unitOfWork = null;
        public UserController(IRepository<UserInfo> userInfoRepository, IUnitOfWork unitOfWork)
        {
            this.userInfoRepository = userInfoRepository;
            this.unitOfWork = unitOfWork;
        }
        // GET: ZdtbAdmin/User
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<UserInfo> pageList = userInfoRepository.GetPage(page, e => true, e => e.Id);
            //var viewmodelList = AutoMapper.Mapper.Map<IPagedList<Model.UserInfo>, StaticPagedList<Admin.UserViewModel>>(pageList);
            return View(pageList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Admin.UserViewModel viewmodel)
        {
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            try
            {
                viewmodel.CreateDateTime = DateTime.Now;
                var userModel = AutoMapper.Mapper.Map<Admin.UserViewModel, Model.UserInfo>(viewmodel);
                userModel.Password = viewmodel.Password.ToMd5String();
                userInfoRepository.Add(userModel);
                unitOfWork.Commit();
                responseModel.Success = true;
                responseModel.Msg = "添加用户成功，页面即将跳转到用户列表页";
                responseModel.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Msg = "添加用户失败，请重试" + ex.Message;
            }
            return Json(responseModel);
        }

        public ActionResult ValidateEmail(string Email)
        {
            var user = userInfoRepository.Get(e => e.Email == Email);
            return Json(user == null ? true : false);
        }

        [HttpGet]
        public ActionResult Modify(int id)
        {
            UserInfo userInfo = userInfoRepository.GetById(id);
            Admin.UserViewModel viewModel = AutoMapper.Mapper.Map<Model.UserInfo, Admin.UserViewModel>(userInfo);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Modify(Admin.UserViewModel viewmodel)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                var userModel = AutoMapper.Mapper.Map<Admin.UserViewModel, Model.UserInfo>(viewmodel);
                userModel.CreateDateTime = DateTime.Now;
                userInfoRepository.Update(userModel);
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "成功更新用户信息，页面即将跳转到用户列表页";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "修改用户失败，请重试" + ex.Message;
            }
            return Json(model);
        }

        public ActionResult Delete(int id)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                userInfoRepository.Delete(userInfoRepository.GetById(id));
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "成功删除用户";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "删除用户失败，请重试" + ex.Message;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RestPwd(int id = 1)
        {
            UserInfo user = userInfoRepository.GetById(id);
            Admin.UserViewModel model = AutoMapper.Mapper.Map<UserInfo, Admin.UserViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public ActionResult RestPwd(Admin.UserViewModel viewModel)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                var user = userInfoRepository.GetById(viewModel.Id);
                user.Password = viewModel.Password.ToMd5String();
                userInfoRepository.Update(user);
                unitOfWork.Commit();
                model.Success = true;
                model.RedirectUrl = CurrentUrl;
                model.Msg = "重置密码成功，页面即将跳转";
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "重置密码失败，请重试";
            }

            return Json(model);
        }

        [HttpGet]
        public ActionResult Assign(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Assign(Admin.UserViewModel viewmodel)
        {
            return View();
        }

        [HttpGet]
        public ActionResult SingIn()
        {
            return View();
        }

        [HttpPost]
        public Task<ActionResult> SingIn(Admin.SignInViewModel signIn)
        {
            return Task.Factory.StartNew<ActionResult>(() =>
            {
                Admin.ResponseModel model = new Admin.ResponseModel();
                var loginPwd = signIn.Password.ToMd5String();
                var user = userInfoRepository.Get(u => u.Email.Equals(signIn.Email) && u.Password.Equals(loginPwd));
                if (user == null)
                {
                    model.Success = false;
                    model.Msg = "用户名密码错误";
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Id.ToString() + "|" + user.UserName + "|" + user.Email, DateTime.Now, DateTime.Now.AddHours(12), false, user.Id.ToString());
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));//加密身份信息，保存至Cookie 
                Response.Cookies.Add(cookie);
                model.Success = true;
                model.Msg = "登录成功，页面即将跳转";
                model.RedirectUrl = CurrentUrl;

                return Json(model, JsonRequestBehavior.AllowGet);
            });

        }

        public ActionResult SingOut()
        {
            FormsAuthentication.SignOut();
            Admin.ResponseModel model = new Admin.ResponseModel();
            model.Success = true;
            model.Msg = "您已经成功退出登录";
            model.RedirectUrl = Url.Action("SingIn");
            return Json(model, JsonRequestBehavior.AllowGet);

        }
    }
}