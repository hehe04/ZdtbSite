using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long Number { get; set; }

        [StringLength(32)]
        public string IPAddress { get; set; }

        public DateTime CreateTime { get; set; }

        public int Count { get; set; }

        [StringLength(32)]
        public string Email { get; set; }
        [StringLength(32)]
        public string Phone { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactsName { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public virtual ICollection<Contract> Contracts { get; set; }

        public Customer()
        {
            CreateTime = DateTime.Now;
        }
    }
}
