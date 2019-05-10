using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    class RootPlanMap : EntityTypeConfiguration<RootPlan>
    {
        public RootPlanMap()
        {
            ToTable(@"RootPlans", @"dbo");
            HasKey(x => x.RootPlanId);
            Property(x => x.DayOfWeek).HasColumnName("DayOfWeek");
            Property(x => x.Time).HasColumnName("Time");
            Property(x => x.SupplierId).HasColumnName("SupplierId");
            Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            Property(x => x.IsActive).HasColumnName("IsActive");
           
        }
    }
}
