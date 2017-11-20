using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Interfaces;

namespace Builder
{
    public class Foreman
    {
        private IBuilder _builder;

        public Foreman(IBuilder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.InitializeFirstItem();
            _builder.InitializeSecondItem();
            _builder.InitializeThirdItem();

            _builder.GetResult();
        }

    }
}
