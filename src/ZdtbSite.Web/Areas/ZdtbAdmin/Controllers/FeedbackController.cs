using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IRepository<Feedback> FeedbackRepository;
        private IUnitOfWork unitOfWork;

        public FeedbackController(IRepository<Feedback> FeedbackRepository, IUnitOfWork unitOfWork)
        {
            this.FeedbackRepository = FeedbackRepository;
            this.unitOfWork = unitOfWork;
        }

        // GET: ZdtbAdmin/Feedback
        [HttpGet]
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            Expression<Func<Feedback, bool>> where = e => true;
            string search = Request.Cookies["searchFeedbackType"] == null ? "-1" : Request.Cookies["searchFeedbackType"].Value;
            int status = -1;
            FeedbackType type;
            if (!Enum.TryParse<FeedbackType>(search, out type))
            {
                status = -1;
            }
            if (status != -1)
            {
                where = e => e.FeedbackType == type;
            }
            IPagedList<Feedback> pageList = FeedbackRepository.GetPage(page, where, e => e.Id);
            return View(pageList);
        }



        [HttpPost]
        public ActionResult Index(FeedbackType? FeedbackType)
        {
            Page page = new Page(1, 10);
            Expression<Func<Feedback, bool>> where = e => true;
            HttpCookie cookie = new HttpCookie("searchFeedbackType");
            cookie.Value = ((int)FeedbackType).ToString();
            Response.SetCookie(cookie);
            if (FeedbackType != null)
            {
                where = e => e.FeedbackType == FeedbackType.Value;
            }
            IPagedList<Feedback> pageList = FeedbackRepository.GetPage(page, where, e => e.Id);
            return View(pageList);
        }

        [HttpGet]
        public ActionResult Reply(int id)
        {
            var feedback = FeedbackRepository.GetById(id);
            Admin.FeedbackViewModel viewmodel = AutoMapper.Mapper.Map<Model.Feedback, Admin.FeedbackViewModel>(feedback);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Reply()
        {
            return View();
        }
    }
}