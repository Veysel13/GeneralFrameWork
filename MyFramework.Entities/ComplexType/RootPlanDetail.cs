using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Entities.ComplexType
{
  public  class RootPlanDetail
    {
        public virtual int RootPlanId { get; set; }
        public virtual DayOfWeek DayOfWeek { get; set; }
        public virtual string Time { get; set; }
        public virtual string SupplierName { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
