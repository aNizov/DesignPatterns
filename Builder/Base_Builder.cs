using System;

namespace Builder
{
    class Program
    {
        static void Main()
        {
            IBuilder builder1 = new Builder1();
            Foreman foreman1 = new Foreman(builder1);
            foreman1.Construct();
            builder1.GetResult();

            Console.WriteLine(new string('-', 50));

            IBuilder builder2 = new Builder2();
            Foreman foreman2 = new Foreman(builder2);
            foreman2.Construct();
            builder2.GetResult(); // По идее метод должен возвращать сконструированный тип, но я это упустил для простоты
        }
    }
    public class Foreman
    {
        private IBuilder _builder;

        public Foreman(IBuilder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.InitializeFirstItem();
            _builder.InitializeSecondItem();
            _builder.InitializeThirdItem();

            _builder.GetResult();
        }

    }
    public interface IBuilder
    {
        void InitializeFirstItem();
        void InitializeSecondItem();
        void InitializeThirdItem();

        void GetResult();
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
    class Builder1 : IBuilder
    {
        private IFirstItem _firstClass;
        private ISecondItem _secondClass;
        private IThirdItem _thirdClass;

        public void InitializeFirstItem()
        {
            _firstClass = new FirstClass1();
        }

        public void InitializeSecondItem()
        {
            _secondClass = new SecondClass1();
        }

        public void InitializeThirdItem()
        {
            _thirdClass = new ThirdClass1();
        }

        public void GetResult()
        {
            _firstClass.SomeMethod11();
            _firstClass.SomeMethod12();
            _secondClass.SomeMethod21();
            _secondClass.SomeMethod22();
            _thirdClass.SomeMethod31();
            _thirdClass.SomeMethod32();
        }
    }
    class Builder2 : IBuilder
    {
        private IFirstItem _firstClass;
        private ISecondItem _secondClass;
        private IThirdItem _thirdClass;

        public void InitializeFirstItem()
        {
            _firstClass = new FirstClass2();
        }

        public void InitializeSecondItem()
        {
            _secondClass = new SecondClass2();
        }

        public void InitializeThirdItem()
        {
            _thirdClass = new ThirdClass2();
        }

        public void GetResult()
        {
            _firstClass.SomeMethod11();
            _firstClass.SomeMethod12();
            _secondClass.SomeMethod21();
            _secondClass.SomeMethod22();
            _thirdClass.SomeMethod31();
            _thirdClass.SomeMethod32();
        }
    }
    public class FirstClass1 : IFirstItem
    {
        public void SomeMethod11()
        {
            Console.WriteLine("implementation 1 of method 11");
        }

        public void SomeMethod12()
        {
            Console.WriteLine("implementation 1 of method 12");
        }
    }
    public class SecondClass1 : ISecondItem
    {
        public void SomeMethod21()
        {
            Console.WriteLine("implementation 1 of method 21");
        }

        public void SomeMethod22()
        {
            Console.WriteLine("implementation 1 of method 22");
        }
    }
    public class ThirdClass1 : IThirdItem
    {
        public void SomeMethod31()
        {
            Console.WriteLine("implementation 1 of method 31");
        }

        public void SomeMethod32()
        {
            Console.WriteLine("implementation 1 of method 32");
        }
    }
    public class FirstClass2 : IFirstItem
    {
        public void SomeMethod11()
        {
            Console.WriteLine("implementation 2 of method 11");
        }

        public void SomeMethod12()
        {
            Console.WriteLine("implementation 2 of method 12");
        }
    }
    public class SecondClass2 : ISecondItem
    {
        public void SomeMethod21()
        {
            Console.WriteLine("implementation 2 of method 21");
        }

        public void SomeMethod22()
        {
            Console.WriteLine("implementation 2 of method 22");
        }
    }
    public class ThirdClass2 : IThirdItem
    {
        public void SomeMethod31()
        {
            Console.WriteLine("implementation 2 of method 31");
        }

        public void SomeMethod32()
        {
            Console.WriteLine("implementation 2 of method 32");
        }
    }
}
