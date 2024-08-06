using System;
using System.Threading;

namespace thread_test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Cria uma nova thread que executa o método PrintNumbers;
            Thread thread = new Thread(() => PrintNumbers(1,5,1000));
            Thread thread2 = new Thread(() => PrintNumbers(1,10,500));
            // Inicia a thread
            thread.Start();
            //Inicia a thread2
            thread2.Start();
           
            // Aguarda a conclusão da thread
            thread.Join();
            // Aguarda a conclusão da thread2
            thread2.Join();
            
            Console.WriteLine("Fim do programa");
        }
        // Método que será executado pela thread
        static void PrintNumbers(int x, int y, int z)
        {
            // Obtém o identificador da thread atual
            string threadId = Thread.CurrentThread.ManagedThreadId.ToString();

            for (int i = x; i <=y; i++)
            {
                Console.WriteLine($"Thread {threadId} - Número {i}");
                // Pausa de 1 segundo entre cada número
                Thread.Sleep(z);
            }
        }
        
    }
}