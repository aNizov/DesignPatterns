using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ДОБАВЛЕНИЕ ПОДДЕРЖКИ НЕСКОЛЬКИХ УВЕДОМЛЕНИЙ
namespace Behavioral_Observer.From_Observer_Pattern_To_Events_3
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        //12. Добавляем в интерфейс дополнительные методы
        //prev. void Notify(string data);
        void AfterDoSomethingWith(string data);
        void AfterDoMore(string complete, string appendedData);
    }
    public interface IObserver
    {
        //13. Меняем интерфейс IObserver с учетом изменений ISubject
        //prev. void Update(ISubject sender, string data);
        void AfterDoSomethingWith(ISubject sender, string data);
        void AfterDoMore(ISubject sender, string completeData, string appendedData);
    }
    public class ConcreteSubject : ISubject
    {
        //14. Меняем ConcreeteSubject в соответствии с интерфейсом
        private readonly IList<IObserver> _observers = new List<IObserver>();

        //15.
        private string data = string.Empty;

        public void DoSomething(string data)
        {
            this.data = data;
            //16.
            //prev. Notify(_data);
            this.AfterDoSomethingWith(this.data);
        }
        //18.
        public void DoMore(string appendData)
        {
            this.data += appendData;
            AfterDoMore(this.data, appendData);
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        //17.
        //prev.  public void Notify(string data)
        public void AfterDoSomethingWith(string data)
        {
            foreach (IObserver observer in _observers)
            {
                //prev.   observer.Update(this, data);
                observer.AfterDoSomethingWith(this, data);
            }
        }
        //19.
        public void AfterDoMore(string completeData, string appendedData)
        {
            foreach (IObserver observer in _observers)
            {
                observer.AfterDoMore(this, completeData, appendedData);
            }
        }
    }
    public class ConcreteObderver1 : IObserver
    {
        public void AfterDoSomethingWith(ISubject sender, string data)
        {
            Console.WriteLine("ConcreteObserver1 AfterDoSomethingWith() method called {0}", data.ToUpper());
        }
        // 20. ЕСЛИ МЫ НЕ ХОТИМ ПОЛУЧАТЬ УВЕДОМЛЕНИЯ О СОБЫТИИ, ТО ТЕЛО МЕТОДА НУЖНО ОТСАВИТЬ ПУСТЫМ.
        // ЭТО КРАЙНЕ НЕУДАЧНОЕ, НО ВЫНУЖДЕННОЕ РЕШЕНИЕ
        public void AfterDoMore(ISubject sender, string completeData, string appendedData)
        {
            
        }
    }
    public class ConcreteObderver2 : IObserver
    {
        public void AfterDoSomethingWith(ISubject sender, string data)
        {
            Console.WriteLine("ConcreteObserver2 AfterDoSomethingWith() method called {0}", data.ToUpper());
        }
        // 21. Здесь все впорядке, т.к. нам нужна подписка на уведомления
        public void AfterDoMore(ISubject sender, string completeData, string appendedData)
        {
            Console.WriteLine("ConcreteObserver2 AfterDoMore() method called {0}", appendedData.ToUpper());
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
            subj.DoMore("tail");

        }
    }
    //Вывод 
    //ConcreteObserver1 AfterDoSomethingWith() method called MY DATA
    //ConcreteObserver2 AfterDoSomethingWith() method called MY DATA
    //ConcreteObserver2 AfterDoMore() method called MY DATA
}
