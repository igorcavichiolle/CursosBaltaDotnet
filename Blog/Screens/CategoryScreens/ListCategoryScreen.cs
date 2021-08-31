using System;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias");
            Console.WriteLine("-------------");
            ListWithPosts();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void ListWithPosts()
        {
            var repository = new CategoryRepository(Database.Connection);
            var categories = repository.GetWithPosts();

            foreach (var category in categories)
            {
                Console.WriteLine();
                Console.WriteLine($"Nome: {category.Name} ,Slug: {category.Slug}");
                Console.WriteLine($"Quantidade de posts: {category.QtdPosts}");
            }

        }
    }
}