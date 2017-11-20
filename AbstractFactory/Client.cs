using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Frame;

namespace AbstractFactory
{
    //Самый важный класс паттерна, на самом деле, 
    //реализующий идею связывания разных классов через абстрактные интерфесы
    public class Client
    {
        private readonly IFirstItem _firstItem;
        private readonly ISecondItem _secondItem;
        private readonly IThirdItem _thirdItem;

        public Client(IFactory factory)
        {
            _firstItem = factory.CreateFirstItem();
            _secondItem = factory.CreateSecondItem();
            _thirdItem = factory.CreaThirdItem();
        }

        //А здесь абстрактно представлена вся реализация.
        //Соответственно, запилив конкретную фабрику, реализующую интерфейс IFactory
        //и возвращающую конкретный типы, реализующие интерфейсы IFirstItem, ISecondItem, IThirdItem
        //можно подавать ее в конструктор класса Client и все будет прекрасно работать
        //без изменения класса Client, т.е. без изменения реализации метода Run()
        //т.е. результат выполнения метода Run() будет зависить от конкретной фабрики,
        //получается мы изменяем результат без изменения поведения.
        public void Run()
        {
            _firstItem.SomeMethod11();
            _firstItem.SomeMethod12();
            _secondItem.SomeMethod21();
            _secondItem.SomeMethod22();
            _thirdItem.SomeMethod31();
            _thirdItem.SomeMethod32();
        }
    }
}
