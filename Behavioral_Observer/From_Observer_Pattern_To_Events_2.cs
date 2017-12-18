using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

//УДАЛЕНИЕ СВЯЗИ МЕЖДУ ПОСТАВЩИКОМ И ДАННЫМИ, ПЕРЕДАВАЕМЫМИ НАБЛЮДАТЕЛЮ
namespace Behavioral_Observer.From_Observer_Pattern_To_Events_2
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        //3. Добавляем данные в метод
        //prev. void Notify();
        void Notify(string data);
        //1. В конкретной имплементации поставщик не должен запоминать данные, которые он передает наблюдателю,
        //т.к. они должны быть привязаны к наблюдателю
        //prev. string Data { get; }
    }

    public interface IObserver
    {
        //2. Дадим поставщику получать данные через метод update
        //prev. void Update(ISubject sender);
        void Update(ISubject sender, string data);
    }
    public class ConcreteSubject : ISubject
    {
        private readonly IList<IObserver> _observers = new List<IObserver>();

        //4. Удаляем свойство Data из конкретной имплементации 
        //public string Data { get; private set; }

        public void DoSomething(string data)
        {
            //5. 
            //prev. this.Data = data;
            //prev. Notify();
            Notify(data);
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        //6. 
        //prev. public void Notify()
        public void Notify(string data)
        {
            foreach (IObserver observer in _observers)
            {
                //7.
                //prev. observer.Update(this);
                observer.Update(this, data);
            }
        }
    }
    public class ConcreteObderver1 : IObserver
    {
        //8. Меняем сигнатуры конкретных обозревателей в соответствии с интерфейсом
        //public void Update(ISubject sender)
        public void Update(ISubject sender, string data)
        {
            //9. 
            //prev. Console.WriteLine("ConcreteObserver1 Update() method called {0}", sender.Data.ToUpper());
            Console.WriteLine("ConcreteObserver1 Update() method called {0}", data.ToUpper());
        }
    }
    public class ConcreteObderver2 : IObserver
    {
        //10.
        //prev. public void Update(ISubject sender)
        public void Update(ISubject sender, string data)
        {
            //11.
            //prev. Console.WriteLine("ConcreteObserver2 Update() method called {0}", sender.Data.ToUpper());
            Console.WriteLine("ConcreteObserver2 Update() method called {0}", data.ToUpper());
        }
    }

    public class Client
    {
        public void Main()
        {
            ConcreteSubject subj = new ConcreteSubject();
            subj.Attach(new ConcreteObderver1());
            subj.Attach(new ConcreteObderver2());
            subj.DoSomething("my data");

        }
    }
}
