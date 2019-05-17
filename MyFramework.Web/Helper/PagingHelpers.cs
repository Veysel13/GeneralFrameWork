using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MyFramework.Web.Models.ViewModel;

namespace MyFramework.Web.Helper
{
    public static class PagingHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper html, PageingInfo pagingInfo)
        {
            //sayfa sayıyısını bulduk
            int totalPage = (int)Math.Ceiling((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage);


            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i <= totalPage; i++)
            {
                var tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", String.Format("/Product/Index/?page={0}&category={1}", i, pagingInfo.CurrentCategory));
                tagBuilder.InnerHtml = i.ToString();

                if (pagingInfo.CurrentPage == i)
                {
                    tagBuilder.AddCssClass("selected");
                }

                stringBuilder.Append(tagBuilder);
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}