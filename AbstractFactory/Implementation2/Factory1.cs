using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Frame;

namespace AbstractFactory.Implementation2
{
    public class Factory2: IFactory
    {
        public IFirstItem CreateFirstItem()
        {
            return new FirstClass2();
        }

        public ISecondItem CreateSecondItem()
        {
            return new SecondClass2();
        }

        public IThirdItem CreaThirdItem()
        {
            return new ThirdClass2();
        }
    }
}
