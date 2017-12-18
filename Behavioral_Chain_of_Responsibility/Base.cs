using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Chain_of_Responsibility.Base
{
    public class Client
    {
        static void Main()
        {
            Handler h1 = new ConcreeteHandler1();
            Handler h2 = new ConcreeteHandler2();

            h1.Successor = h2;
            h1.HandleRequest(1);
            h1.HandleRequest(2);
        }
    }

    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest(int request);
    }
    class ConcreeteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 1)
                Console.WriteLine("One");
            else
                Successor?.HandleRequest(request);
        }
    }
    class ConcreeteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 1)
                Console.WriteLine("Two");
            else
                Successor?.HandleRequest(request);
        }
    }
}
