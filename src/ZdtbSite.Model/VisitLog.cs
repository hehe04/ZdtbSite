using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Model
{
    public class VisitLog
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string IpAddress { get; set; }

        [StringLength(64)]
        public string VisitorName { get; set; }

        public bool IsSendToMail { get; set; }

        public bool IsSendToSms { get; set; }

        [StringLength(512)]
        public string MailTo { get; set; }

        [StringLength(512)]
        public string SmsTo { get; set; }

        [StringLength(256)]
        public string VisitorMail { get; set; }

        [StringLength(256)]
        public string VisitorPhone { get; set; }

        public string Message { get; set; }

        public int ProductId { get; set; }

        public virtual Product ExploreProducts { get; set; }

        public DateTime VisitDateTime { get; set; }

        public string Country { get; set; }

        public string Area { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public VisitLog()
        {
            VisitDateTime = DateTime.Now;
        }
    }
}
