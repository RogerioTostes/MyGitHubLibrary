using MyGitHubLibrary.Domain.Aggregates.GitAgg.Entities;
using System.Collections.Generic;
using System.Data;
using MyGitHubLibrary.Domain.Aggregates.GitAgg.Interfaces.Repositories;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MyGitHubLibrary.Infra.Data.Repositories
{
    public class TagRepository : ITag
    {
        private readonly NpgsqlConnection conexao;
        //public TagRepository(IConfiguration conf) => conexao = new SqlConnection("Data Source=192.168.100.10,1433;Initial Catalog=MyGitHubLibrary;Persist Security Info=False;User ID=tmds;Password=tmds;MultipleActiveResultSets=False;");
        public TagRepository(IConfiguration conf) => conexao = new NpgsqlConnection("Server=postgres;Port=5432;Database=MyGitHubLibrary;UserId=mygithublibrary;Password=mygithublibrary");

        public List<Tag> GetTag()
        {
            return this.conexao.Query<Tag>("SELECT * FROM tag").ToList();
        }
        public Tag GetTagId(int Id)
        {
            return this.conexao.Query<Tag>("SELECT * FROM tag WHERE @id = id", new { Id = Id }).SingleOrDefault();
        }

        public void InsertTag(Tag tag)
        {
            this.conexao.Execute(@"INSERT INTO tag(nametag,idrepo) VALUES (@NameTag,@IdRepo)",
            new { NameTag = tag.NameTag, IdRepo = tag.IdRepo });
        }
        public void DeleteTag(int Id)
        {
            this.conexao.Execute(@"DELETE FROM Tag WHERE @ID = id", new { Id = Id });
        }
        public void UpdateTag(Tag tag)
        {
            this.conexao.Execute("UPDATE Tag SET nametag=@NameTag WHERE id=" + tag.Id,
            new { NameTag = tag.NameTag });
        }

    }
}
