using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public List<Category> GetWithPosts()
        {

            var sql = @"
                SELECT 
                    [Category].Id,
                    [Category].[Name],
                    [Category].Slug,
                    COUNT([Post].Id) AS [QtdPosts]
                FROM 
                    [Category]
                LEFT JOIN 
                    [Post] ON [Category].Id = [Post].CategoryId
                GROUP BY [Category].Id, [Category].Name, [Category].Slug";

            return _connection.Query<Category>(sql).ToList();
        }
    }
}