using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFramework.Entities.Concrete;

namespace MyFramework.Web.Models.ViewModel
{
    public class CategoryListViewModel
    {
        public virtual List<Category> Categories { get; set; }
    }
}