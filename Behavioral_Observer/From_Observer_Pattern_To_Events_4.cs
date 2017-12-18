using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

// НЕДОСТАТКИ ПРЕДУДУЩЕЙ РЕАЛИЗАЦИИ
// - все методы-уведомления смешаны в одном интерфейсе ISubject
// - класс ConcreteSubject ответственнен за возникновение событий и уведомление обозревателей
// нужно разделить возникновение событий и уведомление списка обозревателей, 
// путем выделения функционала уведомления в отдельный класс. 

//НЕОБХОДИМО ОБЕСПЕЧИТЬ ОБОЗРЕВАТЕЛЮ ВОЗМОЖНОСТЬ ВЫБИРАТЬ СПИСОК НОТИФИКАЦИЙ
//, НА КОТОРЫЕ ЕМУ НУЖНО БЫТЬ ПОДПИСАННЫМ
namespace Behavioral_Observer.From_Observer_Pattern_To_Events_4
{
    //25. Этот интерфейс больше не нужен, т..к. за уведомление теперь отвечает MulticastNotifier
    //prev. public interface ISubject
    //prev. {
    //prev.     void Attach(IObserver observer);
    //prev.     void Detach(IObserver observer);
    //prev.     void AfterDoSomethingWith(string data);
    //prev.     void AfterDoMore(string complete, string appendedData);
    //prev. }

    //22. Используя дженерики меняем интерфейс на обобщенный
    //prev. public interface IObserver
    public interface IObserver<T>
    {
        //23. Удаляем отдельные методы под каждое событие, они больше не нужны.
        //Вместо них добовляем 1 метод с обобщенным аргументом
        //prev. void AfterDoSomethingWith(ISubject sender, string data);
        //prev. void AfterDoMore(ISubject sender, string completeData, string appendedData);
        void Update(object sender, T data);
    }
    //23. Добавляем новый класс, ответственный за уведомления, используем дженерики
    public class MulticastNotifier<T>
    {
        //24. именно в него мы и добавляем список наблюдателей
        private readonly IList<IObserver<T>> invocationList;

        public MulticastNotifier(IEnumerable<IObserver<T>> observers)
        {
            this.invocationList = new List<IObserver<T>>(observers);
        }
        //28.
        //Добавляем методы ответственные за оповещегние, 
        //удаленные из ConcreeteSubject с некоторыми модификациями
        public void Notify(object sender, T data)
        {
            foreach (IObserver<T> observer in this.invocationList)
                observer.Update(sender, data);
        }
    }
    //26.
    //prev. public class ConcreteSubject : ISubject
    public class ConcreteSubject
    {
        //29. Редактируем члены класса 
        //добавим 2 поля с Multicastnotifier'ами 
        //и 2 новых метода OnAfterDoSomethingWith и OnAfterDoMore
        //prev. private readonly IList<IObserver> _observers = new List<IObserver>();
        private string data = string.Empty;
        public MulticastNotifier<string> AfterDoSomethingWith;
        public MulticastNotifier<Tuple<string, string>> AfterDoMore;
        public void DoSomething(string data)
        {
            this.data = data;
            this.OnAfterDoSomethingWith(this.data);
        }
        public void DoMore(string appendedData)
        {
            this.data += appendedData;
            this.OnAfterDoMore(this.data, appendedData);
        }
        private void OnAfterDoSomethingWith(string data)
        {
            AfterDoSomethingWith?.Notify(this, data);
        }
        private void OnAfterDoMore(string completeData, string appendedData)
        {
            AfterDoMore?.Notify(this, Tuple.Create(completeData, appendedData));
        }
        //27. Методы ответственные за уведомление наблюдателей тоже больше не нужны,
        // их необходимо перенести в Multicastnotifier
        //prev. public void Attach(IObserver observer)
        //prev. {
        //prev.     _observers.Add(observer);
        //prev. }
        //prev. public void Detach(IObserver observer)
        //prev. {
        //prev.     _observers.Remove(observer);
        //prev. }
        //prev. public void AfterDoSomethingWith(string data)
        //prev. {
        //prev.     foreach (IObserver observer in _observers)
        //prev.     {
        //prev.         observer.AfterDoSomethingWith(this, data);
        //prev.     }
        //prev. }
        //prev. public void AfterDoMore(string completeData, string appendedData)
        //prev. {
        //prev.     foreach (IObserver observer in _observers)
        //prev.     {
        //prev.         observer.AfterDoMore(this, completeData, appendedData);
        //prev.     }
        //prev. }
    }
    //30. Создаем новый класс-адаептер - приемник уведомлений
    //Он принимает функцию, выполняет ее
    public class NotificationSink<T> : IObserver<T>
    {
        private Action<object, T> action;

