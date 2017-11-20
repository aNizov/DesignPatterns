using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Factory_Method
{
    class Program1
    {
        static void Main()
        {
            IFactory1 factory = new Factory();
            IProduct1 product = factory.GetInstance();
            product.SomeMethod();
        }
    }
    internal class Factory : IFactory1
    {
        public IProduct1 GetInstance()
        {
            return new Product1();
        }
    }
    class Product1 : IProduct1
    {
        public void SomeMethod()
        {
            Console.WriteLine("Instance created");
        }
    }
    public interface IFactory1
    {
        IProduct1 GetInstance();
    }
    public interface IProduct1
    {
        void SomeMethod();
    }
}
