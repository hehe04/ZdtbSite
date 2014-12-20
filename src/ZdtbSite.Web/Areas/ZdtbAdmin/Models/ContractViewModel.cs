using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class ContractViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        public virtual CustomerViewModel Customer { get; set; }

        public int CustomerId { get; set; }

        public decimal Prepayments { get; set; }

        public ContractStatus Status { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime SignedTime { get; set; }

        public bool IsSuccess { get; set; }
    }
    public enum ContractStatus
    {
        NotSigned,
        Signed
    }

   
}