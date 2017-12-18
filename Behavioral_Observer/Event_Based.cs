using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Observer.Event_Based
{
    class CustomEventArgs : EventArgs
    {
        private readonly string _args;
        public string Args => _args;
        public CustomEventArgs(string args)
        {
            _args = args;
        }

    }

    class ClassA
    {
        public event EventHandler<CustomEventArgs> OnEvent;
        private void Check()
        {
            //Какой-то предикат...
            //
            //Вызов метода содержащего событие
            EventMethod("aaa");
        }

        public void EventMethod(string str)
        {
            var handler = OnEvent;
            handler?.Invoke(this, new CustomEventArgs(str));
        }
    }

    class Observer
    {
        public void Main()
        {
            ClassA instance = new ClassA();

            //Данный вариант очень похож на вариант с делегатами — с одной важной разницей.
            //Интерфейс класса ClassA позволяет подписаться на событие получения 
            //экземпляра customEventArgs любому числу подписчиков
            instance.OnEvent += SomeMethod;
        }

        //Метод который будет выполняться при срабатывании события
        private void SomeMethod(object sender, CustomEventArgs customEventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
