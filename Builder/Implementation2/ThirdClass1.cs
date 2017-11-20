using System;
using Builder.Interfaces;

namespace Builder.Implementation2
{
    public class ThirdClass2: IThirdItem
    {
        public void SomeMethod31()
        {
            Console.WriteLine("implementation 2 of method 31");
        }

        public void SomeMethod32()
        {
            Console.WriteLine("implementation 2 of method 32");
        }
    }
}
