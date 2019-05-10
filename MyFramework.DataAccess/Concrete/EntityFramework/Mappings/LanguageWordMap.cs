using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class LanguageWordMap : EntityTypeConfiguration<LanguageWord>
    {
        public LanguageWordMap()
        {
            ToTable("LanguageWords", "dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.LanguageId).HasColumnName("LanguageId");
            Property(x => x.Code).HasColumnName("Code");
            Property(x => x.Value).HasColumnName("Value");

        }
    }
}
