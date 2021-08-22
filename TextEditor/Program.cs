using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - abrir arquivo");
            Console.WriteLine("2 - criar novo arquivo");
            Console.WriteLine("0 - sair");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            //StreamReader recebe o caminho de um arquivo e abre o proprio
            //ReadToEnd() le o arquivo até o final e armazena em text
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();

            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("------------------------");

            string text = "";

            //Utiliando o do para sempre realizar a ação e testar a condição depois de realizar
            //Incrementa text com a linha digitada , enquanto a tecla digitada não foi selecionada ESC
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);

        }

        static void Salvar(string pText)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            //Criano um novo arquivo e salvando o conteudo de pText 
            using (var file = new StreamWriter(path))
            {
                file.Write(pText);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadKey();
            Menu();
        }
    }
}
