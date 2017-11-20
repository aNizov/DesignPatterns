using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Frame;

namespace AbstractFactory.Implementation1
{
    public class Factory1: IFactory
    {
        public IFirstItem CreateFirstItem()
        {
            return new FirstClass1();
        }

        public ISecondItem CreateSecondItem()
        {
            return new SecondClass1();
        }

        public IThirdItem CreaThirdItem()
        {
            return new ThirdClass1();
        }
    }
}
