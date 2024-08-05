using System;
using System.Threading;

namespace thread_test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Thread thread = new Thread(PrintNumbers);
            
            thread.Start();

            thread.Join();
            
            Console.WriteLine("Fim do programa");
        }

        static void PrintNumbers()
        {
            string threadId = Thread.CurrentThread.ManagedThreadId.ToString();

            for (int i = 0; i <=5; i++)
            {
                Console.WriteLine($"Thread {threadId} - Número {i}");
                Thread.Sleep(1000);
            }
        }
    }
}