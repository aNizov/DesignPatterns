using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Decorator.Base
{
    //Декоратор добавляет поведение всем методам интерфейса, позволяя нанизывать
    //расширения одно на другое.Класс-заместитель может выполнять определенные
    //действия, например создавать настоящий компонент по мере необходимости, но
    //он не должен ничего подмешивать в результаты исполнения операции.
    public class Client
    {
        public void Main()
        {
            Component component = new ConcreteClass();
            Decorator decoratorA = new ConcreteDecoratorA();
            Decorator decoratorB = new ConcreteDecoratorB();

            decoratorA.Component = component;
            decoratorB.Component = decoratorA;

            //Теперь благодаря декоратору вызвется переопределенный 
            //метод operation() с добавленной функциональностью
            //О клиенты будут работать с ним как раьше не замечаю дополнительно навешанного поведения
            decoratorB.Operation();
        }
    }

    public abstract class Component
    {
        public abstract void Operation();

    }

    public class ConcreteClass : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Operation in conreete class");
        }
    }

    public abstract class Decorator : Component
    {
        public Component Component { get; set; }

        public override void Operation()
        {
            Component?.Operation();
        }
    }
    //Добавление функциональности в существующий класс
    public class ConcreteDecoratorA:Decorator
    {
        private string addedState = "some state";

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Some state added...");
        }
    }
    //Добавление функциональности в существующий класс
    public class ConcreteDecoratorB : Decorator
    {
        private void AddedMethod()
        {
            Console.WriteLine("Some functionality added...");
        }

        public override void Operation()
        {
            base.Operation();
            AddedMethod();
        }
    }

}
