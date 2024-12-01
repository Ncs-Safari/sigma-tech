using Microsoft.AspNetCore.Mvc;
using PaymentShared.Interfaces;
using PaymentShared.ViewModels;
using PaymentShared.ViewModels.Payment;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Payment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private IPayment _payment;
        public PaymentController(ILogger<PaymentController> logger, IPayment payment)
        {
            _logger = logger;
            _payment = payment;
        }

        [HttpGet(Name = "GetPaymentList")]
        public ResponseModel<List<PaymentModel>> GetListPayment()
        {

            var ret = _payment.GetListPayment(out string oMessage);
            return new ResponseModel<List<PaymentModel>>
            {
                IsSuccess = (string.IsNullOrEmpty(oMessage)) ? true : false,
                Data = ret,
                Message = oMessage
            };

        }

       

        [HttpPost(Name = "AddPayment")]
        public ResponseModel<string> AddPayment(decimal PaymentAllocated)
        {
            var addPayment = _payment.AddPayment(PaymentAllocated);

            return new ResponseModel<string>
            {
                IsSuccess = (string.IsNullOrEmpty(addPayment)) ? true : false,
                Data = null,
                Message = addPayment
            };

        }

    }
}
