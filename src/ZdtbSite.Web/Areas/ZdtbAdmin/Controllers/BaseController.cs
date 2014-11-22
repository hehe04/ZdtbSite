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
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            string action = filterContext.RouteData.Values["Action"].ToString();
            if (string.Equals(action, "login", StringComparison.OrdinalIgnoreCase)) { return; }
            if (string.Equals(action, "logout", StringComparison.OrdinalIgnoreCase)) { return; }
            if (string.Equals(action, "TestConnection", StringComparison.OrdinalIgnoreCase)) { return; }
            if (HttpContext.Request.IsAuthenticated)
            {
                try
                {
                    HttpCookie authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie 
                    FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密 
                    //int.TryParse(Ticket.UserData, out LoginId);
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