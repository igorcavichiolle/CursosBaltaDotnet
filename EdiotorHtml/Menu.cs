using System;

namespace EdiotorHtml
{
    public static class Menu
    {
        public static void Show()
        {

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen(30);
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        public static void DrawScreen(int pColums)
        {
            WriteLine(pColums);

            for (int lines = 0; lines < 10; lines++)
            {
                Console.Write("|");
                for (int i = 0; i < pColums; i++)
                    Console.Write(" ");

                Console.Write("|");
                Console.Write("\n");
            }

            WriteLine(pColums);

        }

        public static void WriteLine(int pColums)
        {

            Console.Write("+");

            for (int i = 0; i < pColums; i++)
                Console.Write("-");

            Console.Write("+");
            Console.Write("\n");

        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("=============");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma opção abaixo");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 9);
            Console.Write("Opção: ");
        }

        public static void HandleMenuOption(short pOption)
        {
            switch (pOption)
            {
                case 1: Editor.Show(); break;
                case 2: Console.WriteLine("View"); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Show(); break;
            }
        }
    }
}