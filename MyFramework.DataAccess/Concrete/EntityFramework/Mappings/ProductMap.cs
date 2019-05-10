using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    //context de mappingleri entegre etmemiz gerekir
   public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(x => x.ProductId);

            //bendeki  ProductId veritabanında ProductID ye denk gelir;
            Property(x => x.ProductId).HasColumnName("ProductID");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.SupplierId).HasColumnName("SupplierID");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");
            Property(x => x.Discontinued).HasColumnName("Discontinued");
            
        }
    }
}
