using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.ComplexType;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Abstract
{
   public interface IUserService
    {
        User GetByUserNameAndPassword(string UserName,string Password);
        List<UserRoleItem> GetUserRoleItems(User user);
    }
}
