using System;
using Builder.Interfaces;

namespace Builder.Implementation2
{
    public class SecondClass2: ISecondItem
    {
        public void SomeMethod21()
        {
            Console.WriteLine("implementation 2 of method 21");
        }

        public void SomeMethod22()
        {
            Console.WriteLine("implementation 2 of method 22");
        }
    }
}
