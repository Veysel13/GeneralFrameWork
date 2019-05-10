using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PostSharp.Aspects;

namespace MyFramework.Core.Aspects.Postsharp.AuthorizationAspects
{
    //OnMethodBoundaryAspect metodun basında calısacagını belirtiyoruz
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }
        //metoda girdigimiz zaman
        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;
            for (int i = 0; i < roles.Length; i++)
            {
                //curentprincipal kullanıcı bılgılerını bıze getiren sistemdir
                //.net ile gelen yapıdır
                //session la rol bazlı guvenlık ıcın tutulmaz,Sessionda kullanıcıya dair bilgiler sepet ve seyra gibi
                //sessionlara rolleri bagladıgımızda sadece mvc yi ilgilendiren bir yapı kurmuş oluyoruz.

                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorized = true;
                }
            }
            if (isAuthorized == false)
            {
                //HttpContext.Current.Response.Redirect("/Account/SignIn");
                throw new SecurityException("You are not authorized");
            }

        }
    }
}
