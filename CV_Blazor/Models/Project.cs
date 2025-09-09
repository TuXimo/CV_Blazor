namespace CV_Blazor.Models
{
    public class Project
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string MainImage { get; set; }
        public List<string> SecondaryImages { get; set; } = new();
        public string ProjectLink { get; set; }
        public string GithubLink { get; set; }
    }
}
