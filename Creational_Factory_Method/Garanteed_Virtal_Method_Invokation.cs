using System;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Creational_Factory_Method.Garanted_Virtual_Method_Invokation
{
    class Program
    {
        static void Main()
        {
            var instance = Factory<ConcreeteProduct2>.Create();
            var anotherInstance = Factory<AnotherConcreeteProduct2>.Create();
        }
    }

    internal class Factory<T> where T : Product, new()
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
    public abstract class Product
    {
        protected internal abstract void SomeMethod();
    }

    public class ConcreeteProduct2 : Product
    {
        protected internal override void SomeMethod()
        {
            Console.WriteLine("Virtual method of concreete class processed...");
        }
    }
    public class AnotherConcreeteProduct2 : Product
    {
        protected internal override void SomeMethod()
        {
            Console.WriteLine("Virtual method of another concreete class processed...");
        }
    }
}
