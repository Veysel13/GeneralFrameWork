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
using MyFramework.Core.Aspects.Postsharp.ValidationAspects;
using MyFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.ComplexType;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Concrete.Managers
{
    [LogAspect(typeof(DatabaseLogger))]
    [LogAspect(typeof(FileLogger))]
    class RootPlanManager : IRootPlanService
    {
        private IRootPlanDal _rootPlanDal;
        
        private IMapper _mapper { get; }

        public RootPlanManager(IRootPlanDal rootPlanDal, IMapper mapper)
        {
            _rootPlanDal = rootPlanDal;
            _mapper = mapper;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "SystemAdmin,Admin")]
        public List<RootPlan> GetAll()
        {
           return _mapper.Map<List<RootPlan>>(_rootPlanDal.GetList());
         
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "SystemAdmin,Admin")]
        public RootPlan GetById(int id)
        {

            return _rootPlanDal.Get(x => x.RootPlanId == id);
        }

        [FluentValidationAspect(typeof(RootPlanValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "SystemAdmin,Admin")]
        public RootPlan Add(RootPlan rootplan)
        {
            rootplan.CreatedDate=DateTime.Now;
            rootplan.IsActive = true;
          return _rootPlanDal.Add(rootplan);
        }

        [FluentValidationAspect(typeof(RootPlanValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "SystemAdmin,Admin")]
        public RootPlan Update(RootPlan rootplan)
        {
            return _rootPlanDal.Update(rootplan);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "SystemAdmin,Admin")]
        public void Delete(int id)
        {
            RootPlan model = GetById(id);
            if (model !=null) _rootPlanDal.Delete(model);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "SystemAdmin,Admin")]
        public List<RootPlanDetail> GetListRootPlanDetails()
        {
            return _mapper.Map<List<RootPlanDetail>>(_rootPlanDal.GetRootPlanDetails());
        }

        

    }
}
