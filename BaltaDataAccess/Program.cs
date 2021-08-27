using System;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    //Utilizando o ADO.NET Puro para conexão direta ao banco de dados
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=";

            // //Objeto de conexao com o banco de dados 
            // var connection = new SqlConnection();

            // //Abrindo conexao
            // connection.Open();

            // //Fechando conexao
            // connection.Close();

            // //Distroi o objeto SqlConnection (E Fecha a conexao)
            // connection.Dispose();

            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado");
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }

            }
        }
    }
}
