using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace MyGitHubLibrary.Models
{
    public class Filter
    {
        [FromQuery(Name = "user")]
        [Required]
        public string NameUser { get; set; }        
    }
}
