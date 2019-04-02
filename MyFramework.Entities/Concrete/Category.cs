using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Entities.Concrete
{
   public class Category:IEntity
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
