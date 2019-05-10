using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFramework.Entities.ComplexType;
using MyFramework.Entities.Concrete;

namespace MyFramework.Web.Models.ViewModel
{
    public class RootPlanListViewModel
    {
        public List<RootPlanDetail> RootPlans { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}