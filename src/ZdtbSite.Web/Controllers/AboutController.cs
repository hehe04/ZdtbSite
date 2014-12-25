using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Helper;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using ZdtbSite.Web.ActionFilters;
using ZdtbSite.Web.Models;

namespace ZdtbSite.Web.Controllers
{
    public class AboutController : BaseController
    {
        private IRepository<Product> _productRepository;
        private IRepository<ContentType> _contentType;
        private IRepository<Customer> _customerRepository;
        private IUnitOfWork _unitOfWork;

        public AboutController(IRepository<Product> productRepository, IRepository<ContentType> contentType, IRepository<Customer> customerRepository
            , IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _contentType = contentType;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TechnologySupportIndex(string catelog, int pageIndex = 1, int pageSize = 2)
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            ViewBag.ContentType = _contentType.GetManyAsNoTracking(x => x.PrentId == 1);
            ViewBag.ActionName = "TechnologySupportIndex";
            return View();
        }

        public ActionResult TechnologySupportDetail()
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            ViewBag.ContentTypes = _contentType.GetManyAsNoTracking(x => x.PrentId == 1);
            ViewBag.ActionName = "TechnologySupportIndex";
            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            return View();
        }

        //[ClientVisit]
        [HttpPost]
        public ActionResult ContactUs(MessageViewModel model)
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            if (!ModelState.IsValid) return ReturnView();

            var feedbacks = new List<Feedback>()
            {
                new Feedback()
                {
                   Content=model.Message,
                   FeedbackType=FeedbackType.Message,
                   Mobile=model.PhoneNo
               
                } 
           };
            var customer = _customerRepository.Get(x => x.IPAddress.Trim().Equals(Request.UserHostAddress) || x.Email.Trim().Equals(model.Email));
            bool flag = false;
            if (customer == null)
            {
                customer = new Customer();
                flag = true;
            }
            customer.ContactsName = model.Name;
            customer.Phone = model.PhoneNo;
            customer.Email = model.Email;
            customer.Feedbacks = feedbacks;
            customer.IPAddress = Request.UserHostAddress;
            customer.Count = customer.Count + 1;

            if (flag)
            {
                _customerRepository.Add(customer);
            }
            else
            {
                _customerRepository.Update(customer);
            }

            _unitOfWork.Commit();

            string content = string.Format("客户{0}说:‘{1}’。他的联系方式如下，快点联系他吧~~~\r\n Phone:{2} \r\n Email:{3}"
                , model.Name, model.Message, string.IsNullOrEmpty(model.PhoneNo) ? "无" : model.PhoneNo, model.Email);
            EmailHelper.SendEmail("Minnan Web System", "新的客户留言", content);

            return ReturnView();
        }

        private ActionResult ReturnView()
        {
            if (Request.IsAjaxRequest())
            {
                return Json("ok");
            }
            return View();
        }
    }
}