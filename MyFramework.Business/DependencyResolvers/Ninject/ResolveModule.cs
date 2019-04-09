using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace MyFramework.Business.DependencyResolvers.Ninject
{
    public class ResolveModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load(new BusinessModule());
            
        }
    }
}
