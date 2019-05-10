using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Abstract
{
   public interface ICategoryService
    {
        
        List<Category> GetAll();
        Category GetById(int id);
        Category Add(Category category, HttpPostedFileBase Image);
        Category Update(Category category,HttpPostedFileBase Image);
        void Delete(int id);
    }
}
