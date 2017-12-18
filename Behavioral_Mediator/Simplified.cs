using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Mediator.Simplified
{
    public class Client
    {
        private CollegueA _collegueA;
        private CollegueB _collegueB;
        private Mediator _med;

        public void Main()
        {
            _med = new Mediator(_collegueA, _collegueB);
            _med.DoSomethingComplex();
        }
    }

    public class Mediator
    {

        private CollegueA _collegueA;
        private CollegueB _collegueB;

        public Mediator(CollegueA collegueA, CollegueB collegueB)
        {
            _collegueA = collegueA;
            _collegueB = collegueB;
        }
        //Если классы CollegueA и CollegueB отвечают за какиу-то автономную логику, то они не должны знать друг о друге
        //С ними должен работать класс-посредник
        public void DoSomethingComplex()
        {
            _collegueA.DoSomethingAutonomous();
            _collegueB.DoSomethingAutonomous();
        }
    }

    public class CollegueA
    {
        public void DoSomethingAutonomous() { }
    }
    public class CollegueB
    {
        public void DoSomethingAutonomous() { }
    }
}
