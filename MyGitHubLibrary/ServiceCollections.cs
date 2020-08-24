using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyGitHubLibrary.Interface;
using MyGitHubLibrary.Repository;
using MyGitHubLibrary.Util;
using System;

namespace MyGitHubLibrary
{
    public static class ServiceCollections
    {
        public static IServiceCollection ConfigureHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<IGitHub, GitHubRepository>(c =>
            {
                c.BaseAddress = new Uri(GitHubConfig.GitHubDomain);

                c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.UserAgent.TryParseAdd("GitHubApi-SampleRequest");
            });
            return services;
        }


        public static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            return services;
        }
    }
}
