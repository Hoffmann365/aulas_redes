using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        try
        {
            string server = "192.168.88.254";
            int port = 13000;

            TcpClient client = new TcpClient(server, port);
            NetworkStream stream = client.GetStream();
            int i = 0;
            while (true)
            {
                i++;
                if (i == 1)
                {
                    Console.WriteLine("Digite seu nome:");
                }
                else
                {
                    Console.WriteLine("Digite uma mensagem para enviar ao servidor:");
                }
                
                string msg = Console.ReadLine();
                string message = msg;
                byte[] data = Encoding.ASCII.GetBytes(message);

                stream.Write(data, 0, data.Length);
                Console.WriteLine("Enviado: {0}", message);

                data = new byte[256];
                int bytesRead = stream.Read(data, 0, data.Length);
                string responseData = Encoding.ASCII.GetString(data, 0, bytesRead);
                Console.WriteLine("Recebido: {0}", responseData);

                if (msg == "")
                {
                    break;
                }
            }
            

            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\nPressione Enter para continuar...");
        Console.Read();
    }
}