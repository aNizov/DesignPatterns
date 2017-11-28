using System;

namespace Structural_Flyweight.Base
{
    public class Client
    {
        //Смысл паттерна - вместо экземпляра какого-то класса использовать какой-то прототип и выполнять методы на нем
        public void Main()
        {
            UnsharedConcreteFlyweight prototype = new UnsharedConcreteFlyweight();

            SharedConcreteFlyWeight cl1 = new SharedConcreteFlyWeight(prototype);
            cl1.SomeMetod("some method in clone 1");

            AnotherSharedeConcreteFlyweight cl2 = new AnotherSharedeConcreteFlyweight(prototype);
            cl2.SomeMetod("some method in clone 2");
        }
    }
    public abstract class FlyWeight
    {
        public abstract void SomeMetod(string param);
    }
    public class UnsharedConcreteFlyweight : FlyWeight
    {
        public override void SomeMetod(string param)
        {
            //какая-то реализация прототипа
            throw new NotImplementedException();
        }
    }

    public class SharedConcreteFlyWeight : FlyWeight
    {
        private FlyWeight _fw;

        public SharedConcreteFlyWeight(FlyWeight fw)
        {
            _fw = fw;
        }

        public override void SomeMetod(string param)
        {
            _fw.SomeMetod(param);
        }
    }
    public class AnotherSharedeConcreteFlyweight : FlyWeight
    {
        private FlyWeight _fw;

        public AnotherSharedeConcreteFlyweight(FlyWeight fw)
        {
            _fw = fw;
        }

        public override void SomeMetod(string param)
        {
            _fw.SomeMetod(param);
        }
    }
}
