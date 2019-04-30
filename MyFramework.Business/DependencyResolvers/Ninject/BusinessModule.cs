using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Business.Abstract;
using MyFramework.Business.Concrete.Managers;
using MyFramework.Core.DataAccess;
using MyFramework.Core.DataAccess.EntityFramework;
using MyFramework.Core.DataAccess.NHihabernate;
using MyFramework.DataAccess.Abstract;
using MyFramework.DataAccess.Concrete.EntityFramework;
using MyFramework.DataAccess.Concrete.NHibernate;
using MyFramework.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;

namespace MyFramework.Business.DependencyResolvers.Ninject
{
    //ninject 3.2.2 kararlı paketini kullandık
  public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<ISupplierService>().To<SupplierManager>().InSingletonScope();
            Bind<ISupplierDal>().To<EfSupplierDal>().InSingletonScope();
            //burdakiler standart kullandıgımız için gerekli
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
