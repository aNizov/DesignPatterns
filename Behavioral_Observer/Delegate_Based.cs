using System;
using System.Threading;

namespace Behavioral_Observer.Delegate_Based
{

    public class ClassA
    {
        private readonly string _arg;
        private readonly Action<string> _subscriber;
        private static readonly TimeSpan CheckInterval = TimeSpan.FromSeconds(5);
        private readonly Timer _timer;

        public ClassA(string arg, Action<string> subscriber)
        {
            _arg = arg;
            _subscriber = subscriber;

            _timer = new Timer(obj => CheckSmth(), null, CheckInterval, CheckInterval);
        }

        private void CheckSmth()
        {
            //Какой-то "предикат"...
            //
            //Вызов метод, уведомляющего о событии внешний класс... 
            _subscriber(_arg);
        }
    }
    //Класс наблюдатель
    public class ObserverA
    {
        //Ключевая особенность данной реализации заключается в том,
        //что класс-наблюдатель и класс-исполнитель находятся в отношении 1:1
        public void Main()
        {
            var str = "ccccc";
            var instanse = new ClassA(str, Method);
        }

        public void Method(string arg) { }
    }
}
