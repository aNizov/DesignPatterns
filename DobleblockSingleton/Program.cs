using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobleblockSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class DoubleBlockSingleton
    {
        private static volatile DoubleBlockSingleton _instance;
        private static readonly object _blocker = new object();

        protected DoubleBlockSingleton() { }

        public DoubleBlockSingleton Instance { get {

            if (_instance == null)
            {
                lock (_blocker)
                {
                    if (_instance == null)
                    {
                        return new DoubleBlockSingleton();
                    }
                }
            }
            return _instance;
        } }
    }
}
