using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MyFramework.Core.DataAccess.NHihabernate;
using NHibernate;

namespace MyFramework.DataAccess.Concrete.NHibernate.Helpers
{
    //nhbirnate paketinin eklenmesi gerekiyor
    //fluentnhibernate paketinin de yüklenmesi gerekiyor
    //Entitlerimin virtual imzalı olması gerkiyor nhbirnate de
    public class SqlServerHelper:NHibernateHelper
    {
        protected override ISessionFactory InitializerFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(c=>c.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(t=>t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
           
            /*return Fluently.Configure().Database(OracleClientConfiguration.Oracle10
                    .ConnectionString(c => c.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();*/
        }
    }
}
