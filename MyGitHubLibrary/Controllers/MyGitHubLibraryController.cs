using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyGitHubLibrary.Models;
using MyGitHubLibrary.Repository;

namespace MyGitHubLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyGitHubLibraryController : ControllerBase
    {
        [HttpGet]
        public List<Tag> GetTags([FromServices] IConfiguration conf)
        {
            return new MyGitHubLibraryRepository(conf).GetTag();
        }

        [HttpGet("{id}")]
        public Tag GetTagId(int id, [FromServices] IConfiguration conf)
        {
            return new MyGitHubLibraryRepository(conf).GetTagId(id);
        }

        [HttpPost]
        public void PostTag([FromBody] Tag NameTag, [FromServices] IConfiguration conf)
        {
            new MyGitHubLibraryRepository(conf).InsertTag(NameTag);
        }

        [HttpPut("{id}")]
        public void PutTag(int id, [FromBody] Tag NameTag, [FromServices] IConfiguration conf)
        {
            NameTag.Id = id;
            new MyGitHubLibraryRepository(conf).UpdateTag(NameTag);
        }

        [HttpDelete("{id}")]
        public void DeleteTag(int id, [FromServices] IConfiguration conf)
        {
            new MyGitHubLibraryRepository(conf).DeleteTag(id);
        }

    }
}
