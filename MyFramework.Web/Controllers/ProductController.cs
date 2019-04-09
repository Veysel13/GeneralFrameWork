using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFramework.Business.Abstract;
using MyFramework.Entities.Concrete;
using MyFramework.Web.Models.ViewModel;

namespace MyFramework.Web.Controllers
{
    //postsharp 4.2.17 paketini de indiriyoruz
    //controllerin consruct üretmek için Core katmanında Utilities kısmını yazmam gerekir
    //daha sonra global.assax da bunu belirmemiz gerekir.
    //ninject paktinide kurulması gerekiyor
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel();
            model.Products = _productService.GetAll();
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "aaa",
                QuantityPerUnit = "1",
                UnitPrice = 21
            });
            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "aa",
                QuantityPerUnit = "1",
                UnitPrice = 21
            }, new Product
            {
                CategoryId = 1,
                ProductName = "aa",
                QuantityPerUnit = "1",
                UnitPrice = 33,
                ProductId = 2
            });
            return "UpdateAdded";
        }
    }
}