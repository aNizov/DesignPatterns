﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Singleton
{
    class LazySingleton
    {
        private readonly Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());

        protected LazySingleton() { }

        public LazySingleton Instance => _instance.Value;
    }
}
