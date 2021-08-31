using System;
using System.Collections.Generic;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class ListPostFromCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Digite o id da categoria");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var catId = Console.ReadLine();

            var cat = GetCategoryById(int.Parse(catId));

            if (cat != null)
            {
                GetFromCategory(cat.Id);
            }
            else
            {
                Console.WriteLine("Categoria não encontrada na base de dados");
            }


            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void GetFromCategory(int idCategory)
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetFromCategory(idCategory);

            foreach (var post in posts)
            {
                Console.WriteLine();
                Console.WriteLine($"Id: {post.Id} ,Titulo: {post.Title}");
            }
        }

        public static Category GetCategoryById(int id)
        {
            var repository = new Repository<Category>(Database.Connection);
            return repository.Get(id);
        }
    }
}