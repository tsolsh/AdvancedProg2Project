
using ImageService.Logging.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;

namespace ImageService.Logging
{
    public class LoggingService : ILoggingService
    {
        private System.Diagnostics.EventLog eventLog1;

        public event EventHandler<MessageRecievedEventArgs> MessageRecieved;
        public void Log(string message, MessageTypeEnum type)
        {
            if (this.MessageRecieved)
            {
                this.eventLog1 = new System.Diagnostics.EventLog();
                if (!System.Diagnostics.EventLog.SourceExists(eventSourceName))
                {
                    System.Diagnostics.EventLog.CreateEventSource(eventSourceName, logName);
                }
                eventLog1.Source = eventSourceName;
                eventLog1.Log = logName;
                eventLog1.WriteEntry(message);
            }
        }
    }
}

