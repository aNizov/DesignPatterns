namespace Creational_Abstract_Factory
{
    //Класс-пользователь абстрактоной фабрики
    public class Program
    {
        public void Main()
        {
            Client client = new Client(new Factory1());
            client.Run();

            client = new Client(new Factory2());
            client.Run();
        }

    }
}