using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("-------------");
            ListWithPost();
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.Get();
            foreach (var item in tags)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }

        private static void ListWithPost()
        {
            var repository = new TagRepository(Database.Connection);
            var tags = repository.GetWithPosts();

            foreach (var tag in tags)
            {
                Console.WriteLine();
                Console.WriteLine($"{tag.Id} - {tag.Name} ({tag.Slug})");
                Console.WriteLine($"Quantidade de posts: {tag.QtdPosts}");
            }
        }
    }
}