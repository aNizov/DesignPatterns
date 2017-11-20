using System;
using Builder.Interfaces;

namespace Builder.Implementation1
{
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
}
