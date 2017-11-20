using System.Reflection;
using System.Runtime.ExceptionServices;

namespace GaranteedVirtalMethodInvokation
{
    //Поное описание необходимо посмотреть в книге Теплякова Паттерны проектирование стр 152.
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
}
