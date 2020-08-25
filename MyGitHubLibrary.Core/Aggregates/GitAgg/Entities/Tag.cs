using System;
using System.Collections.Generic;
using System.Text;

namespace MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities
{
    public class Tag
    {
        public string NameTag { get; set; }
        public int Id { get; set; }
        public int IdRepo { get; set; }
    }
}
