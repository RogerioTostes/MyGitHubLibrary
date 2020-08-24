using MyGitHubLibrary.Interface;
using MyGitHubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MyGitHubLibrary.Util;
using Newtonsoft.Json;

namespace MyGitHubLibrary.Repository
{
    public class GitHubRepository : IGitHub
    {
        private HttpClient _httpClient { get; }        
        public IEnumerable<GitHub> Starred { get; private set; }
        public bool SearchUserError { get; private set; }
        public string SearchUserErrorMessage { get; private set; }
        public GitHubRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }        
     
        public async Task<IEnumerable<GitHub>> SearchUser(Filter request)
        {
            var searchQry = GitHubConfig.GitHubDomain + GitHubConfig.SearchUser + request.NameUser + GitHubConfig.Starred;

            return await Search(searchQry);
        }

        public async Task<IEnumerable<GitHub>> Search(string queryParams)
        {
            SearchUserError = false;
            SearchUserErrorMessage = string.Empty;
            try
            {             

                var result = await _httpClient.GetAsync(queryParams);
                await ProcessResponse(result, queryParams);
            }
            catch (Exception ex)
            {
                SearchUserError = true;
                SearchUserErrorMessage = "Error Search";
                Starred = default;
              
            }

            return Starred;
        }
        public async Task<string> GetStrFromJson(string url)
        {
            var rawJson = string.Empty;
            using (var client = new WebClient())
            {
                try
                {
                    client.Headers[HttpRequestHeader.UserAgent] =
                       "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                    rawJson = client.DownloadString(url);
                }
                catch (Exception) { }
            }
            return rawJson;
        }
        private async Task ProcessResponse(HttpResponseMessage response, string queryParams)
        {
            if (response.IsSuccessStatusCode)
            {

                var result = await GetStrFromJson(queryParams);
                var myRepos = JsonConvert.DeserializeObject<List<GitHub>>(result);
                Starred = (IEnumerable<GitHub>)myRepos;
            }
            else
            {              
                switch (response.StatusCode)
                {
                    case HttpStatusCode.UnprocessableEntity:
                        SearchUserErrorMessage = "Invalid search user";
                        break;
                    default:
                        SearchUserErrorMessage = "Not success status";
                        break;
                }
                SearchUserError = true;
                Starred = default;               
            }
        }             
    }
}
