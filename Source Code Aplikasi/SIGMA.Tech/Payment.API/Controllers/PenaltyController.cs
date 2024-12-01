
using Microsoft.AspNetCore.Mvc;
using PaymentShared.Interfaces;
using PaymentShared.ViewModels.Payment;
using PaymentShared.ViewModels;

namespace Payment.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PenaltyController : ControllerBase
    {

        private readonly ILogger<PenaltyController> _logger;
        private IPayment _payment;

        public PenaltyController(ILogger<PenaltyController> logger, IPayment payment)
        {
            _logger = logger;
            _payment = payment;
        }

        [HttpGet(Name = "GetPenalty")]
        public ResponseModel<List<PaymentPenaltyModel>> GetPenalty()
        {

            var ret = _payment.GetPenaltyPayment(out string oMessage);
            return new ResponseModel<List<PaymentPenaltyModel>>
            {
                IsSuccess = (string.IsNullOrEmpty(oMessage)) ? true : false,
                Data = ret,
                Message = oMessage
            };

        }

    }
}
