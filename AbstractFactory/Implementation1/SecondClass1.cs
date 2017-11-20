using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Frame;

namespace AbstractFactory.Implementation1
{
    public class SecondClass1: ISecondItem
    {
        public void SomeMethod21()
        {
            Console.WriteLine("implementation 1 of method 21");
        }

        public void SomeMethod22()
        {
            Console.WriteLine("implementation 1 of method 22");
        }
    }
}
