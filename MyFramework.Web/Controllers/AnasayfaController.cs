using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFramework.Web.Filters;
using MyFramework.Web.Infrastructure;
using MyFramework.Web.Resources;

namespace MyFramework.Web.Controllers
{
    //[Localization]
    [ExceptionFilter]
    [AuthorizationFilter]
    public class AnasayfaController : BaseController
    {

        public AnasayfaController()
        {
            
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeCulture(string dilId, string lang, string returnUrl)
        {
            Response.Cookies.Add(new HttpCookie("culture", lang));
            return Redirect(returnUrl);
        }
    }
}