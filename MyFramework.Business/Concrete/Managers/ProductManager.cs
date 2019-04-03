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
using MyFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using MyFramework.Core.Aspects.Postsharp.CacheAspects;
using MyFramework.Core.Aspects.Postsharp.LogAspects;
using MyFramework.Core.Aspects.Postsharp.PerformanceAspects;
using MyFramework.Core.Aspects.Postsharp.TransactionAspects;
using MyFramework.Core.Aspects.Postsharp.ValidationAspects;
using MyFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using PostSharp.Aspects.Dependencies;

namespace MyFramework.Business.Concrete.Managers
{
    //aop ile yazılan kodlar aslında metod içerisine doğrudan yerleşir
    //postsharp ın 4.2.17 versiyonunu kuruyoruz
    //manager ustunde bunların calısmasını saglayabılırız
    //yada tım managerların loglanmasını ıstıyorsak busıness altındakı propertıesın ıcındekı assmblyınfo ıcıne eklıyoruz
    public class ProductManager:IProductService
   {
       //dependency injection yaptık
       private IProductDal _productDal;

       public ProductManager(IProductDal productDal)
       {
           _productDal = productDal;
       }

       [CacheAspect(typeof(MemoryCacheManager))]
       [LogAspect(typeof(DatabaseLogger))]
       [LogAspect(typeof(FileLogger))]
       [PerformanceCounterAspect(2)]
       [SecuredOperation(Roles="Admin,Editor")]
        public List<Product> GetAll()
       {
          // Thread.Sleep(3000);
          return _productDal.GetList();
       }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        //ürünle alakalı tüm keşleri siler
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
   }
}
