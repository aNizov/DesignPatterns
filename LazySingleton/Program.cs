using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazySingleton
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class LazySingleton
    {
        private readonly Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());

        protected LazySingleton() { }

        public LazySingleton Instance => _instance.Value;
    }

}
