using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.Web.Helper
{
    public static class BeginTableHelper
    {
        public static IDisposable BeginTable(this HtmlHelper helper, string[] titles, string className = "table responsive-data-table data-table")
        {
            helper.ViewContext.Writer.Write("<table class=\"{0}\">", className);
            helper.ViewContext.Writer.Write("<thead>");
            helper.ViewContext.Writer.Write("<tr>");
            foreach (var item in titles)
            {
                helper.ViewContext.Writer.Write("<td>{0}</td>", item);
            }
            helper.ViewContext.Writer.Write("</tr>");
            helper.ViewContext.Writer.Write("</thead>");
            helper.ViewContext.Writer.Write("<tbody >");

            return new BeginTableHelper.MyView(helper);
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
                this.helper.ViewContext.Writer.Write("</tbody>");
                this.helper.ViewContext.Writer.Write("</table>");
            }
        }
    }
}