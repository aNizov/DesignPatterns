using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//БАЗОВАЯ РЕАЛИЗАЦИЯ ПАТТЕРНА, НАИБОЛЕЕ ПОХОЖАЯ НА ВЕРСИЮ GOF
namespace Behavioral_Observer.From_Observer_Pattern_To_Events_1
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
        string Data { get; }
    }

    public interface IObserver
    {
        void Update(ISubject sender);
    }
    public class ConcreteSubject : ISubject
    {
        private readonly IList<IObserver> _observers = new List<IObserver>();

        public string Data { get; private set; }

        public void DoSomething(string data)
        {
            this.Data = data;
            Notify();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
    public class ConcreteObderver1 : IObserver
    {
        public void Update(ISubject sender)
        {
            Console.WriteLine("ConcreteObserver1 Update() method called {0}", sender.Data.ToUpper());
        }
    }
    public class ConcreteObderver2 : IObserver
    {
        public void Update(ISubject sender)
        {
            Console.WriteLine("ConcreteObserver2 Update() method called {0}", sender.Data.ToUpper());
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
