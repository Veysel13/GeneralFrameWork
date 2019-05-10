using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.ComplexType;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Abstract
{
   public interface IRootPlanService
    {
        List<RootPlan> GetAll();
        RootPlan GetById(int id);
        RootPlan Add(RootPlan category);
        RootPlan Update(RootPlan category);
        void Delete(int id);
        List<RootPlanDetail> GetListRootPlanDetails();
    }
}
