﻿using System.Text.Json.Serialization;

namespace CV_Blazor.Models
{
    public class PortfolioViewModel
    {
        public Resume Resume { get; set; } = new();
        public List<Project> Projects { get; set; } = new();
        public List<Project> Jams { get; set; } = new();
    }
}