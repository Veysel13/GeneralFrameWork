using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger
{
   public class FileLogger:LoggerService
    {
        public FileLogger() : base(LogManager.GetLogger("JsonFileLogger"))
        {
        }
    }
}
