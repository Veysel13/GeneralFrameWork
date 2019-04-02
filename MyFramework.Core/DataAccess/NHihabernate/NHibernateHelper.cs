using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace MyFramework.Core.DataAccess.NHihabernate
{
    //nhibernate paketini yukluyoruz
    public abstract class NHibernateHelper : IDisposable
    {
        private static ISessionFactory _sessionFactory;

        public virtual ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = InitializerFactory()); }
        }

        protected abstract ISessionFactory InitializerFactory();

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
