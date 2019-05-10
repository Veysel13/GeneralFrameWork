using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Resources;
using MyFramework.Business.Abstract;
using MyFramework.Business.ValidationRules.FluentValidation;
using MyFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.Concrete;
using MyFramework.Core.Aspects.Postsharp;
using System.Transactions;
using AutoMapper;
using MyFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using MyFramework.Core.Aspects.Postsharp.CacheAspects;
using MyFramework.Core.Aspects.Postsharp.LogAspects;
using MyFramework.Core.Aspects.Postsharp.PerformanceAspects;
using MyFramework.Core.Aspects.Postsharp.TransactionAspects;
using MyFramework.Core.Aspects.Postsharp.ValidationAspects;
using MyFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using PostSharp.Aspects.Dependencies;
using MyFramework.Core.Utilities.Mappings;
using MyFramework.Entities.ComplexType;

namespace MyFramework.Business.Concrete.Managers
{
    //aop ile yazılan kodlar aslında metod içerisine doğrudan yerleşir
    //postsharp ın 4.2.17 versiyonunu kuruyoruz
    //manager ustunde bunların calısmasını saglayabılırız
    //yada tım managerların loglanmasını ıstıyorsak busıness altındakı propertıesın ıcındekı assmblyınfo ıcıne eklıyoruz
    //bu problemi automapper ile çozuoyoruz(nuget paket den ındırıyoruz business katmanına)
    public class ProductManager:IProductService
   {
       //dependency injection yaptık
       private IProductDal _productDal;
       private IMapper _mapper { get; }

        public ProductManager(IProductDal productDal,IMapper mapper)
       {
           _productDal = productDal;
           _mapper = mapper;
        }

       [CacheAspect(typeof(MemoryCacheManager))]
       [LogAspect(typeof(DatabaseLogger))]
       [LogAspect(typeof(FileLogger))]
       [PerformanceCounterAspect(2)]
       [SecuredOperation(Roles="Admin")]
        public List<Product> GetAll()
       {
            // Thread.Sleep(3000);
          
            //return _productDal.GetList().Select(p => new Product()
            //{
            //    CategoryId = p.CategoryId,
            //    ProductId = p.ProductId,
            //    ProductName = p.ProductName,
            //    QuantityPerUnit = p.QuantityPerUnit,
            //    UnitPrice = p.UnitPrice
            //}).ToList();

            //Mapper.Initialize(x => { x.CreateMap<Product, Product>(); });
            //List<Product> products = Mapper.Map<List<Product>, List<Product>>(_productDal.GetList());
            //return products;

            //core daki yapı
            //var result = AutoMapperHelper.MapToSameTypeList(_productDal.GetList());
            //business dayazdıgımız nınject map yapısı
            var result = _mapper.Map<List<Product>>(_productDal.GetList());

            return result;
       }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
       [CacheRemoveAspect(typeof(MemoryCacheManager))]
        //sadece bu cache siler
        //[CacheRemoveAspect("MyFramework.Business.Concrete.Managers.Add", typeof(MemoryCacheManager))]
        [LogAspect(typeof(FileLogger))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidation(new ProductValidatior(),product);
            return _productDal.Add(product);
        }

       [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            //ValidatorTool.FluentValidation(new ProductValidatior(), product);
            return _productDal.Update(product);
        }

       [TransactionScopeAspect]
       [FluentValidationAspect(typeof(ProductValidatior))]
        public void TransactionalOperation(Product product1, Product product2)
       {
           _productDal.Add(product1);
           //diğer işler 
           _productDal.Update(product2);


            /*using System.Transactions; dll referans verilir.
            using (TransactionScope scope=new TransactionScope())
           {
               try
               {
                   _productDal.Add(product1);
                   //diğer işler 
                   _productDal.Update(product2);
                   scope.Complete();
               }
               catch
               {
                   scope.Dispose();
               }
            }*/
          
       }
       [CacheAspect(typeof(MemoryCacheManager))]
       [SecuredOperation(Roles ="Student,Admin")]
        public List<ProductDetail> GetListProductDetails()
       {
          return _productDal.GetProductDetails();
       }
       [CacheRemoveAspect(typeof(MemoryCacheManager))]
       [TransactionScopeAspect]
        public void Delete(int id)
        {
            Product model = GetById(id);
            if (model !=null)
            {
                model.Discontinued = false;
                _productDal.Update(model);
            }
           
        }
    }
}
