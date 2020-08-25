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
    public class MyGitHubLibraryController : ControllerBase
    {
        private readonly IMyGitHubLibraryService _myGitHubLibraryService;
        public MyGitHubLibraryController(IMyGitHubLibraryService myGitHubLibraryService)
        {
            _myGitHubLibraryService = myGitHubLibraryService;
        }
        [HttpGet]
        public List<Tag> GetTags()
        {
            return _myGitHubLibraryService.GetTag();
        }

        [HttpGet("{id}")]
        public Tag GetTagId(int id)
        {
            return _myGitHubLibraryService.GetTagId(id);
        }

        [HttpPost]
        public void PostTag([FromBody] Tag NameTag)
        {
            _myGitHubLibraryService.InsertTag(NameTag);
        }

        [HttpPut("{id}")]
        public void PutTag(int id, [FromBody] Tag NameTag)
        {
            _myGitHubLibraryService.UpdateTag(NameTag);
        }

        [HttpDelete("{id}")]
        public void DeleteTag(int id)
        {
            _myGitHubLibraryService.DeleteTag(id);
        }

    }
}
