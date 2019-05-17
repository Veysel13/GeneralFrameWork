using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
           
            var cookie = HttpContext.Request.Cookies["language"];
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang.ToLower());
            HttpCookie LangCookie = new HttpCookie("language");
            LangCookie.Value = lang;
            Response.Cookies.Add(LangCookie);

            return Redirect(returnUrl);
        }
    }
}