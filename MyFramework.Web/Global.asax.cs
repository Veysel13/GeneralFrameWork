using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MyFramework.Business.DependencyResolvers.Ninject;
using MyFramework.Core.CrossCuttingConcerns.Security.Web;
using MyFramework.Core.Utilities.Mvc.Infrastructure;
using MyFramework.Web.App_Start;

namespace MyFramework.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(),new AutoMapperModule()));
        }
        //IUdentity nesnesının ulasılabılır olması ıcın 
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        //erişebilir oldugu  zamn
        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                //FormsAuthentication.FormsCookieName isminle bir cookie oluşturacagımız soylemsıtık
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                //bos sa dondur
                if (authCookie == null)
                {
                    return;
                }

                var encticket = authCookie.Value;

                //bos sa dondur
                if (String.IsNullOrEmpty(encticket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encticket);
                var securityUrlities = new SecurityUtilities();
                var identity = securityUrlities.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                //backend ve fronted tarafında erişim işlemleri için
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception)
            {


            }
        }
    }
}
