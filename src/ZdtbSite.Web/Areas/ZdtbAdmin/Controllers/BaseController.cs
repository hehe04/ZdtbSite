using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class BaseController : Controller
    {
        private int loginUserId;
        public int LoginUserId { get { return loginUserId; } }
        public string LoginUserName { get; set; }

        public string LoginUserEmail { get; set; }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            string action = filterContext.RouteData.Values["Action"].ToString();
            if (string.Equals(action, "SingIn", StringComparison.OrdinalIgnoreCase)) { return; }
            if (string.Equals(action, "logout", StringComparison.OrdinalIgnoreCase)) { return; }
            if (string.Equals(action, "TestConnection", StringComparison.OrdinalIgnoreCase)) { return; }
            if (HttpContext.Request.IsAuthenticated)
            {
                try
                {
                    HttpCookie authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie 
                    FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密 
                    string[] userData = Ticket.UserData.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    if (int.TryParse(userData[0], out loginUserId))
                    {

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                ///TODO 请登录
            }
            base.OnAuthorization(filterContext);
        }
    }
}