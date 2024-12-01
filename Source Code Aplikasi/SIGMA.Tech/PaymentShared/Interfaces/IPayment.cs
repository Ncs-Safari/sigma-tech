using PaymentShared.ViewModels.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentShared.Interfaces
{
    public interface IPayment
    {
        List<PaymentModel> GetListPayment(out string oMessage);
        string AddPayment(Decimal PaymentAllocated);

        List<PaymentPenaltyModel> GetPenaltyPayment(out string oMessage);
    }
}
