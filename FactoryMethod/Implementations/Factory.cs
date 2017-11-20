using FactoryMethod.Interfaces;

namespace FactoryMethod.Implementations
{
    internal class Factory : IFactory
    {
        public IProduct GetInstance()
        {
            return new Product();
        }
    }
}
