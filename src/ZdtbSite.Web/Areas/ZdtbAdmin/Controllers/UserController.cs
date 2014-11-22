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
        public ActionResult Index()
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