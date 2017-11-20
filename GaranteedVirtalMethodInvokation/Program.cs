using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaranteedVirtalMethodInvokation
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = Factory<ConcreeteProduct>.Create();
            var anotherInstance = Factory<AnotherConcreeteProduct>.Create();
        }
    }
}
