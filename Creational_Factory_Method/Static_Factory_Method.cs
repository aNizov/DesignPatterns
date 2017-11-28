using System;
using System.Collections.Generic;

namespace Creational_Factory_Method.Static_Factory_Method
{
    class Program
    {
        public static void Main()
        {
            IProduct instance1 = Factory.Create(1);
            instance1.SomeMethod();

            IProduct instance2 = Factory.Create(2);
            instance2.SomeMethod();

            IProduct instance3 = Factory.Create(3);
            instance3.SomeMethod();
        }
    }
    public static class Factory
    {
        private static readonly Dictionary<int, Func<IProduct>> Map = new Dictionary<int, Func<IProduct>>();

        private static void GetMap()
        {
            Map[1] = () => new Product1();
            Map[2] = () => new Product2();
            Map[3] = () => new Product3();
        }

        private static Func<IProduct> GetInstance(int key)
        {
            GetMap();
            return Map[key];
        }

        public static IProduct Create(int key)
        {
            var instance = GetInstance(key);
            if (instance == null)
            {
                throw new ArgumentException($"Key value {key} does not supported");
            }
            return instance();
        }
    }
    class Product1 : IProduct
    {
        public void SomeMethod()
        {
            Console.WriteLine("Some method implementation of class1");
        }
    }
    class Product2 : IProduct
    {
        public void SomeMethod()
        {
            Console.WriteLine("Some method implementation of class2");
        }
    }
    class Product3 : IProduct
    {
        public void SomeMethod()
        {
            Console.WriteLine("Some method implementation of class3");
        }
    }
    public interface IProduct
    {
        void SomeMethod();
    }
}
