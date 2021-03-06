﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
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
            return View();
        }

        public ActionResult TechnologySupportDetail()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(MessageViewModel model)
        {
            ViewBag.ProductRecommendList = GetProductRecommendList(_productRepository);
            if (!ModelState.IsValid) return View();

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

            return View();
        }
    }
}