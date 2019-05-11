using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Abstract
{
   public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(string id);
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        void Delete(string id);
    }
}
