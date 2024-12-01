using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentShared.ViewModels.Payment
{
    public class PaymentPenaltyModel
    {
        public int IdBill { get; set; }
        public int IdPenalty { get;set; }
        public decimal BillOverDue { get; set; }
        public int DayLate { get;set;}
        public decimal AmountPenalty { get; set; }
    }
}
