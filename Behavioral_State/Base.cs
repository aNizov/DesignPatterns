using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Xml;
using System.Xml.Linq;

namespace Behavioral_State.Base
{

    public static class Client
    {
        public static void Main()
        {
            Context context = new Context(new ConcreeteStateA());
            context.Request();
            context.Request();
        }
    }

    class Context
    {
        public State State { get; set; }

        public Context(State state)
        {
            this.State = state;
        }
        public void Request()
        {
            this.State.Handle(this);
        }
    }

    abstract class State
    {
        public abstract void Handle(Context context);
    }
    class ConcreeteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreeteStateB();
        }
    }
    class ConcreeteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreeteStateA();
        }
    }
}
