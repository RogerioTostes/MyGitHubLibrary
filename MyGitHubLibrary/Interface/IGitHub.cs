using MyGitHubLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyGitHubLibrary.Interface
{
    public interface IGitHub
    {
        bool SearchUserError { get; }
        string SearchUserErrorMessage { get; }
        IEnumerable<GitHub> Starred { get; }
        Task<IEnumerable<GitHub>> SearchUser(Filter request);
        Task<IEnumerable<GitHub>> Search(string queryParams);
    }
}
