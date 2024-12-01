using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentShared.ViewModels.Payment
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public string DueDate { get; set; }
        public decimal Amount { get; set; }
        public decimal? PaymentAlocated { get; set; }
    }
}
