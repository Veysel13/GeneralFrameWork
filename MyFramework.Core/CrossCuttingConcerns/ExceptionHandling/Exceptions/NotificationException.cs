using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Core.CrossCuttingConcerns.ExceptionHandling.Exceptions
{
    public class NotificationException : Exception
    {
        public NotificationException(string mesaj)
            : base(mesaj)
        {
        }

        public NotificationException(string mesaj, Exception hata)
            : base(mesaj, hata)
        {
        }
    }
}
