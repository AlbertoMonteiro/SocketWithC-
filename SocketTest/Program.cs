using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using Socket.Commom;

namespace SocketTest
{
    class Program
    {
        private static TcpListener _listener;

        static void Main(string[] args)
        {
            _listener = new TcpListener(IPAddress.Any, 18000);
            _listener.Start();
            Console.WriteLine("Escutando");
            var thread = new Thread(EscutaClients);
            thread.Start();
        }

        private static void EscutaClients()
        {
            var mensagem = new BinaryFormatter();
            while (true)
            {
                var tempStream = new MemoryStream();
                using (var conexao = _listener.AcceptTcpClient())
                using (var stream = conexao.GetStream())
                    stream.CopyTo(tempStream);

                tempStream.Seek(0, SeekOrigin.Begin);
                var pessoa = (Pessoa)mensagem.Deserialize(tempStream);
                Console.WriteLine("Pessoa recebida, {0}", pessoa);
            }
        }

    }
}
