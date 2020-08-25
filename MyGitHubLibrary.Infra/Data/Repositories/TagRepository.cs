using MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities;
using System.Collections.Generic;
using System.Data;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Repositories;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MyGitHubLibrary.Infra.Data.Repositories
{
    public class TagRepository : ITag
    {
        private readonly IDbConnection conexao;
        //public TagRepository(IConfiguration conf) => conexao = new SqlConnection("Data Source=192.168.100.10,1433;Initial Catalog=MyGitHubLibrary;Persist Security Info=False;User ID=tmds;Password=tmds;MultipleActiveResultSets=False;");
        public TagRepository(IConfiguration conf) => conexao = new SqlConnection("host=postgres;port=5432;database=MyGitHubLibrary;username=mygithublibrary;password=mygithublibrary");

        public List<Tag> GetTag()
        {
            return this.conexao.Query<Tag>("SELECT * FROM Tag").ToList();
        }
        public Tag GetTagId(int Id)
        {
            return this.conexao.Query<Tag>("SELECT * FROM Tag WHERE @Id = Id", new { Id = Id }).SingleOrDefault();
        }

        public void InsertTag(Tag tag)
        {
            this.conexao.Execute(@"INSERT Tag(NameTag,IdRepo) VALUES (@NameTag,@IdRepo)",
            new { NameTag = tag.NameTag, IdRepo = tag.IdRepo });
        }
        public void DeleteTag(int Id)
        {
            this.conexao.Execute(@"DELETE FROM Tag WHERE @ID = Id", new { Id = Id });
        }
        public void UpdateTag(Tag tag)
        {
            this.conexao.Execute("UPDATE Tag SET NameTag=@NameTag WHERE Id=" + tag.Id,
            new { NameTag = tag.NameTag });
        }

    }
}
