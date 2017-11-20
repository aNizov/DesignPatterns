namespace Creational_Abstract_Factory
{
    public class Factory1 : IFactory
    {
        public IFirstItem CreateFirstItem()
        {
            return new FirstClass1();
        }

        public ISecondItem CreateSecondItem()
        {
            return new SecondClass1();
        }

        public IThirdItem CreaThirdItem()
        {
            return new ThirdClass1();
        }
    }
    public class Factory2 : IFactory
    {
        public IFirstItem CreateFirstItem()
        {
            return new FirstClass2();
        }

        public ISecondItem CreateSecondItem()
        {
            return new SecondClass2();
        }

        public IThirdItem CreaThirdItem()
        {
            return new ThirdClass2();
        }
    }
}