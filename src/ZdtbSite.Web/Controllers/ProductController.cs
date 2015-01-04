using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Helper;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using ZdtbSite.Web.ActionFilters;

namespace ZdtbSite.Web.Controllers
{
    public class ProductController : BaseController
    {
        private IRepository<Product> _productRepository;
        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductList(int? catelog, string keywords, int pageIndex = 1, int pageSize = 2)
        {
            Page page = new Page(pageIndex, pageSize);
            
            //暂时支持2级查询，如果产品类型有更多级，再使用递归重构
            IPagedList<Product> pageList = _productRepository.GetPage(page, e => e.ProductTypeId == catelog || e.ProductType.ParentId == catelog, e => e.Id);
            return View(pageList);
        }

        [ClientVisit]
        public ActionResult ProductDetail(int id)
        {
            var model = _productRepository.GetById(id);
            HttpCookie cookie = new HttpCookie("RecommendProductType");
            cookie.Value = model.ProductTypeId.ToString();
            cookie.Expires = DateTime.Now.AddDays(7);
            ControllerContext.HttpContext.Response.SetCookie(cookie);
            var viewModel = Mapper.Map<Product, ZdtbSite.Web.Models.ProductViewModel>(model);

            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            return View(viewModel);
        }

        public ActionResult DownPdf(string htmlUrl)
        {
            string url = HtmlToFileHelper.HtmlToPDF(htmlUrl);
            string fileName = "ProductInfo" + DateTime.Now.ToString("MM/dd/yyyy") + ".pdf";
            return File(new FileStream(url, FileMode.Open), "application/octet-stream", Server.UrlEncode(fileName));
        }
    }
}