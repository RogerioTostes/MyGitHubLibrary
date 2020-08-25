using MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Repositories
{
    public interface IMyGitHubLibrary
    {
        List<Tag> GetTag();
        Tag GetTagId(int Id);
        void InsertTag(Tag NameTag);
        void DeleteTag(int Id);
        void UpdateTag(Tag NameTag);
    }
}
