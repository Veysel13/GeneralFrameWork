using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Abstract
{
    public interface IRootPointService
    {
        List<RootPoint> GetAll();
        RootPoint GetById(int id);
        RootPoint Add(RootPoint rootPoint);
        RootPoint Update(RootPoint rootPoint);
        void Delete(int id);
        List<RootPoint> GetRootPlan();
        void PlanCheck(int? id);
    }
}
