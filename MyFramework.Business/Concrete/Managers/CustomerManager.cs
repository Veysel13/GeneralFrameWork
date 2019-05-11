using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyFramework.Business.Abstract;
using MyFramework.Business.ValidationRules.FluentValidation;
using MyFramework.Core.Aspects.Postsharp.CacheAspects;
using MyFramework.Core.Aspects.Postsharp.ValidationAspects;
using MyFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Concrete.Managers
{
   public class CustomerManager:ICustomerService
   {
       private ICustomerDal _customerDal;
       private IMapper _mapper { get; }

        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
       {
           _customerDal = customerDal;
           _mapper = mapper;
       }

       [CacheAspect(typeof(MemoryCacheManager))]
        public List<Customer> GetAll()
       {
           return  _mapper.Map<List<Customer>>(_customerDal.GetList());
        }

        public Customer GetById(string id)
        {
            return _mapper.Map<Customer>(_customerDal.Get(x=>x.CustomerId==id));
        }

       [CacheRemoveAspect(typeof(MemoryCacheManager))]
       [FluentValidationAspect(typeof(CustomerValidator))]
        public Customer Add(Customer customer)
       {
            customer.IsActive = true;
            return _customerDal.Add(customer);
        }

       [CacheRemoveAspect(typeof(MemoryCacheManager))]
       [FluentValidationAspect(typeof(CustomerValidator))]
        public Customer Update(Customer customer)
        {
            return _customerDal.Update(customer);
        }

       [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(string id)
        {
            Customer model = GetById(id);
            if (model!=null)
            {
                model.IsActive = false;
               _customerDal.Update(model);
            }
        }
    }
}
