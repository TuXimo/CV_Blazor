namespace CV_Blazor.Models
{
    public class Resume
    {
        public List<Experience> ProfessionalExperience { get; set; } = new();
        public List<Education> Education { get; set; } = new();
        public List<string> SummaryKeys { get; set; } = new();
    }

    public class Experience
    {
        public string Slug { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public List<string> AchievementKeys { get; set; } = new();
    }

    public class Education
    {
        public string Slug { get; set; } = string.Empty;
        public string Institution { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public string DescriptionKey { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
