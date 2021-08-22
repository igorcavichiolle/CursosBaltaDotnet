using System;
using System.Threading;

namespace Stopwatch
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
            Console.WriteLine("S = Segundo => 10s = 10 segundos");
            Console.WriteLine("M = Minuto => 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            string data = Console.ReadLine().ToLower();

            //data.Length - 1 (Pegando a posição do ultimo caractere da string)
            char type = char.Parse(data.Substring(data.Length - 1, 1));

            //Agora vamos da posição 0 até a ultima posição -1
            int time = int.Parse(data.Substring(0, data.Length - 1));

            //Multiplicador apenas ira mudar para 60 quando for escolhido a opção minutos
            int multiplier = 1;

            if (type == 'm')
                multiplier = 60;

            if (time == 0)
                System.Environment.Exit(0);

            //Sempre passando o multiplicador
            PreStart(time * multiplier);
        }
        static void PreStart(int pTime)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(pTime);
        }
        static void Start(int pTime)
        {
            int currentTime = 0;

            while (currentTime != pTime)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizado");
            Thread.Sleep(2500);
            Menu();
        }
    }
}
