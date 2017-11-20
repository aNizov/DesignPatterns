using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Frame;

namespace AbstractFactory.Implementation2
{
    public class ThirdClass2: IThirdItem
    {
        public void SomeMethod31()
        {
            Console.WriteLine("implementation 2 of method 31");
        }

        public void SomeMethod32()
        {
            Console.WriteLine("implementation 2 of method 32");
        }
    }
}
