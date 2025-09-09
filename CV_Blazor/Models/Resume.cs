namespace CV_Blazor.Models
{
    public class Resume
    {
        public List<Experience> ProfessionalExperience { get; set; } = new();
        public List<Education> Education { get; set; } = new();
        public List<Skill> Skills { get; set; } = new();
        public List<string> Summary { get; set; } = new();
    }

    public class Experience
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string Period { get; set; }
        public List<string> Achievements { get; set; } = new();
    }

    public class Education
    {
        public string Title { get; set; }
        public string Institution { get; set; }
        public string Period { get; set; }
    }

    public class Skill
    {
        public string Name { get; set; }
        public List<string> Details { get; set; } = new();
    }
}
