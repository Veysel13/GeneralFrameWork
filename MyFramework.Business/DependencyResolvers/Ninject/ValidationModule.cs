using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyFramework.Business.ValidationRules.FluentValidation;
using MyFramework.Entities.Concrete;
using Ninject.Modules;

namespace MyFramework.Business.DependencyResolvers.Ninject
{
   public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidatior>().InSingletonScope();
        }
    }
}
