using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.DataAccess.EntityFramework;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.ComplexType;
using MyFramework.Entities.Concrete;

namespace MyFramework.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal :EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products
                    join c in context.Categories on p.CategoryId equals c.CategoryId
                    join s in context.Suppliers on p.SupplierId equals s.SupplierId
                             select new ProductDetail
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        UnitPrice=p.UnitPrice,
                        CategoryName = c.CategoryName,
                        CompanyName = s.CompanyName,
                        Discontinued = p.Discontinued,
                        CategoryId=p.CategoryId
                             };
                return result.ToList();
            }
            
        }
    }
}
