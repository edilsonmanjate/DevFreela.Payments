using DevFreela.Payments.API.Models;

using System.Text;
using System.Text.Json;

namespace DevFreela.Payments.API.Services
{
    public class PaymentService : IPaymentService
    {
        public IHttpClientFactory _httpClientFactory;
        private readonly string _configuration;

        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration.GetSection("Services:Payments").Value;
        }
        public async Task<bool> ProcessPaymentAsync(PaymentInputModel paymentInputModel)
        {
            var url = $"{_configuration}/api/payments";


            var paymentInfoJson = JsonSerializer.Serialize(paymentInputModel);

            var paymentInfoContent = new StringContent(
                paymentInfoJson, 
                Encoding.UTF8, 
                "application/json"
                );

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.PostAsync(url, paymentInfoContent);
            
            return response.IsSuccessStatusCode;
        }
    }
}
