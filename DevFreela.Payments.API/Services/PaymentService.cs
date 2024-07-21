using DevFreela.Payments.API.Models;

namespace DevFreela.Payments.API.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> ProcessPaymentAsync(PaymentInputModel paymentInputModel)
        {
            return Task.FromResult(true);
        }
    }
}
