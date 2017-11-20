using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticFactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ISomeInterface instance1 = Factory.Create(1);
            instance1.SomeMethod();

            ISomeInterface instance2 = Factory.Create(2);
            instance2.SomeMethod();

            ISomeInterface instance3 = Factory.Create(3);
            instance3.SomeMethod();
        }
    }
}
