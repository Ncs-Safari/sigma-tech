using Dapper;
using PaymentEntities.Payments;
using PaymentShared;
using PaymentShared.Interfaces;
using PaymentShared.ViewModels.Payment;
using System.Data;
using System.Data.Common;

namespace Payment.Services
{
    public class PaymentService : IPayment
    {
        private readonly string ServiceName = "Payment.Service.PaymentService";
        private readonly Common common = new Common();
        public string AddPayment(decimal PaymentAllocated)
        {
            try
            {
                string message = string.Empty;
                if (PaymentAllocated < 0)
                {
                    message = "Payment less 0 ";
                    return message;
                }

                using (IDbConnection conn = common.DBConnection)
                {
                    conn.Open();
                    var paymentList = conn.GetList<TbPayment>().OrderBy(t => t.DueDate).ToList();

                    foreach (var payment in paymentList)
                    {
                        if (payment.Amount >= payment.PaymentAllocated)
                        {
                            if (PaymentAllocated >= payment.Amount)
                            {
                                payment.PaymentAllocated = payment.Amount;
                                PaymentAllocated -= payment.Amount;

                                var paymentAllocation = new TbPayment
                                {
                                    Id = payment.Id,
                                    DueDate = payment.DueDate,
                                    Amount = payment.Amount,
                                    PaymentAllocated = payment.Amount,
                                    UpdatedOn = DateTime.Now
                                };

                                conn.Update(paymentAllocation);

                            }
                            else
                            {
                                payment.PaymentAllocated = PaymentAllocated;

                                // Insert Payment Allocation
                                var paymentAllocation = new TbPayment
                                {
                                    Id = payment.Id,
                                    DueDate = payment.DueDate,
                                    Amount = payment.Amount,
                                    PaymentAllocated = PaymentAllocated,
                                    UpdatedOn = DateTime.Now
                                };

                                conn.Update(paymentAllocation);

                                break; 
                            }
                        }
                    }
                    return message;

                }

            }
            catch (Exception ex)
            {
                return common.GetErrorMessage(ServiceName + "AddPayment", ex);
            }
        }

        public List<PaymentModel> GetListPayment(out string oMessage)
        {
            try
            {
                oMessage = string.Empty;
                using (IDbConnection conn = common.DBConnection)
                {
                    conn.Open();
                    return (from a in conn.GetList<TbPayment>()
                            select new PaymentModel
                            {
                                Id = a.Id,
                                DueDate = a.DueDate.ToShortDateString(),
                                Amount = a.Amount
                            }).OrderBy(x => x.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                oMessage = common.GetErrorMessage(ServiceName + "GetListPayment", ex);
                return null;
            }
        }

        public List<PaymentPenaltyModel> GetPenaltyPayment(out string oMessage)
        {
            try
            {
                var today = new DateTime(2023, 04, 29);
                oMessage = string.Empty;
                using (IDbConnection conn = common.DBConnection)
                {
                    conn.Open();

                    var payments = conn.GetList<TbPayment>().ToList();
                    var invoices = conn.GetList<TBPaymentInvoice>().ToList();

                    var penaltyResults = CalculatePenalty(invoices, payments, today);


                    return penaltyResults;


                }
            }
            catch (Exception ex)
            {
                oMessage = common.GetErrorMessage(ServiceName + "GetPenaltyPayment", ex);
                return null;
            }
        }

        private List<PaymentPenaltyModel> CalculatePenalty(List<TBPaymentInvoice> tagihanList, List<TbPayment> pembayaranList, DateTime today)
        {
            var results = new List<PaymentPenaltyModel>();

            // Proses setiap tagihan
            foreach (var tagihan in tagihanList)
            {
                // Ambil daftar pembayaran untuk tagihan ini
                var paymentsForTagihan = pembayaranList.Where(p => p.Id == tagihan.PaymentId).ToList();

                decimal totalPaid = paymentsForTagihan.Sum(p => p.PaymentAllocated); 
                decimal remainingAmount = tagihan.PmtAmount - totalPaid; 

                if (remainingAmount > 0)
                {
                   
                    DateTime lastPaymentDate = paymentsForTagihan.Any() ? paymentsForTagihan.Max(p => p.DueDate) : tagihan.PmtDate;

                    
                    int overdueDays = (today - lastPaymentDate).Days;
                    if (overdueDays < 0) overdueDays = 0; // Pastikan tidak ada nilai negatif

                    
                    decimal penaltyAmount = remainingAmount * 2m / 1000m * overdueDays;

                    results.Add(new PaymentPenaltyModel
                    {
                        IdPenalty = tagihan.Id, 
                        IdBill = tagihan.PaymentId, 
                        BillOverDue = remainingAmount, 
                        DayLate = overdueDays, 
                        AmountPenalty = penaltyAmount 
                    });
                }
            }

            return results;
        }
    }
}
