using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Core.DataAccess
{
    // T bir referans tip olmalı(class)
    //interfacelerde abstractlarda referans tip olduğu için (IEntity) olanları alsın
    //new lene bilsin 
   public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        //verileri listelerken where kosullarını liste üzerinde uygulamamız için (Expression<Func<T,bool>>) kullandık
        
        List<T> GetList(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
