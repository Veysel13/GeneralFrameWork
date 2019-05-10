using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Resources;

namespace MyFramework.Web.Resources
{
    //kontrollar da attr,bute olarak yazılır
    public class LocalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string culture = null;
            var cookie = filterContext.HttpContext.Request.Cookies["culture"];
            
            if (filterContext.RouteData.Values["lang"] != null)
            {
                culture = filterContext.RouteData.Values["lang"].ToString();
               
                if (culture.IndexOf("-") != 2)
                {
                    culture = cookie == null ? Thread.CurrentThread.CurrentUICulture.Name : cookie.Value;
                }
            }
            else
            {
                culture = cookie == null ? Thread.CurrentThread.CurrentCulture.Name : cookie.Value;
            }


            if (cookie == null || culture != cookie.Value)
            {
                cookie = new HttpCookie("culture");
                cookie.HttpOnly = false;
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
                filterContext.HttpContext.Response.Cookies.Add(cookie);
            }

            lang.Culture = new CultureInfo(culture);
            filterContext.RouteData.Values["lang"] = culture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
            base.OnActionExecuting(filterContext);
        }
    }
}