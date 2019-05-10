using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using MyFramework.Business.Abstract;
using MyFramework.Business.ValidationRules.FluentValidation;
using MyFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using MyFramework.Core.Aspects.Postsharp.CacheAspects;
using MyFramework.Core.Aspects.Postsharp.LogAspects;
using MyFramework.Core.Aspects.Postsharp.ValidationAspects;
using MyFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.ComplexType;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Concrete.Managers
{
    [LogAspect(typeof(DatabaseLogger))]
    [LogAspect(typeof(FileLogger))]
    public class CategoryManager:ICategoryService
   {
       private IFileUploadService _fileUploadService;
       private ICategoryDal _categoryDal;
       private IMapper _mapper { get; }

        public CategoryManager(ICategoryDal categoryDal,IMapper mapper, IFileUploadService fileUploadService)
       {
           _categoryDal = categoryDal;
           _mapper = mapper;
           _fileUploadService = fileUploadService;
       }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Category> GetAll()
        {
            return _mapper.Map<List<Category>>(_categoryDal.GetList());
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

       [FluentValidationAspect(typeof(CategoryValidatior))]
       [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Category Add(Category category, HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                ImageDetail imagePath = _fileUploadService.ThumbImageSave(Image, "Category",225,225);
                category.Image = imagePath.Image;
                category.ThumbImage = imagePath.ThumbImage;
            }

            return _categoryDal.Add(category);
        }

       [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Category Update(Category category,HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                ImageDetail imagePath = _fileUploadService.ThumbImageSave(Image, "Category", 130, 150);
                category.Image = imagePath.Image;
                category.ThumbImage = imagePath.ThumbImage;
            }
            return _categoryDal.Update(category);
        }

       [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int id)
       {
           Category model = GetById(id);
           if (model !=null)
           {
               model.IsActive = false;
           }
             _categoryDal.Update(model);
        }
    }
}
