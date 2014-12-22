using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Model
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

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
