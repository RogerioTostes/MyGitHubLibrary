using System;
using System.Collections.Generic;
using System.Text;

namespace MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities
{
    public class GitHub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html_Url { get; set; }
        public string Language { get; set; }
        public string NameUser { get; set; }
    }
}
