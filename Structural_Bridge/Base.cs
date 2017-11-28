using System;

namespace Structural_Bridge.Base
{
    public class Client
    {
        static void Main()
        {
            Abstraction abstraction = new RefinedAbstraction(new ConcreteImplementorA());
            abstraction.Operation();

            abstraction = new RefinedAbstraction(new ConcreteImplementorB());
            abstraction.Operation();
        }
    }

    //Отделяем абстракцию от реализации
    public abstract class Abstraction
    {
        protected Implementor implementor;

        protected Abstraction(Implementor implementor)
        {
            this.implementor = implementor;
        }
        public virtual void Operation()
        {
            implementor.OperationImp();
        }
    }

    public abstract class Implementor
    {
        public abstract void OperationImp();
    }


    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor imp) : base(imp)
        {
            
        }
        public override void Operation()
        {
            //...Какая-то имплементация
            base.Operation();
            Console.WriteLine("///");
        }
    }
    class ConcreteImplementorA: Implementor
    {
        public override void OperationImp()
        {
            //Какая-то имплементация А
        }
    }
    class ConcreteImplementorB : Implementor
    {
        public override void OperationImp()
        {
            //Какая-то имплементация B
        }
    }
}
