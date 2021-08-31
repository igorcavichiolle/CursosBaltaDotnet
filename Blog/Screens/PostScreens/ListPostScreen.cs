using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts");
            Console.WriteLine("-------------");
            ListWithTags();
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void ListWithTags()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithTags();

            foreach (var post in posts)
            {
                Console.WriteLine();
                Console.WriteLine($"Id: {post.Id} ,Titulo: {post.Title}");


                Console.Write($"Tags: ");
                foreach (var tag in post.Tags)
                {
                    if (!(post.Tags.IndexOf(tag) == 0))
                    {
                        Console.Write(", ");
                    }
                    Console.Write($"{tag.Name}");
                }
                Console.WriteLine();
            }

        }
    }
}