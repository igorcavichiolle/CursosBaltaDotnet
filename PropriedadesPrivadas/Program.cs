using System;

namespace PropriedadesPrivadas
{
    class Program
    {
        /// <summary>
        /// Programa utilizando conceitos de propriedades privadas
        /// Clean code e boas praticas de programação
        /// https://www.youtube.com/watch?v=mjJwulk8_QM
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Criando lógicamente o pedido ja passando os parametros necessarios para ele
            var order = new Order("Pedro");
            var mouse = new OrderItem("mouse", 2, 10);

            //utilizando o método AddItem criado para adicionar um novo item no pedido
            //order.Items.Add() não está disponivel pois a lista publica é um IEnumerable
            order.AddItem(mouse);

            var oder2 = new Order("Igor");
            var fone = new OrderItem("fone", 5, 10);

            oder2.AddItem(fone);

            Console.WriteLine(order.Customer);
            Console.WriteLine(order.Number);
            Console.WriteLine(order.Date);
            Console.WriteLine(order.GetTotalOrder());

            Console.WriteLine("---------------------------------------");

            Console.WriteLine(oder2.Customer);
            Console.WriteLine(oder2.Number);
            Console.WriteLine(oder2.Date);
            Console.WriteLine(oder2.GetTotalOrder());
        }
    }
}
