using System;
using System.Collections.Generic;

namespace Creational_Factory_Method
{
    class Program3
    {
        public static void Main()
        {
            IProduct3 instance1 = Factory3.Create(1);
            instance1.SomeMethod();

            IProduct3 instance2 = Factory3.Create(2);
            instance2.SomeMethod();

            IProduct3 instance3 = Factory3.Create(3);
            instance3.SomeMethod();
        }
    }
    public static class Factory3
    {
        private static readonly Dictionary<int, Func<IProduct3>> Map = new Dictionary<int, Func<IProduct3>>();

        private static void GetMap()
        {
            Map[1] = () => new Product31();
            Map[2] = () => new Product32();
            Map[3] = () => new Product33();
        }

        private static Func<IProduct3> GetInstance(int key)
        {
            GetMap();
            return Map[key];
        }

        public static IProduct3 Create(int key)
        {
            var instance = GetInstance(key);
            if (instance == null)
            {
                throw new ArgumentException($"Key value {key} does not supported");
            }
            return instance();
        }
    }
    class Product31 : IProduct3
    {
        public void SomeMethod()
        {
            Console.WriteLine("Some method implementation of class1");
        }
    }
    class Product32 : IProduct3
    {
        public void SomeMethod()
        {
            Console.WriteLine("Some method implementation of class2");
        }
    }
    class Product33 : IProduct3
    {
        public void SomeMethod()
        {
            Console.WriteLine("Some method implementation of class3");
        }
    }
    public interface IProduct3
    {
        void SomeMethod();
    }
}
