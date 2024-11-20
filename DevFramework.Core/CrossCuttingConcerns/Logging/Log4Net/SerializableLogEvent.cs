using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;      // LoggingEvent log datalarını tutar

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName => _loggingEvent.UserName;
        public object MessageObject => _loggingEvent.MessageObject;
    }
}
