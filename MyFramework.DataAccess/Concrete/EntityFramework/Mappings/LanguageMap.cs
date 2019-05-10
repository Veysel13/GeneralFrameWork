using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class LanguageMap : EntityTypeConfiguration<Language>
    {
        public LanguageMap()
        {
            ToTable("Languages", "dbo");
            HasKey(x => x.LanguageId);
            Property(x => x.LanguageId).HasColumnName("LanguageId");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Code).HasColumnName("Code");

        }
    }
}
