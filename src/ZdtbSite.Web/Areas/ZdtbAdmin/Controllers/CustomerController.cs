using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class CustomerController : BaseController
    {
        private string CurrentUrl
        {
            get
            {
                return Url.Action("Index", "Customer");
            }
        }
        private readonly IRepository<Customer> customerRepository;
        private IUnitOfWork unitOfWork;
        public CustomerController(IRepository<Customer> customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        // GET: ZdtbAdmin/Customer
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<Customer> pageList = customerRepository.GetPage(page, e => true, e => e.Id);
            return View(pageList);
        }

        [HttpGet]
        public ActionResult Modify(int id)
        {
            Customer customer = customerRepository.GetById(id);
            Admin.CustomerViewModel customerViewModel = AutoMapper.Mapper.Map<Customer, Admin.CustomerViewModel>(customer);
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Modify(Admin.CustomerViewModel viewModel)
        {
            //Admin.CustomerViewModel customerViewModel = AutoMapper.Mapper.Map<Customer, Admin.CustomerViewModel>(customer);
            Customer customer = AutoMapper.Mapper.Map<Admin.CustomerViewModel, Customer>(viewModel);
            customer.CreateTime = DateTime.Now;
            customerRepository.Update(customer);
            unitOfWork.Commit();
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            responseModel.Success = true;
            responseModel.Msg = "成功修改客户信息，页面即将跳转";
            responseModel.RedirectUrl = CurrentUrl;
            return Json(responseModel, JsonRequestBehavior.AllowGet);
        }
    }
}