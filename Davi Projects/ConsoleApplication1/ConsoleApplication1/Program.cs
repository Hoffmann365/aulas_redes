using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Digite Seu Nome:");
            string x = Console.ReadLine();
            Console.WriteLine("Olá, Seja Bem Vindo " + x);
        }
    }
}