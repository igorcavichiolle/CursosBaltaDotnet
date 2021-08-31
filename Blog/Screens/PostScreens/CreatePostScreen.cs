using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Post");
            Console.WriteLine("-------------");

            Console.Write("Id da categoria: ");
            var categoryId = Console.ReadLine();

            Console.Write("Id da autor: ");
            var authorId = Console.ReadLine();

            Console.Write("Titulo do post: ");
            var title = Console.ReadLine();

            Console.Write("Sumario do post: ");
            var summary = Console.ReadLine();

            Console.Write("Corpo do post: ");
            var body = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Post
            {
                CategoryId = int.Parse(categoryId),
                AuthorId = int.Parse(authorId),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            });

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Post cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}