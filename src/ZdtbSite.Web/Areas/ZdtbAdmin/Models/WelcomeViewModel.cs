using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class WelcomeViewModel
    {
        public int NewCustomer { get; set; }

        public int ContractCount { get; set; }

        public int RecruitmentCount { get; set; }

        public int ArticleCount { get; set; }

        public int FeedbackCount { get; set; }

        public int VisitLogCount { get; set; }

        public List<Feedback> Feedbacks { get; set; }
    }
}