using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Repositories;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Services;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Service;
using MyGitHubLibrary.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGitHubLibrary.CrossCutting
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMyGitHubLibraryService, MyGitHubLibraryService>();
            services.AddScoped<IMyGitHubLibrary, MyGitHubLibraryRepository>();
        }
    }

}
