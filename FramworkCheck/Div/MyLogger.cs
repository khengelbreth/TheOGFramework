using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramworkCheck.Div
{
    public class MyLogger
    {
        private static readonly Lazy<MyLogger> instance = new Lazy<MyLogger>(() => new MyLogger());
        private TraceSource traceSource;
        private const string logName = "MyLog";

        private MyLogger()
        {
            traceSource = new TraceSource(logName);
            traceSource.Switch = new SourceSwitch("MySwitch", SourceLevels.Information.ToString());

            // Configure listeners
            traceSource.Listeners.Add(new ConsoleTraceListener());
            traceSource.Listeners.Add(new TextWriterTraceListener($"{logName}.txt")
            {
                Filter = new EventTypeFilter(SourceLevels.Error)
            });

            traceSource.Listeners.Add(new EventLogTraceListener("Application"));

        }

        public static MyLogger Instance => instance.Value;

        public void LogInfo(string message)
        {
            traceSource.TraceEvent(TraceEventType.Information, 0, message);
        }

        public void LogWarning(string message)
        {
            traceSource.TraceEvent(TraceEventType.Warning, 0, message);
        }

        public void LogError(string message)
        {
            traceSource.TraceEvent(TraceEventType.Error, 0, message);
        }

        public void LogCritical(string message)
        {
            traceSource.TraceEvent(TraceEventType.Critical, 0, message);
        }

        public void Close()
        {
            traceSource.Close();
        }
    }
}
