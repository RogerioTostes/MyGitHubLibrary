using Microsoft.Extensions.Configuration;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Repositories;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyGitHubLibrary.Domain.Aggregates.GitAgg.Service
{
    public class MyGitHubLibraryService : IMyGitHubLibraryService
    {

        private readonly IMyGitHubLibrary _myGitHubLibraryRepository;
        public MyGitHubLibraryService(IMyGitHubLibrary myGitHubLibrary)
        {
            _myGitHubLibraryRepository = myGitHubLibrary;
        }
        public List<Tag> GetTag()
        {
            return _myGitHubLibraryRepository.GetTag();
        }
        public Tag GetTagId(int Id)
        {
            return _myGitHubLibraryRepository.GetTagId(Id);
        }

        public void InsertTag(Tag tag)
        {
            _myGitHubLibraryRepository.InsertTag(tag);
        }
        public void DeleteTag(int Id)
        {
            _myGitHubLibraryRepository.DeleteTag(Id);
        }
        public void UpdateTag(Tag tag)
        {
            _myGitHubLibraryRepository.UpdateTag(tag);
        }

    }
}
