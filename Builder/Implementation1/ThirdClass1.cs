using System;
using Builder.Interfaces;

namespace Builder.Implementation1
{
    public class ThirdClass1: IThirdItem
    {
        public void SomeMethod31()
        {
            Console.WriteLine("implementation 1 of method 31");
        }

        public void SomeMethod32()
        {
            Console.WriteLine("implementation 1 of method 32");
        }
    }
}
