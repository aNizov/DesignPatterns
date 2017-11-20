using System;

namespace StaticFactoryMethod
{
    class Class1: ISomeInterface
    {
        public void SomeMethod()
        {
            Console.WriteLine("Some method implementation of class1");
        }
    }
    class Class2 : ISomeInterface
    {
        public void SomeMethod()
        {
            Console.WriteLine("Some method implementation of class2");
        }
    }
    class Class3 : ISomeInterface
    {
        public void SomeMethod()
        {
            Console.WriteLine("Some method implementation of class3");
        }
    }
}
