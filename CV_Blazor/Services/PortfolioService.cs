using System.Net.Http.Json;
using System.Text.Json;
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
            // Genera un timestamp para asegurar una URL única en cada solicitud.
            string cacheBuster = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            string jsonUrl = $"data/portfolio.json?v={cacheBuster}";

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Usa la URL con el parámetro de consulta para evitar la caché.
            var data = await _http.GetFromJsonAsync<PortfolioViewModel>(jsonUrl, options);
            return data ?? new PortfolioViewModel();
        }
    }
}