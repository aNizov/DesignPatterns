using System;

namespace Creational_Abstract_Factory
{
    public class FirstClass1 : IFirstItem
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

    public class FirstClass2 : IFirstItem
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
    public class SecondClass1 : ISecondItem
    {
        public void SomeMethod21()
        {
            Console.WriteLine("implementation 1 of method 21");
        }

        public void SomeMethod22()
        {
            Console.WriteLine("implementation 1 of method 22");
        }
    }
    public class SecondClass2 : ISecondItem
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
    public class ThirdClass1 : IThirdItem
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
    public class ThirdClass2 : IThirdItem
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