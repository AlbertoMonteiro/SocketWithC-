using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Socket.Commom;

namespace SocketSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryFormatter = new BinaryFormatter();
            Console.WriteLine("Qual o nome da pessoa?");
            string nome;
            while (!string.IsNullOrEmpty(nome = Console.ReadLine()))
            {
                using (var client = new TcpClient("localhost", 18000))
                using (var stream = client.GetStream())
                    binaryFormatter.Serialize(stream, new Pessoa {Nome = nome});
                Console.WriteLine("Qual o nome da pessoa?");
            }
        }

    }
}
