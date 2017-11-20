using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Template_Method
{
    public abstract class LogEntryBase
    {
        public DateTime EntryDateTime { get; internal set; }
        public Severity Severity { get; internal set; }
        public string Message { get; internal set; }
        public string AdditionalInformation { get; set; }
    }

    public static class LogEntryBaseEx
    {
        public static string GetText(this LogEntryBase logEntry)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[{0}] ", logEntry.EntryDateTime)
                .AppendFormat("[{0}]", logEntry.Severity)
                .AppendLine(logEntry.Message)
                .AppendLine(logEntry.AdditionalInformation);
            return sb.ToString();
        }

    }
    public class Severity
    {
        //затычка
    }
}
