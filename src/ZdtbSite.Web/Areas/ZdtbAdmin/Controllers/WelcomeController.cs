using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class WelcomeController : BaseController
    {
        private readonly IRepository<Article> articleRepository = null;
        private readonly IRepository<Contract> ContractRepository;
        private readonly IRepository<Recruitment> RecruitmentRepository;
        private readonly IRepository<Feedback> FeedbackRepository;
        private readonly IRepository<VisitLog> visitLogRepository;
        private readonly IRepository<Customer> customerRepository;
        public WelcomeController(
            IRepository<Article> articleRepository,
            IRepository<Contract> ContractRepository,
            IRepository<Recruitment> RecruitmentRepository,
            IRepository<Feedback> FeedbackRepository,
            IRepository<VisitLog> visitLogRepository,
            IRepository<Customer> customerRepository)
        {
            this.articleRepository = articleRepository;
            this.ContractRepository = ContractRepository;
            this.RecruitmentRepository = RecruitmentRepository;
            this.FeedbackRepository = FeedbackRepository;
            this.visitLogRepository = visitLogRepository;
            this.customerRepository = customerRepository;
        }
        // GET: ZdtbAdmin/Home
        public ActionResult Index()
        {
            Models.WelcomeViewModel model = new Models.WelcomeViewModel();
            DateTime start = DateTime.Now.Date;
            DateTime end = DateTime.Now.AddDays(1).Date;
            model.NewCustomer = customerRepository.GetMany(e => e.CreateTime >= start && e.CreateTime < end).Count();
            model.ArticleCount = articleRepository.GetMany(e => e.UpdateDateTime >= start && e.UpdateDateTime < end && e.OriginArticlesType == OriginArticlesType.Web).Count();
            model.ContractCount = ContractRepository.GetMany(e => e.CreateTime >= start && e.CreateTime < end).Count();
            model.Feedbacks = FeedbackRepository.GetMany(
                    e => e.CreateTime >= start
                    && e.CreateTime < end
                    && e.FeedbackType == FeedbackType.Message)
                    .OrderByDescending(e => e.CreateTime)
                    .Take(3).ToList();
            model.Feedbacks.AddRange(FeedbackRepository.GetMany(
                    e => e.CreateTime >= start
                    && e.CreateTime < end
                    && e.FeedbackType == FeedbackType.Question)
                    .OrderByDescending(e => e.CreateTime)
                    .Take(3).ToList());
            model.FeedbackCount = model.Feedbacks.Count();
            model.RecruitmentCount = RecruitmentRepository.GetAll().Count();
            model.VisitLogCount = visitLogRepository.GetMany(e => e.VisitDateTime >= start && e.VisitDateTime < end).Count();
            return View(model);
        }
    }
}