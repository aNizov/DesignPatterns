using System;
using System.Collections.Generic;

//Определяет поставщика push-уведомлений.
//IObservable<T> - поставщик - класс, который отправляет уведомления
//IObserver<T> - наблюдатель - класс, который получает уведомления 
//T Представляет класс, который предоставляет сведения об уведомлении
namespace Behavioral_Observer.IObservable
{
    //Location класс, содержащий данные широты и долготы.
    public struct Location
    {
        private readonly double _lat;
        private readonly double _lon;

        public Location(double latitude, double longitude)
        {
            _lat = latitude;
            _lon = longitude;
        }

        public double Latitude => _lat;

        public double Longitude => _lon;
    }

    //РЕАЛИЗАЦИЯ ПОСТАЩИКА
    //Предоставляет реализвцию IObservable<T>
    public class LocationTracker : IObservable<Location>
    {
        private readonly List<IObserver<Location>> _observers;

        public LocationTracker()
        {
            _observers = new List<IObserver<Location>>();
        }

        //Единственный метод интерфейса IObservable<Location>
        //вызывая этот метод, наблюдатели регистрируются на получение уведомления  от LocationTracker 
        //который в свою очередь, сохраняет ссылку на экземпляр наблюдателя в списке
        public IDisposable Subscribe(IObserver<Location> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }

        //Реализоанный IDisposable в данном классе позволяет наблюдателям остановить получение уведомлений
        private class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<Location>> _observers;
            private readonly IObserver<Location> _observer;

            public Unsubscriber(List<IObserver<Location>> observers, IObserver<Location> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
        //TrackLocation оповещает каждого подписавшегося наблюдателя, через вызов OnNext на каждом экземпляре наблюдателя
        //если loc!=null он вызывает метод OnError - куда передает исключение
        public void TrackLocation(Location? loc)
        {
            foreach (var observer in _observers)
            {
                if (!loc.HasValue)
                    observer.OnError(new LocationUnknownException());
                else
                    observer.OnNext(loc.Value);
            }
        }
        //Данный метод вызывает метод OnCompleted на каждом из наблюдателей,
        //когда список Location пройден
        public void EndTransmission()
        {
            foreach (var observer in _observers.ToArray())
                if (_observers.Contains(observer))
                    observer.OnCompleted();
            //список наблюдателей очищается
            _observers.Clear();
        }
    }
    public class LocationUnknownException : Exception
    {
        internal LocationUnknownException()
        {
        }
    }

    //РЕАЛИЗВЦИЯ НАБЛЮДАТЕЛЯ
    //Предоставляет реализвцию IObservable<T>
    public class LocationReporter : IObserver<Location>
    {
        private IDisposable _unsubscriber;

        public LocationReporter(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public virtual void Subscribe(IObservable<Location> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }
        public virtual void OnCompleted()
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", Name);
            Unsubscribe();
        }
        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: The location cannot be determined.", Name);
        }
        public virtual void OnNext(Location value)
        {
            Console.WriteLine("{2}: The current location is {0}, {1}", value.Latitude, value.Longitude, Name);
        }
        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }

    //ДЕМО
    class Client
    {
        static void Main()
        {
            // ПОСТАВЩИК и 2 НАБЛЮДАТЕЛЯ
            LocationTracker provider = new LocationTracker();
            LocationReporter reporter1 = new LocationReporter("FixedGPS");
            reporter1.Subscribe(provider);
            LocationReporter reporter2 = new LocationReporter("MobileGPS");
            reporter2.Subscribe(provider);

            provider.TrackLocation(new Location(47.6456, -122.1312));
            reporter1.Unsubscribe();
            provider.TrackLocation(new Location(47.6677, -122.1199));
            provider.TrackLocation(null);
            provider.EndTransmission();
        }
    }
    // Результат:
    //      FixedGPS: The current location is 47.6456, -122.1312
    //      MobileGPS: The current location is 47.6456, -122.1312
    //      MobileGPS: The current location is 47.6677, -122.1199
    //      MobileGPS: The location cannot be determined.
    //      The Location Tracker has completed transmitting data to MobileGPS.
}