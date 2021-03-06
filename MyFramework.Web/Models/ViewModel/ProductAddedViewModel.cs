﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFramework.Entities.Concrete;

namespace MyFramework.Web.Models.ViewModel
{
    public class ProductAddedViewModel
    {
        public ProductAddedViewModel()
        {
            CategoryId = -1;
            SupplierId = -1;
        }
       
        public virtual int SupplierId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual bool Discontinued { get; set; }
        public Product Product { get; set; }
        public SelectList CategoriesData { get; set; }
        public SelectList SuppliersData { get; set; }
    }
}