using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;

namespace MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent=new SerializableLogEvent(loggingEvent);
            //using Newtonsoft.Json; dan gelir

            var json = JsonConvert.SerializeObject(logEvent,Formatting.Indented);
            //writer veritabanı oldugunda veritabanına 
            //dosya olunca dosyaya yazılacak olayı yapar
            writer.WriteLine(json);
        }
    }
}
