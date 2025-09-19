using System.Net.Http.Json;
using System.Text.Json;
using System.Globalization;
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
            var culture = CultureInfo.CurrentUICulture.Name;
            var jsonFile = culture switch
            {
                "es-ES" => "data/portfolio-es-ES.json",
                "en-US" => "data/portfolio-en-US.json",
                _ => "data/portfolio-en-US.json" // fallback
            };

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = await _http.GetFromJsonAsync<PortfolioViewModel>(jsonFile, options);
            return data ?? new PortfolioViewModel();
        }
    }
}