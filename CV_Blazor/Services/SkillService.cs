using CV_Blazor.Models;
using System.Globalization;
using System.Net.Http.Json;

namespace CV_Blazor.Services
{
    public class SkillService
    {
        private readonly HttpClient _http;

        public SkillService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Skill>> GetSkillsAsync()
        {
            var culture = CultureInfo.CurrentUICulture.Name;
            var jsonFile = culture switch
            {
                "es-ES" => "data/skills-es-ES.json",
                "en-US" => "data/skills-en-US.json",
                _ => "data/skills-en-US.json" // fallback
            };

#pragma warning disable CS8603 // Possible null reference return.
            return await _http.GetFromJsonAsync<List<Skill>>(jsonFile);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
