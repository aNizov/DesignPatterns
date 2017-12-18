using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Memento.Base
{
    //Данный паттерн используется для временного храниения состояния
    public class Client
    {
        static void Main()
        {
            Originator originator = new Originator
            {
                State = "On"
            };

            CareTaker careTaker = new CareTaker
            {
                Memento = originator.CreateMemento()
            };
            originator.State = "Off";

            //Возвращается первичное состояние
            originator.SetMomento(careTaker.Memento);
        }
    }

    //ХОЗЯИН
    class Originator
    {
        public string State { get; set; }

        public void SetMomento(Memento memento)
        {
            State = memento.State;
        }

        public Memento CreateMemento()
        {
            return new Memento(State);
        }
    }

    //ПОСРЕДНИК
    class CareTaker
    {
        public Memento Memento { get; set; }
    }

    //ХРАНИТЕЛЬ
    class Memento
    {
        public string State { get; private set; }

        public Memento(string state)
        {
            this.State = state;
        }
    }
}