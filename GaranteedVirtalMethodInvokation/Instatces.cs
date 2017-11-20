using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaranteedVirtalMethodInvokation
{
    public abstract class Product
    {
        protected internal abstract void SomeMethod();
    }

    public class ConcreeteProduct: Product
    {
        protected internal override void SomeMethod()
        {
            Console.WriteLine("Virtual method of concreete class processed...");
        }
    }
    public class AnotherConcreeteProduct : Product
    {
        protected internal override void SomeMethod()
        {
            Console.WriteLine("Virtual method of another concreete class processed...");
        }
    }
}
