using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Implementation1;
using AbstractFactory.Implementation2;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(new Factory1());
            client.Run();

            Console.WriteLine(new string('-', 20));

            client = new Client(new Factory2());
            client.Run();
        }
    }
}
