using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Entities.Concrete
{
   public class Role:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
