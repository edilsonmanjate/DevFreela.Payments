using DevFreela.Payments.API.Models;
using DevFreela.Payments.API.Services;

using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Payments.API.Controllers
{
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentInputModel paymentInputModel)
        {
            var result = await _paymentService.ProcessPaymentAsync(paymentInputModel);

            if (!result) return BadRequest();
            
            return NoContent();
        }
    }
}
