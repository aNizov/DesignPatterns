using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Composite.Base
{
    public class Client
    {
        static void Main()
        {
            Component root = new Composite("ROOT");
            Component branch1 = new Composite("BR1");
            Component branch2 = new Composite("BR2");
            Component leaf1 = new Leaf("L1");
            Component leaf2 = new Leaf("L2");
            root.Add(branch1);
            root.Add(branch2);
            branch1.Add(leaf1);
            branch2.Add(leaf2);

            //Запускаем последовательность операций (рекурсивно)
            root.Operation();

        }
    }

    internal abstract class Component
    {
        protected string _name;
        protected Component(string name)
        {
            this._name = name;
        }
        public abstract void Operation();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);
    }

    internal class Leaf : Component
    {
        public Component Component { get; set; }
        public Leaf(string name) : base(name) { }
        public override void Operation()
        {
            throw new NotImplementedException();
        }
        public override void Add(Component component)
        {
            this.Component = component;
        }
        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
        public override Component GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }

    internal class Composite : Component
    {
        private readonly List<Component> _components;
        public Composite(string name) : base(name) { _components = new List<Component>(); }
        public override void Operation()
        {
            Console.WriteLine("name");
            foreach (var component in _components)
            {
                component.Operation();
            }
        }
        public override void Add(Component component)
        {
            this._components.Add(component);
        }
        public override void Remove(Component component)
        {
            this._components.Remove(component);
        }
        public override Component GetChild(int index)
        {
            return _components[index];
        }
    }
}
