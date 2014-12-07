using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Core.Repository;
using ZdtbSite.Model;

namespace ZdtbSite.Web.ActionFilters
{
    public class ClientVisitAttribute : ActionFilterAttribute
    {
        public IRepository<VisitLog> VisitLogRepository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public ClientVisitAttribute()
            : base()
        {
            VisitLogRepository = DependencyResolver.Current.GetService<IRepository<VisitLog>>();
            UnitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var log = new VisitLog();
            log.IpAddress = filterContext.HttpContext.Request.UserHostAddress;
            log.VisitDateTime = DateTime.Now;

            try
            {
                var objId = filterContext.Controller.ControllerContext.RouteData.Values["Id"];
                if (objId != null)
                {
                    int id = Convert.ToInt32(objId);
                    log.ProductId = id;
                }
                VisitLogRepository.Add(log);
                UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
            }
        }

    }
}