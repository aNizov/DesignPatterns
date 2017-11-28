using System;

namespace Creational_Factory_Method.Base
{
    class Program
    {
        static void Main()
        {
            IFactory factory = new Factory();
            IProduct product = factory.GetInstance();
            product.SomeMethod();
        }
    }
    internal class Factory : IFactory
    {
        public IProduct GetInstance()
        {
            return new Product();
        }
    }
    class Product : IProduct
    {
        public void SomeMethod()
        {
            Console.WriteLine("Instance created");
        }
    }
    public interface IFactory
    {
        IProduct GetInstance();
    }
    public interface IProduct
    {
        void SomeMethod();
    }
}
