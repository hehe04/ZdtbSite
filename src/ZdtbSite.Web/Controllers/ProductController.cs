using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult ProductList(string catelog, string keywords, int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<Product> pageList = _productRepository.GetPage(page, e => true, e => e.Id);
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
    }
}