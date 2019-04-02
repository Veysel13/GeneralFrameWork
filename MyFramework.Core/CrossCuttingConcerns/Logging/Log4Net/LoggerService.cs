using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;


namespace MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    //nuget paket den log4net paketini indiriyoruz
    [Serializable]
   public class LoggerService
   {
       private ILog _log;

       public LoggerService(ILog log)
       {
           _log = log;
       }
        //loglamalardan bilgi logları açık mı
       public bool IsInfoEnabled => _log.IsInfoEnabled;
       //loglamalardan debug logları açık mı
        public bool IsDebugEanbled => _log.IsDebugEnabled;
       //loglamalardan uyarı logları açık mı
       public bool IsWarnEnabled => _log.IsWarnEnabled;
       //loglamalardan ölümcül hata logları açık mı
       public bool IsFatalEnabled => _log.IsFatalEnabled;
       //loglamalardan hata logları açık mı
       public bool IsErrorEnabled => _log.IsErrorEnabled;

       public void Info(object logMessage)
       {
           if (IsInfoEnabled)
           {
               _log.Info(logMessage);
           }
       }
       public void Debug(object logMessage)
       {
           if (IsDebugEanbled)
           {
               _log.Debug(logMessage);
           }
       }
       public void Warn(object logMessage)
       {
           if (IsInfoEnabled)
           {
               _log.Warn(logMessage);
           }
       }
       public void Fatal(object logMessage)
       {
           if (IsInfoEnabled)
           {
               _log.Fatal(logMessage);
           }
       }
       public void Error(object logMessage)
       {
           if (IsInfoEnabled)
           {
               _log.Error(logMessage);
           }
       }
    }
}
