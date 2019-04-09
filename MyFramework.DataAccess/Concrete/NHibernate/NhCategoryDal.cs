using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.DataAccess.NHihabernate;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.NHibernate
{
   public class NhCategoryDal:NhEntityRepositoryBase<Category>,ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
