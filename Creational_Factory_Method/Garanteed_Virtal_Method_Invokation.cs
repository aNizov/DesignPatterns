using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Creational_Factory_Method
{
    class Program2
    {
        static void Main()
        {
            var instance = Factory2<ConcreeteProduct2>.Create();
            var anotherInstance = Factory2<AnotherConcreeteProduct2>.Create();
        }
    }

    internal class Factory2<T> where T : Product2, new()
    {
        public static T Create()
        {
            try
            {
                var instance = new T();
                instance.SomeMethod();
                return instance;
            }
            catch (TargetInvocationException exception)
            {
                var edi = ExceptionDispatchInfo.Capture(exception.InnerException);
                edi.Throw();
                return default(T);
            }
        }
    }
    public abstract class Product2
    {
        protected internal abstract void SomeMethod();
    }

    public class ConcreeteProduct2 : Product2
    {
        protected internal override void SomeMethod()
        {
            Console.WriteLine("Virtual method of concreete class processed...");
        }
    }
    public class AnotherConcreeteProduct2 : Product2
    {
        protected internal override void SomeMethod()
        {
            Console.WriteLine("Virtual method of another concreete class processed...");
        }
    }
}
