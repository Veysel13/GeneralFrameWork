using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Core.CrossCuttingConcerns.Security
{
    //.net in System.Security.Principal; sınıfından gelmektedir
    public class Identity:IIdentity
    {
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }

        //kendi ozelliklerim
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
