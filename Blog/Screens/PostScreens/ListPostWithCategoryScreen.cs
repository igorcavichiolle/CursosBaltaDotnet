using System;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class ListPostWithCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts");
            Console.WriteLine("-------------");
            ListWithCategories();
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void ListWithCategories()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithCategory();

            foreach (var post in posts)
            {
                Console.WriteLine();
                Console.WriteLine($"Post");
                Console.WriteLine($"Id: {post.Id} ,Titulo: {post.Title}");

                Console.Write($"Categoria : ");
                Console.Write($"{post.Category.Id} - {post.Category.Name}");

                Console.WriteLine();
            }

        }
    }
}