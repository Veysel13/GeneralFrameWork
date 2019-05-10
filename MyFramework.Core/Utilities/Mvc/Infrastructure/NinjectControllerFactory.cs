﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Modules;

namespace MyFramework.Core.Utilities.Mvc.Infrastructure
{
   public class NinjectControllerFactory : DefaultControllerFactory
   {
       private IKernel _kernel;

       //params gonderek ıstedııgm kadar nınject module verebilirim
       public NinjectControllerFactory(params INinjectModule[] modules)
       {
           _kernel = new StandardKernel(modules);
       }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
           return controllerType==null?null:(IController) _kernel.Get(controllerType);
        }
    }
}
