using Dapper;
using Microsoft.Extensions.Configuration;
using MyGitHubLibrary.Interface;
using MyGitHubLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace MyGitHubLibrary.Repository
{
    public class MyGitHubLibraryRepository: IMyGitHubLibrary
    {       
        private readonly IDbConnection conexao;

        public MyGitHubLibraryRepository(IConfiguration conf) => conexao = new SqlConnection(conf.GetConnectionString("MyGitHubLibrary"));
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
            this.conexao.Execute(@"INSERT Tag(NameTag) VALUES (@NameTag)",
            new { NameTag = tag.NameTag });
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
