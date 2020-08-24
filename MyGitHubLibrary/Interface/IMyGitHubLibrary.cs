using MyGitHubLibrary.Models;
using System.Collections.Generic;

namespace MyGitHubLibrary.Interface
{
    interface IMyGitHubLibrary
    {
        List<Tag> GetTag();
        Tag GetTagId(int Id);      
        void InsertTag(Tag NameTag);
        void DeleteTag(int Id);
        void UpdateTag(Tag NameTag);
    }
}
