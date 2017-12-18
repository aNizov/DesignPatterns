using System.Collections.Generic;
using System.Linq;

namespace Behavioral_Template_Method.Base
{
    public abstract class LogReader
    {
        private int _currentPosition;

        public IEnumerable<LogEntry> ReadLogEntry()
        {
            return ReadEntries(ref _currentPosition).Select(ParseLogEntry);
        }

        protected abstract IEnumerable<string> ReadEntries(ref int position);
        protected abstract LogEntry ParseLogEntry(string stringEntry);
    }

    public class LogEntry
    {
        //Контейнер для логов
    }
}
