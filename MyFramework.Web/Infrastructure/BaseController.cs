using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using MyFramework.Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using MyFramework.Core.Utilities.Mvc.Enums;
using MyFramework.Web.Resources;

namespace MyFramework.Web.Infrastructure
{
   
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception e = filterContext.Exception;
            var logger = new DatabaseLogger();

            filterContext.ExceptionHandled = true;

            if (e is NotificationException)
            {
                logger.Info(filterContext.Exception.Message);

                filterContext.Result = new ViewResult
                {
                    TempData = new TempDataDictionary
                    {
                        { string.Format("MyFramework.notifications.{0}", NotifyType.Error),e.Message }
                    },
                    ViewData = new ViewDataDictionary(filterContext.Result)
                };
            }
            else if (e is SecurityException)
            {
                logger.Error(filterContext.Exception.Message);

                filterContext.Result = new ViewResult()
                {
                    ViewName = "NoAuthorize",
                    ViewData = new ViewDataDictionary(e)
                };
            }
            else
            {
                logger.Error(filterContext.Exception.Message);

                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(e)
                };
            }
        }

        public virtual string RenderPartialViewToString()
        {
            return RenderPartialViewToString(null, null);
        }

        public virtual string RenderPartialViewToString(string viewName)
        {
            return RenderPartialViewToString(viewName, null);
        }

        public virtual string RenderPartialViewToString(object model)
        {
            return RenderPartialViewToString(null, model);
        }

        public virtual string RenderPartialViewToString(string viewName, object model)
        {
            //Original source code: http://craftycodeblog.com/2010/05/15/asp-net-mvc-render-partial-view-to-string/
            if (string.IsNullOrEmpty(viewName))
                viewName = this.ControllerContext.RouteData.GetRequiredString("action");

            this.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = System.Web.Mvc.ViewEngines.Engines.FindPartialView(
                    this.ControllerContext, viewName);
                var viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData,
                    sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Success, message, persistForTheNextRequest);
        }

        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Error, message, persistForTheNextRequest);
        }

        protected virtual void AddNotification(NotifyType type, string message, bool persistForTheNextRequest)
        {
            var dataKey = $"MyFramework.notifications.{type}";

            if (persistForTheNextRequest)
                TempData[dataKey] = message;
            else
                ViewData[dataKey] = message;
        }
    }
}