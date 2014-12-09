using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Core.Repository;
using ZdtbSite.Model;
using System.Data.Entity;
using ZdtbSite.Web.Models;

namespace ZdtbSite.Web.ActionFilters
{
    public class ClientVisitAttribute : ActionFilterAttribute
    {
        public IRepository<VisitLog> VisitLogRepository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var log = new VisitLog();
            log.IpAddress = filterContext.HttpContext.Request.UserHostAddress;
            log.VisitDateTime = DateTime.Now;
            var objId = filterContext.Controller.ControllerContext.RouteData.Values["Id"];
            if (objId != null)
            {
                int id = Convert.ToInt32(objId);
                log.ProductId = id;
            }
            VisitLogRepository.Add(log);
            UnitOfWork.Commit();

            Tuple<HttpContext, VisitLog> context = new Tuple<HttpContext, VisitLog>(filterContext.HttpContext.ApplicationInstance.Context, log);
            Thread thread = new Thread(ThreadStart);
            thread.IsBackground = false;
            thread.Start(context);
        }

        private void ThreadStart(object obj)
        {
            var context = (Tuple<HttpContext, VisitLog>)obj;
            string url = string.Concat("http://apistore.baidu.com/microservice/iplookup?ip=", context.Item2.IpAddress);
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse response = null;
            Stream stream = null;
            StreamReader sr = null;
            var datacontext = new DbContextFactory().DataContext;
            try
            {
                response = webRequest.GetResponse();
                stream = response.GetResponseStream();
                sr = new StreamReader(stream);
                var result = sr.ReadToEnd();

                var model = datacontext.VisitLogs.Find(context.Item2.Id);
                model.Message = result;

                var iplook = Newtonsoft.Json.JsonConvert.DeserializeObject<IplookupViewModel>(result);
                model.Area = iplook.RetData.Area;
                model.District = iplook.RetData.District;
                model.City = iplook.RetData.City;
                model.Province = iplook.RetData.Province;
                model.Country = iplook.RetData.Country;

                datacontext.Entry<VisitLog>(model).State = EntityState.Modified;
                datacontext.SaveChanges();
            }
            catch (Exception e)
            {
                Elmah.ErrorSignal.FromContext(context.Item1).Raise(e);
            }
            finally
            {
                if (datacontext != null)
                    datacontext.Dispose();
                if (response != null)
                    response.Close();
                if (stream != null)
                    stream.Close();
                if (sr != null)
                    sr.Close();
            }
        }
    }
}