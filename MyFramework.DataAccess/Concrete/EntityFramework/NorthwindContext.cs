using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.DataAccess.Concrete.EntityFramework.Mappings;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework
{
  public  class NorthwindContext:DbContext
    {
        public NorthwindContext()
        {
            //bu veri tabanı için herhangi bir migrations verme null yap
            //benim eklediğim değişiklikleri veritabnına ekleme 
            Database.SetInitializer<NorthwindContext>(null);
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        //

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new UserMap());
            //
        }
    }
}
