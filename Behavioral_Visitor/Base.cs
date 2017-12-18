using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Visitor.Base
{
    public class Client
    {
        static void Main()
        {
            ObjectStructure structure = new ObjectStructure();

            structure.Add(new ElementA());
            structure.Add(new ElementB());

            structure.Accept(new ConcreteVisitor());

        }
    }
    class ObjectStructure
    {
        // Подчеркиваетсяя гетерогенность.
        ArrayList elements = new ArrayList();

        public void Add(Element element)
        {
            elements.Add(element);
        }

        public void Remove(Element element)
        {
            elements.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (Element element in elements)
                element.Accept(visitor);
        }
    }
    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
        public string SomeState { get; set; }
    }
    class ElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementA(this);
        }

        public void OperationA()
        {
            Console.WriteLine("OperationA");
        }
    }
    class ElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementB(this);
        }

        public void OperationB()
        {
            Console.WriteLine("OperationB");
        }
    }
    abstract class Visitor
    {
        public abstract void VisitElementA(ElementA elementA);
        public abstract void VisitElementB(ElementB elementB);
    }
    class ConcreteVisitor : Visitor
    {
        public override void VisitElementA(ElementA elementA)
        {
            // Код который мог быть размещен в классе ElementA,
            // расширяет собой класс ElementA.
            elementA.SomeState = "State A";
            Console.WriteLine(elementA.SomeState);

            // Работа с разнородным интерфейсом.
            elementA.OperationA();
        }

        public override void VisitElementB(ElementB elementB)
        {
            // Код который мог быть размещен в классе ElementB,
            // расширяет собой класс ElementB.
            elementB.SomeState = "State B";
            Console.WriteLine(elementB.SomeState);

            // Работа с разнородным интерфейсом.
            elementB.OperationB();
        }
    }

}
