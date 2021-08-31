using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection;

        public TagRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public List<Tag> GetWithPosts()
        {

            var sql = @"
                SELECT 
                    [Tag].Id,
                    [Tag].Name,
                    [Tag].Slug,
                    COUNT([PostTag].PostId) AS [QtdPosts]
                FROM 
                    [Tag]
                LEFT JOIN [PostTag] ON [Tag].[Id] = [PostTag].[TagId]
                GROUP BY [Tag].[Id], [Tag].[Name], [Tag].[Slug]";

            return _connection.Query<Tag>(sql).ToList();
        }
    }
}