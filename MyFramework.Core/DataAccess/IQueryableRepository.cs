using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Core.DataAccess
{
    //IQueryable  tamamen select operasyonları için kullanılır
    //veritabanı işlemleri(context kapanmadan çalıştırması için)
    //sorguları kapatmadan arada işlemler yapmak için IQueryable yaralanırız
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get;}
    }
}
