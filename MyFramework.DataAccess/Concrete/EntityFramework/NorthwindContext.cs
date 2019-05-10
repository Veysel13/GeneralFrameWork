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
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.AutoDetectChangesEnabled = false;
            Database.SetInitializer<NorthwindContext>(null);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<RootPlan> RootPlans { get; set; }
        public DbSet<RootPoint> RootPoints { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageWord> LanguageWords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new RootPlanMap());
            modelBuilder.Configurations.Add(new RootPointMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new LanguageWordMap());
            //
        }
    }
}
