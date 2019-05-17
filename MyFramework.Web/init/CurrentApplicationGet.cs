using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFramework.Business.Abstract;
using MyFramework.Business.DependencyResolvers.Ninject;
using MyFramework.Entities.Concrete;

namespace MyFramework.Web.init
{
    //aplicationdan veri çekme orneği
    public class CurrentApplicationGet
    {
        //private IProductService _productService;
        //public CurrentApplicationGet(IProductService productService)
        //{
        //    _productService = productService;
        //}
        public static List<Product> ProductList()
        {
           
            var _data = HttpContext.Current.Application["odalar"] as List<Product>;
            var data = new List<Product>();
            if (_data != null && _data is List<Product>)
            {
                data = _data as List<Product>;
            }
            else
            {
                var productService = InstanceFactory.GetInstance<IProductService>(); 
                data = productService.GetAll();
                HttpContext.Current.Application["odalar"] = data;
            }
            return data;
        }

        public static void Remove(string key)
        {
            if (HttpContext.Current.Application[key] != null)
            {
                HttpContext.Current.Application.Remove(key);
            }
        }
    }
}