using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Entities.Concrete
{
    public class RootPoint : IEntity
    {
        public virtual int RootPointId { get; set; }
        public virtual int RootPlanId { get; set; }
        public virtual DateTime CreatedDate { get; set; }


    }
}
