using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFramework.Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using MyFramework.Core.Utilities.Mvc.Enums;

namespace MyFramework.Web.Filters
{
    public class ExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            if (filterContext.Exception is NotificationException)
            {
                filterContext.Result = new ViewResult
                {
                    TempData = new TempDataDictionary
                    {
                        {$"MyFramework.notifications.{NotifyType.Error}",filterContext.Exception.Message }
                    }
                };
            }
            else
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "NoAuthorize",
                    ViewData = new ViewDataDictionary(filterContext.Exception)
                };
            }

        }
    }
}