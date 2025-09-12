using System.Text.Json.Serialization;

namespace CV_Blazor.Models
{
    public class PortfolioViewModel
    {
        [JsonPropertyName("resume")]
        public Resume Resume { get; set; }

        [JsonPropertyName("projects")]
        public List<Project> Projects { get; set; } = new();

        [JsonPropertyName("jams")]
        public List<Project> Jams { get; set; } = new();
    }
}