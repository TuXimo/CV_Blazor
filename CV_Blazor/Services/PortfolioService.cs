using CV_Blazor.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace CV_Blazor.Services
{
    public class PortfolioService
    {
        private readonly HttpClient _http;

        public PortfolioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<PortfolioViewModel> GetPortfolioAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = await _http.GetFromJsonAsync<PortfolioViewModel>("data/portfolio.json", options);

            return data ?? new PortfolioViewModel();
        }
    }
}
