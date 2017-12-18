using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Observer.Strongly_Typed_Observer
{
    public interface IClassObserver
    {
        void SomeEventHappened(string str);
    }

    public class ClassA
    {
        private readonly IClassObserver _observer;

        public ClassA(IClassObserver observer)
        {
            _observer = observer;
        }

        private void DetectEvent()
        {
            //Какой-то предикат
            _observer.SomeEventHappened("ssss");
        }
    }
}
