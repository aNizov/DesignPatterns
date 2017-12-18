using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Command.Base
{
    public class Client
    {
        static void Main()
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();
             
            invoker.StoreCommand(command);
            invoker.ExecuteCommand();
        }
    }
    // "Command"
    abstract class Command
    {
        protected Receiver receiver;

        protected Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }
    class Invoker
    {
        Command command;

        public void StoreCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Receiver");
        }
    }
}
