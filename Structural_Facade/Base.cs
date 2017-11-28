using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Facade.Base
{
    public class Client
    {
        private Facade _facade;

        public void Main()
        {
            //Работа с подсистемами 1,2,3,4 через фасад
            _facade = new Facade();
            _facade.MethodA();
            _facade.MethodB();

            //Работа с подсистемой напрямую без фасада
            SubSystem3 three = _facade.Three;
            three.Method3();

        }
    }

    //Добавляет определенный уровень абстракции при работе с подсистемой
    public class Facade
    {
        private readonly SubSystem1 _one;
        private readonly SubSystem2 _two;
        private readonly SubSystem3 _three;
        private readonly SubSystem4 _four;

        public Facade()
        {
            _one = new SubSystem1();
            _two = new SubSystem2();
            _three = new SubSystem3();
            _four = new SubSystem4();
        }

        public void MethodA()
        {
            _one.Method1();
            _two.Method2();
            _three.Method3();
            _four.Method4();
        }

        public void MethodB()
        {
            _four.Method4();
            _three.Method3();
            _two.Method2();
            _one.Method1();
        }

        public SubSystem1 One => _one;
        public SubSystem2 Two => _two;
        public SubSystem3 Three => _three;
        public SubSystem4 Four => _four;
    }

    //КЛАССЫ ПОДСИСТЕМ НЕ ХРАНЯТ ССЫЛОК НА ФАСАД!!!!!!!!!!!!
    public class SubSystem1
    {
        public void Method1()
        {
        }
    }

    public class SubSystem2
    {
        public void Method2()
        {
        }
    }

    public class SubSystem3
    {
        public void Method3()
        {
        }
    }

    public class SubSystem4
    {
        public void Method4()
        {
        }
    }
}