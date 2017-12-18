using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ФИНАЛЬНАЯ ТРАНСФОРМАЦИЯ В .NET Events
namespace Behavioral_Observer.From_Observer_Pattern_To_Events_6
{
    //41. Теперь этот класс больше не нужен
    //prev. public interface IObserver<T>
    //prev. {
    //prev.     void Update(object sender, T data);
    //prev. }

    //43. Этот класс тоже удаляется
    //public class MulticastNotifier<T>
    //{
    //    private readonly IList<IObserver<T>> invocationList;

    //    private MulticastNotifier(IObserver<T> observer)
    //    {
    //        this.invocationList = new List<IObserver<T>> { observer };
    //    }
    //    private MulticastNotifier(MulticastNotifier<T> notifier, IObserver<T> observer)
    //    {
    //        this.invocationList = new List<IObserver<T>>(notifier.invocationList) { observer };
    //    }
    //    public void Notify(object sender, T data)
    //    {
    //        foreach (IObserver<T> observer in this.invocationList)
    //            observer.Update(sender, data);
    //    }
    //    public static MulticastNotifier<T> operator +(MulticastNotifier<T> notifier, IObserver<T> observer)
    //    {
    //        if (notifier == null) return new MulticastNotifier<T>(observer);
    //        return new MulticastNotifier<T>(notifier, observer);
    //    }
    //}
    public class ConcreteSubject
    {
        private string data = string.Empty;

        //37. Меняем тип MulticastNotifier на event с его базовым перехватчиком EventHandler
        //prev. public MulticastNotifier<string> AfterDoSomethingWith;
        //prev. public MulticastNotifier<Tuple<string, string>> AfterDoMore;
        public event EventHandler<string> AfterDoSomethingWith;
        public event EventHandler<Tuple<string, string>> AfterDoMore;

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
            //38. Больше нет смысла вызывать метод Notify - за нас это сделает компилятор
            AfterDoSomethingWith?.Invoke(this,data);
        }
        private void OnAfterDoMore(string completeData, string appendedData)
        {
            //38. Больше нет смысла вызывать метод Notify - за нас это сделает компилятор
            AfterDoMore?.Invoke(this, Tuple.Create(completeData, appendedData));
        }
    }
    //42. И этот класс тоже
    //prev.public class NotificationSink<T> : IObserver<T>
    //prev.{
    //prev.    private readonly Action<object, T> action;
    //prev.
    //prev.    public NotificationSink(Action<object, T> action)
    //prev.    {
    //prev.        this.action = action;
    //prev.    }
    //prev.    public void Update(object sender, T data)
    //prev.    {
    //prev.        this.action(sender, data);
    //prev.    }
    //prev.}
    public class ConcreteObserver1
    {
        //39. В этом тоже больше нет необходимости
        //prev.public readonly IObserver<string> AfterDoSomethingWith;
        //prev.
        //prev.public ConcreteObserver1()
        //prev.{
        //prev.    this.AfterDoSomethingWith = new NotificationSink<string>(this.AfterDoSomethingWithHandler);
        //prev.}

        //40. Меняем модификатор доступа и название
        //prev. private void AfterDoSomethingWithHandler(object sender, string data)
        public void AfterDoSomethingWith(object sender, string data)
        {
            Console.WriteLine("ConcreteObserver1 AfterDoSomethingWith() method called {0}", data.ToUpper());
        }
    }
    public class ConcreteObserver2
    {
        //39. В этом тоже больше нет необходимости
        //prev.public readonly IObserver<string> AfterDoSomethingWith;
        //prev.public readonly IObserver<Tuple<string, string>> AfterDoMore;
        //prev.
        //prev.public ConcreteObserver2()
        //prev.{
        //prev.    this.AfterDoSomethingWith =
        //prev.        new NotificationSink<string>(this.AfterDoSomethingWithHandler);
        //prev.    this.AfterDoMore =
        //prev.        new NotificationSink<Tuple<string, string>>(this.AfterDoMoreHandler);
        //prev.}

        //40. Меняем модификатор доступа  и название
        //prev. private void AfterDoSomethingWithHandler(object sender, string data)
        public void AfterDoSomethingWith(object sender, string data)
        {
            Console.WriteLine("ConcreteObserver2 AfterDoSomethingWith() method called {0}", data.ToUpper());
        }
        //40. Меняем модификатор доступа и название
        //prev. private void AfterDoMoreHandler(object sender, Tuple<string, string> tuple)
        public void AfterDoMore(object sender, Tuple<string, string> tuple)
        {
            Console.WriteLine("ConcreteObserver2 AfterDoMore() method called {0}", tuple.Item1.ToUpper());
        }
    }
    public class Client
    {
        public void Main()
        {
            ConcreteSubject subj = new ConcreteSubject();
            ConcreteObserver1 co1 = new ConcreteObserver1();
            ConcreteObserver2 co2 = new ConcreteObserver2();

            //САМОЕ УДИВИТЕЛЬНОЕ, ЧТО ЗДЕСЬ НИЧЕГО МЕНЯТЬ НЕ НУЖНО.
            subj.AfterDoSomethingWith += co1.AfterDoSomethingWith;
            subj.AfterDoSomethingWith += co2.AfterDoSomethingWith;
            subj.AfterDoMore += co2.AfterDoMore;

            subj.DoSomething("my data");
            subj.DoMore("tail");

        }
    }
    //Вывод 
    //ConcreteObserver1 AfterDoSomethingWith() method called MY DATA
    //ConcreteObserver2 AfterDoSomethingWith() method called MY DATA
    //ConcreteObserver2 AfterDoMore() method called MY DATA
}
