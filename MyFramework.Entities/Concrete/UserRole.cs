using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Entities.Concrete
{
   public class UserRole:IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
