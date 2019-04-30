using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Abstract
{
   public interface ISupplierService
    { 
        List<Supplier> GetAll();
        Supplier GetById(int id);
        Supplier Add(Supplier supplier);
        Supplier Update(Supplier supplier);
        void Delete(Supplier supplier);
    }
}
