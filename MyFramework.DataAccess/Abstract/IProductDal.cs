using MyFramework.Core.DataAccess;
using MyFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.ComplexType;

namespace MyFramework.DataAccess.Abstract
{
   public interface IProductDal: IEntityRepository<Product>
   {

       List<ProductDetail> GetProductDetails();

   }
}
