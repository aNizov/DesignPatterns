using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Frame
{
    public interface IFactory
    {
        IFirstItem CreateFirstItem();
        ISecondItem CreateSecondItem();
        IThirdItem CreaThirdItem();
    }
}
