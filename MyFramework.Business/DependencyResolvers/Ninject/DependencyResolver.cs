using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace MyFramework.Business.DependencyResolvers.Ninject
{
    public class DependencyResolver<T>
    {
        public static T Resolve()
        {
            IKernel kernel = new StandardKernel(new ResolveModule(), new AutoMapperModule());

            return kernel.Get<T>();
        }
    }
}
