using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Decorator.Log_Saver_Decorator
{
    public class Client
    {
        public void Main()
        {
            ILogSaver logSaver = new ThrottlingLogSaverDecorator(
                new ElasticSearchLogSaver());
                //Декораторов может быть несколько
                //и они будут вложены друг в друга
        }
    }
    public interface ILogSaver
    {
        Task SaveLogEntry(string applicationId, LogEntry logEntry);
    }

    //Класс запечатан, т.е. добавить новую функциональность с помощью наследования не выйдет
    public sealed class ElasticSearchLogSaver : ILogSaver
    {
        public Task SaveLogEntry(string applicationId, LogEntry logEntry)
        {
            //Сохраняем переданую запись в Elastich search
            return Task.FromResult<object>(null);
        }
    }

    public abstract class LogSaverDecorator : ILogSaver
    {
        protected readonly ILogSaver _decoratee;

        protected LogSaverDecorator(ILogSaver decoratee)
        {
            _decoratee = decoratee;
        }

        public abstract Task SaveLogEntry(string applicationId, LogEntry logEntry);
    }

    //Реализация декоратора для добавления LogSaverDecorator дополнительно функциональности
    public class ThrottlingLogSaverDecorator : LogSaverDecorator
    {
        public ThrottlingLogSaverDecorator(ILogSaver decoratee) : base(decoratee)
        {
        }

        public override async Task SaveLogEntry(string applicationId, LogEntry logEntry)
        {
            //добавление новой функциональности
            if (!QuotaReached(applicationId))
            {
                IncrementUsedQuata();
                //вызов базового метода
                await _decoratee.SaveLogEntry(applicationId, logEntry);
                return;
            }
        }
        //новая функциональность
        private bool QuotaReached(string applicationId)
        {
            //какая реализация
            return true;
        }
        //еще новая функциональность
        private bool IncrementUsedQuata()
        {
            //....
            return true;
        }
    }

    public class LogEntry
    {
    }
}