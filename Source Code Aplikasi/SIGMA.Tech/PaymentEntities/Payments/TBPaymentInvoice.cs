using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentEntities.Payments
{
    [Table("TBPaymentInvoice")]
    public class TBPaymentInvoice
    {
        [Key, Required]
        [Column("id")]
        public int Id { get; set; }

        [Column("payment_id")]
        public int PaymentId { get; set; }

        [Column("pmt_date")]
        public DateTime PmtDate { get; set; }

        [Column("pmt_amount")]
        public decimal PmtAmount { get; set; }

    }
}
