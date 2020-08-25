using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Repositories;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Services;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Service;
using MyGitHubLibrary.Domain.SharedKernel.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGitHubLibrary.Configuration
{
    public static class ServiceCollections
    {
        public static IServiceCollection ConfigureHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<IGitHubService, GitHubService>(c =>
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
