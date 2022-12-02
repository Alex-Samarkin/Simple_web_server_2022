using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MyServer server = new MyServer();
            await server.AnswerAsync();
            Console.WriteLine("----->");
            Console.ReadLine();
        }

    }
}
