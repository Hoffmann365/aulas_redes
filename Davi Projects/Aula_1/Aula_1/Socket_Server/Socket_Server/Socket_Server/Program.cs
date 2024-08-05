using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket_Server
{
    class Server
    {
        static void Main(string[] args)
        {
            // Definir o IP e a PORTA em que o servidor irá escutar
            IPAddress ipAddress = IPAddress.Any;
            int port = 11000;

            // Cria um endpoint de rede
            IPEndPoint localEndpoint = new IPEndPoint(ipAddress, port);

            // Cria um socket TCP/IP
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            //variável de controle do while
            bool control = true;
            
            try
            {
                // Associa o Socket ao EndPoint e escuta as conexões
                listener.Bind(localEndpoint);
                listener.Listen(10);

                Console.WriteLine("Aguardando por uma Conexão...");

                // Inicia a escuta de conexões de entrada
                while (true)
                {
                    
                    // Programa está Bloqueado enquanto espera por uma conexão
                    Socket handler = listener.Accept();
                    
                    
                    while (true)
                    {
                        string data = null;
                        // Buffer para armazenar os dados recbidos
                        byte[] bytes = new byte[1024];
                        int bytesReceived = handler.Receive(bytes);

                        data += Encoding.UTF8.GetString(bytes, 0, bytesReceived);

                        // Exibe a Mensagem Recebia
                        Console.WriteLine("Texto recebido : {0}", data);
                    
                        // Envia uma mensagem  de confirmação de volta ao cliente
                        byte[] msg = Encoding.UTF8.GetBytes("Mensagem recebida");
                        handler.Send(msg);

                        if (data == "0")
                        {
                            Console.WriteLine("Conexão Encerrada...");
                            break;
                        }
                    }
                        
                    //Fecha o Socket
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    break;
                    
                }
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