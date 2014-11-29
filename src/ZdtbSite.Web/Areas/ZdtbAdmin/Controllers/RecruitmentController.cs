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
    public class RecruitmentController : Controller
    {
        private readonly IRepository<Recruitment> RecruitmentRepository;
        private IUnitOfWork unitOfWork;
        private string CurrentUrl { get { return Url.Action("Index", "Recruitment"); } }
        public RecruitmentController(IRepository<Recruitment> RecruitmentRepository, IUnitOfWork unitOfWork)
        {
            this.RecruitmentRepository = RecruitmentRepository;
            this.unitOfWork = unitOfWork;
        }
        // GET: ZdtbAdmin/Recruitment
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<Recruitment> pageList = RecruitmentRepository.GetPage(page, e => true, e => e.Id);
            return View(pageList);
        }
    }
}