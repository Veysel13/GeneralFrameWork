using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyFramework.Business.Abstract;
using MyFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using MyFramework.Core.Aspects.Postsharp.LogAspects;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Concrete.Managers
{
    [LogAspect(typeof(DatabaseLogger))]
    [LogAspect(typeof(FileLogger))]
    [SecuredOperation(Roles = "SystemAdmin,Admin")]
    public class RootPointManager : IRootPointService
    {
        private IRootPointDal _rootPointDal;
        
        private IMapper _mapper;

        public RootPointManager(IRootPointDal rootPointDal, IMapper mapper)
        {
            _rootPointDal = rootPointDal;
            _mapper = mapper;
        }

        public RootPoint Add(RootPoint rootPoint)
        {
            return _rootPointDal.Update(rootPoint);
        }

        public void Delete(int id)
        {
            RootPoint model = GetById(id);
            if (model !=null) _rootPointDal.Delete(model);
        }

        public List<RootPoint> GetAll()
        {
            return _mapper.Map<List<RootPoint>>(_rootPointDal.GetList());
        }

        public RootPoint GetById(int id)
        {
            return _mapper.Map<RootPoint>(_rootPointDal.GetList());
        }

        public RootPoint Update(RootPoint rootPoint)
        {
            return _rootPointDal.Update(rootPoint);
        }
        public List<RootPoint> GetRootPlan()
        {
            var now = DateTime.Now;
           return _rootPointDal.GetList(x => x.CreatedDate.Year == now.Year && x.CreatedDate.Month == now.Month && x.CreatedDate.Day == now.Day).ToList() ?? new List<RootPoint>();

        }
        public void PlanCheck(int? id)
        {
            RootPoint data = _rootPointDal.Get(x=>x.RootPlanId==id.Value);
            if (data == null)
                _rootPointDal.Add(new RootPoint
                {
                    RootPlanId = id.Value,
                    CreatedDate = DateTime.Now,

                });
            else
                _rootPointDal.Delete(data);
        }

    }
}
