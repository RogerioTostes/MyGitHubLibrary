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
    public class TagService : Interfaces.Services.ITagService
    {

        private readonly ITag _tagRepository;
        public TagService(ITag tag)
        {
            _tagRepository = tag;
        }
        public List<Tag> GetTag()
        {
            return _tagRepository.GetTag();
        }
        public Tag GetTagId(int Id)
        {
            return _tagRepository.GetTagId(Id);
        }

        public void InsertTag(Tag tag)
        {
            _tagRepository.InsertTag(tag);
        }
        public void DeleteTag(int Id)
        {
            _tagRepository.DeleteTag(Id);
        }
        public void UpdateTag(Tag tag)
        {
            _tagRepository.UpdateTag(tag);
        }

    }
}
