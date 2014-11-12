using System.Web.Mvc;

namespace ZdtbSite.Web.Areas.ZdtbAdmin
{
    public class ZdtbAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ZdtbAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ZdtbAdmin_default",
                "ZdtbAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}