using AutoMapper;
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

        public ActionResult ProductList(string catelog, string keywords, int pageIndex = 1)
        {
            return View();
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
            return View(viewModel);
        }
    }
}