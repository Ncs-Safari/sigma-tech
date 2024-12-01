using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentEntities.Payments
{
    [Table("TBPayment")]

    public class TbPayment
    {
        [Key, Required]
        [Column("id")]
        public int Id { get; set; }

        [Column("due_date")]
        public DateTime DueDate { get; set; }
        [Column("amount")]
        public Decimal Amount { get; set; }
        [Column("payment_allocated")]
        public decimal PaymentAllocated { get; set; }

        [Column("updated_on")]
        public DateTime UpdatedOn { get; set; }


    }
}
