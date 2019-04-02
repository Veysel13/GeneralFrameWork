using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        //bir dbye aboneolmak için
        private DbContext _context;
        //bir entitiye aboneolmak için
        private IDbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities;

        protected virtual IDbSet<T>  Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }
    }
}
