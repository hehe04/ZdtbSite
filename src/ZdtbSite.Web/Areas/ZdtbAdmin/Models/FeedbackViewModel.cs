using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class FeedbackViewModel
    {

        public int Id { get; set; }

        [StringLength(1024)]
        public string Content { get; set; }

        public FeedbackType FeedbackType { get; set; }

        public virtual CustomerViewModel Customer { get; set; }

        public int CustomerId { get; set; }

        [StringLength(32)]
        public string Mobile { get; set; }

        public DateTime CreateTime { get; set; }
    }
    public enum FeedbackType
    {
        Question = 1,
        Message = 2
    }
}