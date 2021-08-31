using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class LinkUserToRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Digite o id do usuário");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var usrId = Console.ReadLine();

            var user = GetUserById(int.Parse(usrId));

            if (user != null)
            {
                Console.WriteLine("Digite o id do perfil para vincular");
                Console.Write("Id: ");
                var roleId = Console.ReadLine();

                var role = GetRoleById(int.Parse(roleId));

                if (role != null)
                {
                    Create(new UserRole
                    {
                        RoleId = role.Id,
                        UserId = user.Id
                    });
                }
                else
                {
                    Console.WriteLine("Perfil não encontrado na base de dados");
                }
            }
            else
            {
                Console.WriteLine("Usuario não encontrado na base de dados");
            }


            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(UserRole userRole)
        {
            try
            {
                var repository = new Repository<UserRole>(Database.Connection);
                repository.Create(userRole);
                Console.WriteLine("Usuário vinculado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular o usuário");
                Console.WriteLine(ex.Message);
            }
        }

        public static User GetUserById(int id)
        {
            var repository = new Repository<User>(Database.Connection);
            return repository.Get(id);
        }

        public static Role GetRoleById(int id)
        {
            var repository = new Repository<Role>(Database.Connection);
            return repository.Get(id);
        }
    }
}