using System;
using System.Collections.Generic;
using System.IO;

namespace DelegateRealization
{
    public class LogReader
    {
        private readonly Func<Stream> _streamFactory;

        private LogReader(Func<Stream> streamFactory)
        {
            _streamFactory = streamFactory;
        }

        public static LogReader FromFile(string fileName)
        {
            return new LogReader(() => new FileStream(fileName, FileMode.Open));
        }

        public static LogReader FromStream(Stream stream)
        {
            return new LogReader(() => stream);
        }

        public IEnumerable<LogEntry> Read()
        {
            using (var stream = OpenLogSource())
            {
                using (var reader = new StreamReader(stream))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        yield return LogEntryParser.Parse(line);
                    }
                }
            }
        }
        private Stream OpenLogSource()
        {
            return _streamFactory();
        }
    }

    internal class LogEntryParser
    {
        internal static LogEntry Parse(string line)
        {
            throw new NotImplementedException();
        }
    }

    public class LogEntry
    {
    }
}
