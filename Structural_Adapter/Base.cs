using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Adapter.Base
{
    public class SqlServerLogSaverAdapter : ILogSaver
    {
        private readonly SqlServerLogSaver _sqlServerLogSaver = new SqlServerLogSaver();

        //Метод с подходящим интерфейсом
        public void Save(LogEntry logEntry)
        {
            //Реализация адаптера
            var simpleEntry = logEntry as SimpleLogEntry;
            if (simpleEntry != null)
            {
                _sqlServerLogSaver.Save(simpleEntry.EntryDateTime, simpleEntry.Severity.ToString(),
                    simpleEntry.Message);
                return;
            }
        }
    }

    public class SimpleLogEntry : LogEntry
    {
        public DateTime EntryDateTime { get; set; }
        public Severity Severity { get; set; }
        public string Message { get; set; }
    }

    internal class SqlServerLogSaver
    {
        //Метод с неподходящим интерфейсом
        internal void Save(DateTime entryDateTime, string severity, string Message)
        {
        }
    }

    public interface ILogSaver
    {
        void Save(LogEntry logEntry);
    }

    public class LogEntry
    {
    }

    public class Severity
    {
    }
}