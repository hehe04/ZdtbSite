using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Model
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [StringLength(1024)]
        public string Content { get; set; }

        public FeedbackType FeedbackType { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

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
