﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Entities.ComplexType
{
  public  class ProductDetail
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual bool Discontinued { get; set; }
    }
}
