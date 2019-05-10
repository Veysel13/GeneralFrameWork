using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyFramework.Business.Abstract;
using MyFramework.Business.ValidationRules.FluentValidation;
using MyFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using MyFramework.Core.Aspects.Postsharp.CacheAspects;
using MyFramework.Core.Aspects.Postsharp.LogAspects;
using MyFramework.Core.Aspects.Postsharp.PerformanceAspects;
using MyFramework.Core.Aspects.Postsharp.ValidationAspects;
using MyFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.Concrete;
using Ninject.Activation.Caching;

namespace MyFramework.Business.Concrete.Managers
{
    [LogAspect(typeof(DatabaseLogger))]
    [LogAspect(typeof(FileLogger))]
  public class SupplierManager:ISupplierService
   {
       private ISupplierDal _supplierDal;
       private IMapper _mapper { get; }

        public SupplierManager(ISupplierDal supplierDal,IMapper mapper)
       {
           _supplierDal = supplierDal;
           _mapper = mapper;
       }

       [CacheAspect(typeof(MemoryCacheManager))]
       [LogAspect(typeof(DatabaseLogger))]
       //[LogAspect(typeof(FileLogger))]
     public List<Supplier> GetAll()
        {
          return _mapper.Map<List<Supplier>>(_supplierDal.GetList());
        }

        public Supplier GetById(int id)
        {
            return _mapper.Map<Supplier>(_supplierDal.Get(x=>x.SupplierId==id));

        }


        [FluentValidationAspect(typeof(SupplierValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Supplier Add(Supplier supplier)
        {
            return _supplierDal.Add(supplier);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Supplier Update(Supplier supplier)
        {
            return _supplierDal.Update(supplier);
        }

       [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int id)
       {
           Supplier model = GetById(id);
           if (model !=null) _supplierDal.Delete(model);
       }
    }
}
