using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Repositories;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Services;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Service;
using System.Collections.Generic;

namespace MyGitHubLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _TagService;
        public TagController(ITagService TagService)
        {
            _TagService = TagService;
        }
        [HttpGet]
        public List<Tag> GetTags()
        {
            return _TagService.GetTag();
        }

        [HttpGet("{id}")]
        public Tag GetTagId(int id)
        {
            return _TagService.GetTagId(id);
        }

        [HttpPost]
        public void PostTag([FromBody] Tag NameTag)
        {
            _TagService.InsertTag(NameTag);
        }

        [HttpPut("{id}")]
        public void PutTag(int id, [FromBody] Tag NameTag)
        {
            _TagService.UpdateTag(NameTag);
        }

        [HttpDelete("{id}")]
        public void DeleteTag(int id)
        {
            _TagService.DeleteTag(id);
        }

    }
}
