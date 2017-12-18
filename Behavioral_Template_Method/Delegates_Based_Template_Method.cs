using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Template_Method.Delegates_Based
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface ILogSaver
    {
        void UploadLogEntries(IEnumerable<LogEntry> logEntries);
        void UploadExeptions(IEnumerable<ExceptionLogEntry> exeptions);
    }

    class LogSaverProxy : ILogSaver
    {
        class LogSaverClient : ClientBased<ILogSaver>
        {
            public ILogSaver LogSaver => Channel;


        }
        public void UploadLogEntries(IEnumerable<LogEntry> logEntries)
        {
            throw new NotImplementedException();
        }

        public void UploadExeptions(IEnumerable<ExceptionLogEntry> exeptions)
        {
            throw new NotImplementedException();
        }

        private void UseProxyClient(Action<ILogSaver> accessor)
        {
            var client = new LogSaverClient();
            try
            {
                accessor(client.LogSaver);
                client.Close();
            }
            catch (CommunicationExeption e)
            {
                client.Abort();
                Console.WriteLine(e);
                throw new OperationFailedExeption(e);
            }
        }

    }

    internal class OperationFailedExeption : Exception
    {
        public OperationFailedExeption(CommunicationExeption communicationExeption)
        {
            throw new NotImplementedException();
        }
    }

    internal class CommunicationExeption : Exception
    {
    }

    internal class ClientBased<T>
    {
        public ILogSaver Channel;
        public void Close()
        {
        }
        public void Abort() { }


    }

    internal class ExceptionLogEntry
    {
    }

}
