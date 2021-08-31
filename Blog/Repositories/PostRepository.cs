using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public List<Post> GetWithTags()
        {
            var query = @"
                SELECT 
                    [Post].*,
                    [Tag].*
                FROM [Post]
                    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";

            var posts = new List<Post>();

            var items = _connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        if (tag != null)
                            pst.Tags.Add(tag);

                        posts.Add(pst);
                    }
                    else
                        pst.Tags.Add(tag);

                    return post;
                }, splitOn: "Id");

            return posts;
        }

        public List<Post> GetFromCategory(int id)
        {

            var query = @"
                    SELECT 
                        *
                    FROM 
                        [Post]
                    WHERE 
                        [CategoryId] = @CategoryId";

            return _connection.Query<Post>(query, new { CategoryId = id }).ToList();
        }

        public List<Post> GetWithCategory()
        {
            var query = @"
                SELECT 
                    [Post].*,
                    [Category].*
                FROM 
                    [Post]
                INNER JOIN 
                    [Category] ON [Post].[CategoryId] = [Category].[Id]";

            var posts = new List<Post>();

            var items = _connection.Query<Post, Category, Post>(
                query,
                (post, category) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        if (category != null)
                            pst.Category = category;

                        posts.Add(pst);
                    }
                    else
                        pst.Category = category;

                    return post;
                }, splitOn: "Id");

            return posts;
        }
    }
}