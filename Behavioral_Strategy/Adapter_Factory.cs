using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Strategy.Adapter_Factory
{
    class Client
    {
        void Main()
        {
            var comparer = new EmployeeByIdComparer();

            // Конструктор принимает IComparable
            // у SortedSet нет конструктора, принимающего делегат Comparison<T>
            var set = new SortedSet<Employee>(comparer);

            //Используем адаптерную фабрику и все работает
            var anotherComparer = ComparerFactory.Create<Employee>((x, y) => x.Id.CompareTo(y.Id));
            var anotherSet = new SortedSet<Employee>(anotherComparer);
        }
    }

    //Адаптерный фабричный класс, принимающий делегат Comprasion<T>
    //и возвращающий IComparable<T>
    class ComparerFactory
    {
        public static IComparer<T> Create<T>(Comparison<T> comparer)
        {
            return new DelegateComparer<T>(comparer);
        }

        private class DelegateComparer<T> : IComparer<T>
        {
            private readonly Comparison<T> _comparer;

            public DelegateComparer(Comparison<T> comparer)
            {
                _comparer = comparer;
            }

            public int Compare(T x, T y)
            {
                return _comparer(x, y);
            }
        }
    }


    public class EmployeeByIdComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id={Id}, Name={Name}";
        }
    }
}
