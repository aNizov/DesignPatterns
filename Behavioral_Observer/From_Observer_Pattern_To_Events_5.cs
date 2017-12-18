using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ПРЕДЫДУЩАЯ РЕАЛИЗАЦИЯ ОЧЕНЬ СЛОЖНАЯ - ЕЕ НАДО НЕМНОГО УПРОСТИТЬ
namespace Behavioral_Observer.From_Observer_Pattern_To_Events_5
{
    public interface IObserver<T>
    {
        void Update(object sender, T data);
    }
    public class MulticastNotifier<T>
    {
        private readonly IList<IObserver<T>> invocationList;

        //35. Данный конструктор нигде не используется поэтому удаляем его
        //prev. public MulticastNotifier(IEnumerable<IObserver<T>> observers)
        //prev. {
        //prev.     this.invocationList = new List<IObserver<T>>(observers);
        //prev. }

        //33. Добавим еще один закрытый конструктор, который принимает одного наблюдателя
        private MulticastNotifier(IObserver<T> observer)
        {
            this.invocationList = new List<IObserver<T>> { observer };
        }
        //34. И еще 1 закрытый конструктор, добавляюший наблюдателя к списку наблюдателей
        private MulticastNotifier(MulticastNotifier<T> notifier, IObserver<T> observer)
        {
            this.invocationList = new List<IObserver<T>>(notifier.invocationList) { observer };
        }
        public void Notify(object sender, T data)
        {
            foreach (IObserver<T> observer in this.invocationList)
                observer.Update(sender, data);
        }
        //32. ХИТРОСТЬ! Добавим метод перегрузки оператора + при работе с данным классом
        public static MulticastNotifier<T> operator +(MulticastNotifier<T> notifier, IObserver<T> observer)
        {
            if (notifier == null) return new MulticastNotifier<T>(observer);
            return new MulticastNotifier<T>(notifier, observer);
        }
    }
    public class ConcreteSubject
    {
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
    }
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
    public class Client
    {
        public void Main()
        {
            ConcreteSubject subj = new ConcreteSubject();
            ConcreteObserver1 co1 = new ConcreteObserver1();
            ConcreteObserver2 co2 = new ConcreteObserver2();
            
            //36. Теперь меняем синтексис с учетом перегруженного оператора
            //КРАСОТА!!!!
            //prev. subj.AfterDoSomethingWith = new MulticastNotifier<string>(
            //prev.     new IObserver<string>[]
            //prev.     {
            //prev.     co1.AfterDoSomethingWith,
            //prev.     co2.AfterDoSomethingWith
            //prev.     });
            //prev. subj.AfterDoMore = new MulticastNotifier<Tuple<string, string>>(
            //prev.     new IObserver<Tuple<string, string>>[]
            //prev.     {
            //prev.         co2.AfterDoMore
            //prev.     });
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
