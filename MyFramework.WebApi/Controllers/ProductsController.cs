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

        public List<Product> Get([FromUri]int? categoryId=0, [FromUri]int top=0)
        {
            List<Product> model= _productService.GetAll();
            if (categoryId  >0)
            {
                model = model.Where(x => x.CategoryId == categoryId).ToList();
            }

            if (top>0)
            {
                 model = model.Take(top).ToList();
            }

            return model;
        }

        public Product Get(int id)
        {
            return _productService.GetById(id);
        }

        public HttpResponseMessage Post([FromBody]Product product)
        {
            //genelde create edilen veri geri dondurulur.
            //response.Headers.Location = new Uri(Request.RequestUri+"/"+data.ProdcutId);

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
               var data= _productService.Add(product);
                if (data !=null)
                {
                    response = Request.CreateResponse(HttpStatusCode.Created, data);
                    response.Headers.Location = new Uri(Request.RequestUri.ToString());
                }
                else
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Veri ekleme işlemi başarısız");
                    response.Headers.Location = new Uri(Request.RequestUri.ToString());
                }
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                response.Headers.Location = new Uri(Request.RequestUri.ToString());
            }
             
            return response;
        }

        public HttpResponseMessage Put([FromBody]Product product)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
               
                Product model = _productService.GetById(product.ProductId);
                if (model !=null)
                {
                    model.SupplierId = product.SupplierId;
                    model.CategoryId = product.CategoryId;
                    model.ProductName = product.ProductName;
                    model.QuantityPerUnit = product.QuantityPerUnit;
                    model.UnitPrice = product.UnitPrice;
                    model.UnitsInStock = product.UnitsInStock;
                    model.UnitsOnOrder = product.UnitsOnOrder;
                    model.ReorderLevel = product.ReorderLevel;
                    model.Discontinued = product.Discontinued;
                    var returnValue= _productService.Update(model);

                    response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
                    response.Headers.Location = new Uri(Request.RequestUri.ToString());
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound,"Product Id :"+product.ProductId);
                    response.Headers.Location = new Uri(Request.RequestUri.ToString());
                }
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                response.Headers.Location = new Uri(Request.RequestUri.ToString());
            }
            
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _productService.Delete(id);
                response = Request.CreateResponse(HttpStatusCode.OK, "Product Id :" + id);
                response.Headers.Location = new Uri(Request.RequestUri.ToString());
            }
            catch (Exception e)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                response.Headers.Location = new Uri(Request.RequestUri.ToString());
            }

            return response;
        }

    }
}
