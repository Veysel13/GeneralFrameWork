using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.DataAccess.EntityFramework;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework
{
  public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
