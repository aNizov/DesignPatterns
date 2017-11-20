using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Frame;

namespace AbstractFactory.Implementation1
{
    public class FirstClass1: IFirstItem
    {
        public void SomeMethod11()
        {
            Console.WriteLine("implementation 1 of method 11");
        }

        public void SomeMethod12()
        {
            Console.WriteLine("implementation 1 of method 12");
        }
    }
}
