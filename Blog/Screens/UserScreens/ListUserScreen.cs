using System;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários");
            Console.WriteLine("-------------");
            ListWithRoles();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var tags = repository.Get();
            foreach (var item in tags)
                Console.WriteLine($"Nome: {item.Name} ,Email: {item.Email}");
        }

        private static void ListWithRoles()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine();
                Console.WriteLine($"Nome: {user.Name} ,Email: {user.Email}");
                Console.Write($"Perfis: ");
                foreach (var role in user.Roles)
                {
                    if (!(user.Roles.IndexOf(role) == 0))
                    {
                        Console.Write(",");
                    }
                    Console.Write($"{role.Slug}");
                }
                Console.WriteLine();
            }

        }
    }
}