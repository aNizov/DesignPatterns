using System;
using System.Collections.Generic;

namespace StaticFactoryMethod
{
    public static class Factory
    {
        private static readonly Dictionary<int, Func<ISomeInterface>> Map = new Dictionary<int, Func<ISomeInterface>>();

        private static void GetMap()
        {
            Map[1] = () => new Class1();
            Map[2] = () => new Class2();
            Map[3] = () => new Class3();
        }

        private static Func<ISomeInterface> GetInstance(int key)
        {
            GetMap();
            return Map[key];
        }

        public static ISomeInterface Create(int key)
        {
            var instance = GetInstance(key);
            if (instance == null)
            {
                throw new ArgumentException($"Key value {key} does not supported");
            }
            return instance();
        }
    }
}