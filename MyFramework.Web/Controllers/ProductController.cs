using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFramework.Business.Abstract;
using MyFramework.Entities.Concrete;
using MyFramework.Web.Filters;
using MyFramework.Web.Infrastructure;
using MyFramework.Web.Models.ViewModel;
using NonFactors.Mvc.Grid;
namespace MyFramework.Web.Controllers
{
    //postsharp 4.2.17 paketini de indiriyoruz
    //controllerin consruct üretmek için Core katmanında Utilities kısmını yazmam gerekir
    //daha sonra global.assax da bunu belirmemiz gerekir.
    //ninject paktinide kurulması gerekiyor
    [AuthorizationFilter]
    public class ProductController : BaseController
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel();
            model.Products = _productService.GetListProductDetails();
            return View(model);
        }
        public ActionResult Deneme(Int32? page, Int32? rows)
        {
            //nuget paket den NonFactors.Grid.Mvc5 paketini ındiriyoruz
            //nuget den NonFactors.Mvc.Grid paketinide indiriyoruz
            IGrid<Product> col = new Grid<Product>(_productService.GetAll());
            col.Query=new NameValueCollection(Request.QueryString);
            if (col.Query != null)
            {
                col = new Grid<Product>(_productService.GetAll());
            }
            

            col.Columns.Add(x => x.ProductName).Titled("Urun İsmi").MultiFilterable(true);
            col.Columns.Add(x => x.UnitPrice).Titled("Urun Fiyatı").MultiFilterable(true);
            col.Columns.Add(x => x.QuantityPerUnit).Titled("Birim Miktarı").MultiFilterable(true);
            col.Columns.Add(x => "<a class='btn btn-warning btn-sm' title='Güncelle' href='Edit/" + x.ProductId + "'><i class='fas fa-edit'></i></a>" +
                                 "<a class='actions  btn btn-danger btn-sm' title='Sil' href='Delete/" + x.ProductId + "'><i class='fas fa-trash'></i> </a>")
                .Encoded(false).Titled("işlemler").Filterable(true).Sortable(true).Css("table-hover");
            col.Pager = new GridPager<Product>(col);
            col.Processors.Add(col.Pager);
            col.Pager.RowsPerPage = 10;
            col.EmptyText = "Gösterilecek Kayıt Yok :(";
            
            var total = _productService.GetAll().Count();
            ViewBag.totalRows = Convert.ToInt32(total);
            return View(col);
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
                ProductName = "cc",
                QuantityPerUnit = "1",
                UnitPrice = 3
            }, new Product
            {
                CategoryId = 1,
                ProductName = "cc",
                QuantityPerUnit = "1",
                UnitPrice = 33,
                ProductId = 2
            });
            return "UpdateAdded";
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}