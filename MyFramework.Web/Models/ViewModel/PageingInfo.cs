using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFramework.Web.Models.ViewModel
{
    public class PageingInfo
    {
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentCategory { get; internal set; }
    }
}