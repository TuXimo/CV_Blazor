namespace CV_Blazor.Models
{
    public class Project
    {
        public string Slug { get; set; } = string.Empty;
        public string MainImage { get; set; } = string.Empty;
        public List<string> SecondaryImages { get; set; } = new();
        public string ProjectLink { get; set; } = string.Empty;
        public string? GithubLink { get; set; }
        public List<string> Technologies { get; set; } = new();
    }
}
