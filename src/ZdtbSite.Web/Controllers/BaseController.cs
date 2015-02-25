using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Core.Repository;
using ZdtbSite.Model;
using ZdtbSite.Web.Areas.ZdtbAdmin.Models;
using ProductViewModel = ZdtbSite.Web.Models.ProductViewModel;

namespace ZdtbSite.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            ViewBag.SiteKeywords = GetSiteKeywords();
            View(actionName).ExecuteResult(ControllerContext);
        }

        /// <summary>
        /// 产品推荐列表
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> GetProductRecommendList(IRepository<Product> repository)
        {
            HttpCookie cookie = ControllerContext.HttpContext.Request.Cookies["RecommendProductType"];
            var productType = 1;
            if (cookie != null)
            {
                productType = int.Parse(cookie.Value);
            }
            var list = repository.GetManyAsNoTracking(x => x.ProductTypeId == productType).Take(3);
            return AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(list);
        }

        public BasicInfoViewModel GetSiteKeywords()
        {
            var repository = DependencyResolver.Current.GetService<IRepository<BasicInfo>>();
            var siteKeywords = repository.GetById(11);
            return AutoMapper.Mapper.Map<BasicInfo, BasicInfoViewModel>(siteKeywords);
        }

        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            ViewBag.SiteKeywords = GetSiteKeywords();
        }
    }
}