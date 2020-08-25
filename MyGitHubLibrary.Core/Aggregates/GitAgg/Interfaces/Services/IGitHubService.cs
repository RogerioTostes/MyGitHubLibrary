using MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Services
{
   public interface IGitHubService
    {
        bool SearchUserError { get; }
        string SearchUserErrorMessage { get; }
        IEnumerable<GitHub> Starred { get; }
        Task<IEnumerable<GitHub>> SearchUser(Filter request);
        Task<IEnumerable<GitHub>> Search(string queryParams);
    }
}
