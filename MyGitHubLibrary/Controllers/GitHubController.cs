﻿using Microsoft.AspNetCore.Mvc;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Repositories;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGitHubLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private IGitHubService _gitHubClient { get; }


        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubClient = gitHubService;

        }
        [HttpGet("/Filter/Starred")]
        public async Task<ActionResult<IEnumerable<object>>> GetStarred([FromQuery] Filter request)
        {
            try
            {
                await _gitHubClient.SearchUser(request);

                if (!_gitHubClient.SearchUserError)
                    return Ok(_gitHubClient.Starred);
                else
                    return BadRequest($"Error {_gitHubClient.SearchUserErrorMessage}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error");
            }
        }
    }
}
