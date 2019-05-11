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
           
            var cookie = HttpContext.Request.Cookies["culture"];
            cookie = new HttpCookie("culture");
            cookie.HttpOnly = false;
            cookie.Value = lang;
            cookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Response.Cookies.Add(cookie);
            Session["language"] = lang;
            //HttpContext.Response.Cookies.Add(new HttpCookie("culture", lang));
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            //Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            CultureInfo Culture = new System.Globalization.CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = Culture;
            Thread.CurrentThread.CurrentUICulture = Culture;

            return Redirect(returnUrl);
        }
    }
}