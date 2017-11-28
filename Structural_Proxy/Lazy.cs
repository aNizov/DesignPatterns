using System;

namespace Structural_Proxy.Lazy
{
    public interface IHeavyweight
    {
        void Foo();
    }
    // Стоимость создания класса очень высока
    public class Heavyweight : IHeavyweight
    {
        public void Foo()
        { }
    }
    // Виртуальный заместитель, который будет создавать
    // тяжеловесный объект лишь при необходимости
    public class HeavyweightProxy : IHeavyweight
    {
        private readonly Lazy<Heavyweight> _lazy = new Lazy<Heavyweight>();
        public void Foo()
        {
            _lazy.Value.Foo();
        }
    }
}
