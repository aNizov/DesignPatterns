using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Implementations
{
    class Product: IProduct
    {
        public void SomeMethod()
        {
            Console.WriteLine("Instance created");
        }
    }
}
