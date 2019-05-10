using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework.Mappings
{
  public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(x => x.CategoryId);

            //bendeki  CategoryId veritabanında CategoryId ye denk gelir;
            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.CategoryName).HasColumnName("CategoryName");
            Property(x => x.Description).HasColumnName("Description");
            Property(x => x.Image).HasColumnName("Image");
            Property(x => x.ThumbImage).HasColumnName("ThumbImage");
            
        }
    }
}
