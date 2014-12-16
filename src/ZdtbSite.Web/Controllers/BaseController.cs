using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using ZdtbSite.Web.Models;

namespace ZdtbSite.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
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
            var list=repository.GetManyAsNoTracking(x => x.ProductTypeId == productType).Take(3);
            return AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(list);
        }
    }
}