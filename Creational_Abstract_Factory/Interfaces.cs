namespace Creational_Abstract_Factory
{
    public interface IFactory
    {
        IFirstItem CreateFirstItem();
        ISecondItem CreateSecondItem();
        IThirdItem CreaThirdItem();
    }
    public interface IFirstItem
    {
        void SomeMethod11();
        void SomeMethod12();
    }
    public interface ISecondItem
    {
        void SomeMethod21();
        void SomeMethod22();
    }
    public interface IThirdItem
    {
        void SomeMethod31();
        void SomeMethod32();
    }
}