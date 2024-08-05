using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket_Client
{
    class Client
    {
        static void Main(string[] args)
        {
            // Define o IP do Servidor e a Porta
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 11000;

            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, port);

            // Cria um Socket TCP/IP
            Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            string clientText = null;
            

            try
            {
                // Conecta ao Servidor
                sender.Connect(remoteEndPoint);

                Console.WriteLine("Socket conectado a {0}", sender.RemoteEndPoint.ToString());
                while (true)
                {
                    //Cliente digita mensagem que será enviada ao servidor
                    Console.WriteLine("Escreva uma mensagem para enviar para o servidor:");
                    clientText = Console.ReadLine();

                    // Envia dados ao servidor
                    byte[] msg = Encoding.UTF8.GetBytes(clientText);

                    int bytesSent = sender.Send(msg);

                    // Recebe a resposta do servidor
                    byte[] bytes = new byte[1024];
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Resposta recebida : {0}", Encoding.UTF8.GetString(bytes, 0, bytesRec));

                    if (clientText == "0")
                    {
                        break;
                    }
                    
                }
                
                // Fecha o Socket
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.Read();
        }
    }
}