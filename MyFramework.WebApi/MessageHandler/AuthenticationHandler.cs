using MyFramework.Business.Abstract;
using MyFramework.Business.DependencyResolvers.Ninject;
using MyFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MyFramework.WebApi.MessageHandler
{
    public class AuthenticationHandler:DelegatingHandler
    {
        //web api cpnfiğe eklmemiz gerekıyor
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token !=null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodeString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodeString.Split(':');
                    IUserService userService = InstanceFactory.GetInstance<IUserService>();
                    User user = userService.GetByUserNameAndPassword(tokenValues[0], tokenValues[1]);
                    if (user != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]),
                            userService.GetUserRoleItems(user).Select(u => u.RoleName).ToArray());
                        //web için authwntication
                        Thread.CurrentPrincipal = principal;
                        //web api için authention
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch {
               
            }
            return base.SendAsync(request, cancellationToken);
        }

      
    }

    
}