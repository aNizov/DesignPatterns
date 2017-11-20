using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Frame;

namespace AbstractFactory.Implementation1
{
    public class ThirdClass1: IThirdItem
    {
        public void SomeMethod31()
        {
            Console.WriteLine("implementation 1 of method 31");
        }

        public void SomeMethod32()
        {
            Console.WriteLine("implementation 1 of method 32");
        }
    }
}
