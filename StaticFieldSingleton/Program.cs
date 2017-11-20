using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticFieldSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
        }

    }
    //"Неленивая" реализация, т.к. возможная инициализация при обращению у любому другому статическому полю класса
    sealed class FieldInitSingleton
    {
        private static readonly FieldInitSingleton _instance = new FieldInitSingleton();
        protected FieldInitSingleton() { }
        static FieldInitSingleton() { }

        public static FieldInitSingleton Instance => _instance;
    }
    //Полностью "ленивая" реализация с помощью nested класса
    sealed class LazyFieldInitSingleton
    {
        private LazyFieldInitSingleton() { }
        public static LazyFieldInitSingleton Instance => SingletonHolder._instance;

        // Именно вложенный класс делает реализацию полностью «ленивой»
            private static class SingletonHolder
            {
                public static readonly LazyFieldInitSingleton _instance =
                    new LazyFieldInitSingleton();
                // Пустой статический конструктор уже не нужен, если мы будем
                // обращаться к полю _instance лишь из свойства Instance
                // класса LazyFieldSingleton
            }
    }

}
