﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.DataAccess;
using MyFramework.Entities.ComplexType;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Abstract
{
   public interface IRootPlanDal:IEntityRepository<RootPlan>
    {
        List<RootPlanDetail> GetRootPlanDetails();
    }
}
