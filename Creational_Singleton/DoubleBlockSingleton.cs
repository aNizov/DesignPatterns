using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Singleton
{
    class DoubleBlockSingleton
    {
        private static volatile DoubleBlockSingleton _instance;
        private static readonly object _blocker = new object();

        protected DoubleBlockSingleton() { }

        public DoubleBlockSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_blocker)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleBlockSingleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
