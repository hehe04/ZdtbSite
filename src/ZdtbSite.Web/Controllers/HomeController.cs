using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Controllers
{
    public class HomeController : Controller
    {
        DataContext repository;

        public HomeController()
        {
            repository = new DataContext();
        }

        // GET: Home
        public ActionResult Index()
        {
            ProductType productType = new ProductType()
            {
                TypeName = "变压器",
                Products = new List<Product>() 
                { 
                    new Product()
                    {
                        Name = "高压开关柜1",
                        Description = "宇宙第一开关柜"
                    },
                    new Product()
                    {
                        Name = "高压开关柜2",
                        Description = "宇宙第一开关柜"
                    }

                }
            };
            repository.ProductTypes.Add(productType);
            repository.SaveChanges();            
            return View();
        }
    }
}