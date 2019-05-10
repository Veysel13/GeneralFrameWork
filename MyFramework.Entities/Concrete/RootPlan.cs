using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Entities.Concrete
{
    public class RootPlan : IEntity
    {
       
        public virtual int RootPlanId { get; set; }
        public virtual DayOfWeek DayOfWeek { get; set; }
        public virtual string Time { get; set; }
        public virtual int SupplierId { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
