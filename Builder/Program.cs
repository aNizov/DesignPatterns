using System;
using Builder.Implementation1;
using Builder.Implementation2;
using Builder.Interfaces;

namespace Builder
{
    class Program
    {
        static void Main()
        {
            IBuilder builder1 = new Builder1();
            Foreman foreman1 = new Foreman(builder1);
            foreman1.Construct();
            builder1.GetResult();

            Console.WriteLine(new string('-', 50));

            IBuilder builder2 = new Builder2();
            Foreman foreman2 = new Foreman(builder2);
            foreman2.Construct();
            builder2.GetResult(); // По идее метод должен возвращать сконструированный тип, но я это упустил для простоты
        }
    }
}
