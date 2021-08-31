using System;

namespace Blog.Screens.RoleScreens
{
    public static class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Perfis");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar perfis");
            Console.WriteLine("2 - Cadastrar perfis");
            Console.WriteLine("3 - Atualizar perfis");
            Console.WriteLine("4 - Excluir perfis");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    //ListTagScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    //UpdateTagScreen.Load();
                    break;
                case 4:
                    //DeleteTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}