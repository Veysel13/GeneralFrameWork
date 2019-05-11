using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework.Mappings
{
   public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable(@"Customers", @"dbo");
            HasKey(x => x.CustomerId);
            //bendeki  CategoryId veritabanında CategoryId ye denk gelir;
            Property(x => x.CustomerId).HasColumnName("CustomerID");
            Property(x => x.CompanyName).HasColumnName("CompanyName");
            Property(x => x.ContactName).HasColumnName("ContactName");
            Property(x => x.ContactTitle).HasColumnName("ContactTitle");
            Property(x => x.Address).HasColumnName("Address");
            Property(x => x.City).HasColumnName("City");
            Property(x => x.Region).HasColumnName("Region");
            Property(x => x.PostalCode).HasColumnName("PostalCode");
            Property(x => x.Country).HasColumnName("Country");
            Property(x => x.Phone).HasColumnName("Phone");
            Property(x => x.Fax).HasColumnName("Fax");
            Property(x => x.IsActive).HasColumnName("IsActive");

        }
    }
}
