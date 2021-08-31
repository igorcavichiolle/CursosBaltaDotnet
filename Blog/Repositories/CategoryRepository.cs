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

        // public List<Category> GetWithPostss()
        // {
        //     var query = @"
        //         SELECT
        //             [Category].*,
        //             [Post].*
        //         FROM 
        //             [Category]
        //         LEFT JOIN 
        //             [Post] ON [Category].[Id] = [Post].[CategoryId]";

        //     var categories = new List<Category>();

        //     var items = _connection.Query<Category, Post, Category>(
        //         query,
        //         (category, post) =>
        //         {
        //             var ctg = categories.FirstOrDefault(x => x.Id == category.Id);
        //             if (ctg == null)
        //             {
        //                 ctg = category;
        //                 if (post != null)
        //                     ctg..Add(role);

        //                 users.Add(ctg);
        //             }
        //             else
        //                 usr.Roles.Add(role);

        //             return user;
        //         }, splitOn: "Id");

        //     return users;
        // }
    }
}