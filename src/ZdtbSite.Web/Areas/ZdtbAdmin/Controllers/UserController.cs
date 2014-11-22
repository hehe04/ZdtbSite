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
    public class UserController : Controller
    {
        private readonly IRepository<UserInfo> userInfoRepository = null;

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

            //pageList
            var list = userInfoRepository.GetAll().ToList();
            var viewmodelList = AutoMapper.Mapper.Map<List<Model.UserInfo>, List<Admin.UserViewModel>>(list);
            return View(viewmodelList);
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
                responseModel.RedirectUrl = Url.Action("Index");
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Msg = "添加用户失败，请重试" + ex.Message;
            }
            return Json(responseModel);
        }

        [HttpGet]
        public ActionResult Modify(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Modify(Admin.UserViewModel viewmodel)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
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
                var user = userInfoRepository.Get(u => u.Email.Equals(signIn.Email) && u.Password.Equals(signIn.Password));
                if (user == null)
                {
                    model.Success = false;
                    model.Msg = "用户名密码错误";
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Id.ToString(), DateTime.Now, DateTime.Now.AddHours(12), false, user.Id.ToString());
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));//加密身份信息，保存至Cookie 
                Response.Cookies.Add(cookie);
                model.Success = true;
                model.Msg = "登录成功，页面即将跳转";

                return Json(model, JsonRequestBehavior.AllowGet);
            });

        }
    }
}