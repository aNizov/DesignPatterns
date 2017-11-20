using FactoryMethod.Implementations;
using FactoryMethod.Interfaces;

//Основа всех пораждающих паттернов
namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new Factory();
            IProduct product = factory.GetInstance();
            product.SomeMethod();
        }
    }
}
