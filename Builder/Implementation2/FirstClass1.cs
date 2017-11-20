using System;
using Builder.Interfaces;

namespace Builder.Implementation2
{
    public class FirstClass2: IFirstItem
    {
        public void SomeMethod11()
        {
            Console.WriteLine("implementation 2 of method 11");
        }

        public void SomeMethod12()
        {
            Console.WriteLine("implementation 2 of method 12");
        }
    }
}
