using MyFramework.Business.Abstract;
using MyFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFramework.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        //ninject paketini 
        //webApiContrib.IoC.Ninject pakitini
        //ninject.Mvc5 ( common web common webhost gibi uygulamaları yukler)
        //paketlerın surunlrinın uyumluluklarını kontrol et

        //app startın altında yenı nınject web common clası eklenecek orda configurasyonlar yapılmalı

        //bilgilerin serilestirme hatası gelmektedir.Entity fremawork de
        //bu problemi automapper ile çozuoyoruz
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Get()
        {
            return _productService.GetAll();
        }
    }
}
