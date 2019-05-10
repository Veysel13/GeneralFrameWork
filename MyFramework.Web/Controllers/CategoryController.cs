using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFramework.Business.Abstract;
using MyFramework.Entities.Concrete;
using MyFramework.Web.Filters;
using MyFramework.Web.Infrastructure;
using MyFramework.Web.Models.ViewModel;

namespace MyFramework.Web.Controllers
{
    [ExceptionFilter]
    [AuthorizationFilter]
    public class CategoryController : BaseController
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public ActionResult Index()
        {
            CategoryListViewModel model=new CategoryListViewModel();
            model.Categories = _categoryService.GetAll().Where(x=>x.IsActive==true).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Category model,HttpPostedFileBase Image)
        {
             model.IsActive = true;
            _categoryService.Add(model, Image);
            SuccessNotification("Kayıt Eklendi.");
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            Category model = _categoryService.GetById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(Category model,HttpPostedFileBase Image)
        {
            _categoryService.Update(model, Image);
            SuccessNotification("Kayıt Güncellendi.");
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
          _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}