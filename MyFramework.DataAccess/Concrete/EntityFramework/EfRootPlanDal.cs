using System.Collections.Generic;
using System.Linq;
using MyFramework.Core.DataAccess.EntityFramework;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.ComplexType;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework
{
   public class EfRootPlanDal: EfEntityRepositoryBase<RootPlan, NorthwindContext>, IRootPlanDal
    {
        public List<RootPlanDetail> GetRootPlanDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.RootPlans
                    join c in context.Suppliers on p.SupplierId equals c.SupplierId
                  
                    select new RootPlanDetail
                    {
                        RootPlanId = p.RootPlanId,
                        DayOfWeek = p.DayOfWeek,
                        Time = p.Time,
                        SupplierName = c.CompanyName,
                        CreatedDate = p.CreatedDate
                        
                    };
                return result.ToList();
            }
        }
    }
}
