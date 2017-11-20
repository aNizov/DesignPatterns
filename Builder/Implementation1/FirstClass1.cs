using System;
using Builder.Interfaces;

namespace Builder.Implementation1
{
    public class FirstClass1: IFirstItem
    {
        public void SomeMethod11()
        {
            Console.WriteLine("implementation 1 of method 11");
        }

        public void SomeMethod12()
        {
            Console.WriteLine("implementation 1 of method 12");
        }
    }
}
