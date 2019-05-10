using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    class RootPointMap : EntityTypeConfiguration<RootPoint>
    {
        public RootPointMap()
        {
            ToTable(@"RootPoints", @"dbo");
            HasKey(x => x.RootPointId);

            Property(x => x.RootPlanId).HasColumnName("RootPlanId");
            Property(x => x.CreatedDate).HasColumnName("CreatedDate");
           
        }
    }
}
