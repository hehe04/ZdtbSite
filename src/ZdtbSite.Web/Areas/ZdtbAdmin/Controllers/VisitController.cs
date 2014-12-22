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
    public class VisitController : BaseController
    {
        private readonly IRepository<VisitLog> visitLogRepository;
        private IUnitOfWork unitOfWork;
        public VisitController(IRepository<VisitLog> visitLogRepository, IUnitOfWork unitOfWork)
        {
            this.visitLogRepository = visitLogRepository;
            this.unitOfWork = unitOfWork;
        }

        // GET: ZdtbAdmin/Visit
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<VisitLog> pageList = visitLogRepository.GetPage(page, e => true, e => e.Id);
            return View(pageList);
        }
    }
}