        public NotificationSink(Action<object, T> action)
        {
            this.action = action;
        }
        public void Update(object sender, T data)
        {
            this.action(sender, data);
        }
    }
    //30. Меняем класс обозревателя полностью
    //prev. public class ConcreteObderver1 : IObserver
    //{
    //    public void AfterDoSomethingWith(ISubject sender, string data)
    //    {
    //        Console.WriteLine("ConcreteObserver1 AfterDoSomethingWith() method called {0}", data.ToUpper());
    //    }
    //    public void AfterDoMore(ISubject sender, string completeData, string appendedData)
    //    {
    //    }
    //}
    public class ConcreteObserver1
    {
        public readonly IObserver<string> AfterDoSomethingWith;

        public ConcreteObserver1()
        {
            this.AfterDoSomethingWith = new NotificationSink<string>(this.AfterDoSomethingWithHandler);
        }

        private void AfterDoSomethingWithHandler(object sender, string data)
        {
            Console.WriteLine("ConcreteObserver1 AfterDoSomethingWith() method called {0}", data.ToUpper());
        }
    }
    //31. Меняем класс обозревателя полностью
    //prev. public class ConcreteObderver2 : IObserver
    //prev. {
    //prev.     public void AfterDoSomethingWith(ISubject sender, string data)
    //prev.     {
    //prev.         Console.WriteLine("ConcreteObserver2 AfterDoSomethingWith() method called {0}", data.ToUpper());
    //prev.     }
    //prev.     public void AfterDoMore(ISubject sender, string completeData, string appendedData)
    //prev.     {
    //prev.         Console.WriteLine("ConcreteObserver2 AfterDoMore() method called {0}", appendedData.ToUpper());
    //prev.     }
    //prev. }
    public class ConcreteObserver2
    {
        public readonly IObserver<string> AfterDoSomethingWith;
        public readonly IObserver<Tuple<string, string>> AfterDoMore;

        public ConcreteObserver2()
        {
            this.AfterDoSomethingWith =
                new NotificationSink<string>(this.AfterDoSomethingWithHandler);
            this.AfterDoMore =
                new NotificationSink<Tuple<string, string>>(this.AfterDoMoreHandler);
        }
        private void AfterDoSomethingWithHandler(object sender, string data)
        {
            Console.WriteLine("ConcreteObserver2 AfterDoSomethingWith() method called {0}", data.ToUpper());
        }
        private void AfterDoMoreHandler(object sender, Tuple<string, string> tuple)
        {
            Console.WriteLine("ConcreteObserver2 AfterDoMore() method called {0}", tuple.Item1.ToUpper());
        }
    }
    //32. Меняем клиент
    public class Client
    {
        public void Main()
        {
            ConcreteSubject subj = new ConcreteSubject();
            ConcreteObserver1 co1 = new ConcreteObserver1();
            ConcreteObserver2 co2 = new ConcreteObserver2();
            subj.AfterDoSomethingWith = new MulticastNotifier<string>(
                new IObserver<string>[]
                {
                co1.AfterDoSomethingWith,
                co2.AfterDoSomethingWith
                });
            subj.AfterDoMore = new MulticastNotifier<Tuple<string, string>>(
                new IObserver<Tuple<string, string>>[]
                {
                    co2.AfterDoMore
                });


            subj.DoSomething("my data");
            subj.DoMore("tail");

        }
    }
    //Вывод 
    //ConcreteObserver1 AfterDoSomethingWith() method called MY DATA
    //ConcreteObserver2 AfterDoSomethingWith() method called MY DATA
    //ConcreteObserver2 AfterDoMore() method called MY DATA
}
