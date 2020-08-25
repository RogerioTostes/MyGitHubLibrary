using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities
{
    public class Filter
    {
        [FromQuery(Name = "user")]
        [Required]
        public string NameUser { get; set; }
    }
}
