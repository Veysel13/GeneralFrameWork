using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using Resources;

namespace MyFramework.Web.Resources
{
    public static class MyLanguage
    {
        //text değişimlerinde
        //Html.Language("deger")
        public static string Language(this HtmlHelper html, string key)
        {
            var fields = (ResourceExpressionFields)new ResourceExpressionBuilder().ParseExpression("lang," + key,
                typeof(string), new ExpressionBuilderContext("~/App_GlobalResources/"));
            return (string)HttpContext.GetGlobalResourceObject(fields.ClassKey, fields.ResourceKey,
                CultureInfo.CurrentUICulture);
        }
        //code içindeki text değişimlerinde
        //Html.Lan("deger")
        public static string Lan(this HtmlHelper html, string key)
        {
            var fields = (ResourceExpressionFields)new ResourceExpressionBuilder().ParseExpression("lang," + key,
                typeof(string), new ExpressionBuilderContext("~/App_GlobalResources/"));
            return (string)HttpContext.GetGlobalResourceObject(fields.ClassKey, fields.ResourceKey,
                CultureInfo.CurrentUICulture);
        }
    }

    public class MyDisplayName : DisplayNameAttribute
    {
        public string name { get; set; }

        public MyDisplayName(string key) : base(key)
        {
            name = key;
        }

        public override string DisplayName
        {
            get
            {
                var property = typeof(lang).GetProperty(name, BindingFlags.Static | BindingFlags.NonPublic);
                return (string)property.GetValue(property.DeclaringType, null);
            }

        }
    }
}