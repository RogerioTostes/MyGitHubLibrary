using MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Repositories
{
    public interface ITag
    {
        List<Tag> GetTag();
        Tag GetTagId(int Id);
        void InsertTag(Tag NameTag);
        void DeleteTag(int Id);
        void UpdateTag(Tag NameTag);
    }
}
