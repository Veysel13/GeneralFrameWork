using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.Web.Helper
{
    public static class BeginFormHelper
    {
        public static IDisposable BeginForm(this HtmlHelper helper, string url, bool image = false)
        {
            helper.ViewContext.Writer.Write(
                $"<form action=\"{url}\" {(image ? $"enctype=\"multipart/form-data\"" : "")} method=\"post\">");
            helper.ViewContext.Writer.Write("<div class=\"form-group\">");
            return new MyView(helper);
        }

        class MyView : IDisposable
        {
            private HtmlHelper helper;

            public MyView(HtmlHelper helper)
            {
                this.helper = helper;
            }

            public void Dispose()
            {
                this.helper.ViewContext.Writer.Write("</div>");
                this.helper.ViewContext.Writer.Write("</form>");
            }
        }
    }
}