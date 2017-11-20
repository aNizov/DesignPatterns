using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Interfaces
{
    public interface IBuilder
    {
        void InitializeFirstItem();
        void InitializeSecondItem();
        void InitializeThirdItem();

        void GetResult();
    }
}
