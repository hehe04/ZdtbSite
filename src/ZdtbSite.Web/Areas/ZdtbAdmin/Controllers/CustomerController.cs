using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class CustomerController : BaseController
    {
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
    }
}