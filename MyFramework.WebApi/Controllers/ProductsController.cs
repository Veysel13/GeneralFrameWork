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
        //bu problemi automapper ile çozuoyoruz(nuget paket den ındırıyoruz business katmanına)
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _productService.GetAll();
        }
        //[Route("{id:int:range(1,10)}", Name = "GetById")]
        [HttpGet]
        public Product Get(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Product product)
        {
            _productService.Add(product);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
           // response.Headers.Location=new Uri("/api/Employee");
            //response.Headers.Location = new Uri(Request.RequestUri+"/" + emp.Id.ToString());
            //işlem sonucu yönlecegi adresi yazıyoruz
            response.Headers.Location = new Uri(Url.Link("Get","Product"));
            return response;
        }


    }
}
