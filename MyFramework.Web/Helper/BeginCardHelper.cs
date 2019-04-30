using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.Web.Helper
{
    public static class BeginCardHelper
    {
        public static IDisposable BeginCard(this HtmlHelper helper, string title,string rowGrid= "col-sm-12")
        {
            helper.ViewContext.Writer.Write("<div class=\"wrapper\">");
            helper.ViewContext.Writer.Write("<div class=\"row\">");
            helper.ViewContext.Writer.Write("<div class=\"{0}\">",rowGrid);
            helper.ViewContext.Writer.Write("<section class=\"panel\">");
            helper.ViewContext.Writer.Write("<header class=\"panel-heading\">{0}</header>", title);
            helper.ViewContext.Writer.Write("<div class=\"panel-body\">");

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
                this.helper.ViewContext.Writer.Write("</section>");
                this.helper.ViewContext.Writer.Write("</div>");
                this.helper.ViewContext.Writer.Write("</div>");
                this.helper.ViewContext.Writer.Write("</div>");
            }
        }
    }
}