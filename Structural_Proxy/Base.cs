using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Proxy.Base
{
    //Декоратор добавляет поведение всем методам интерфейса, позволяя нанизывать
    //расширения одно на другое.Класс-заместитель может выполнять определенные
    //действия, например создавать настоящий компонент по мере необходимости, но
    //он не должен ничего подмешивать в результаты исполнения операции.
    public class Client
    {
        public void Main()
        {
            IProduct product = new Product();
            IProduct proxy = new ProductProxy(product);
            proxy.Operation();
        }
    }

    public interface IProduct
    {
        SomeResult Operation();
    }
    public class Product:IProduct
    {
        public SomeResult Operation()
        {
            return new SomeResult();
        }
    }
    public class ProductProxy: IProduct
    {
        private readonly IProduct _product;
        public ProductProxy(IProduct product)
        {
            _product = product;
        }
        public SomeResult Operation()
        {
            //Какая-то дополнительная логика
            //...
            //Класс ProductProxy должен возвращать тот же результат, что и Product
            return _product.Operation();
            //Возможно даже такое:
            //return new SomeResult();
        }
    }

    public class SomeResult
    {
        //...
    }
}
