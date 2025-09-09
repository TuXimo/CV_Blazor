using System.Net.Http.Json;
using CV_Blazor.Models;

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
            var data = await _http.GetFromJsonAsync<PortfolioViewModel>("data/portfolio.json");
            return data ?? new PortfolioViewModel();
        }
    }
}
