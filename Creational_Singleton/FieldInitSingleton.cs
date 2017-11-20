using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Singleton
{
    //"Неленивая" реализация, т.к. возможная инициализация при обращению у любому другому статическому полю класса
    internal class FieldInitSingleton
    {
        private static readonly FieldInitSingleton _instance = new FieldInitSingleton();
        protected FieldInitSingleton() { }
        static FieldInitSingleton() { }

        public static FieldInitSingleton Instance => _instance;
    }
}
