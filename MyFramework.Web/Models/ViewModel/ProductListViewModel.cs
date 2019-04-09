using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFramework.Entities.Concrete;

namespace MyFramework.Web.Models.ViewModel
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
    }
}