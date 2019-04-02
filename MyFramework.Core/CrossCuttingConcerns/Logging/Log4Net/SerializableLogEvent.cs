using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
   public class SerializableLogEvent
    {
        //log4net den gelir
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName => _loggingEvent.UserName;
        public object MessageObject => _loggingEvent.MessageObject;
    }
}
