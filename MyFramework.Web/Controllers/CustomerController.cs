using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFramework.Business.Abstract;
using MyFramework.Entities.Concrete;
using MyFramework.Web.Infrastructure;
using MyFramework.Web.Models.ViewModel;

namespace MyFramework.Web.Controllers
{
    public class CustomerController : BaseController
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            CustomerListViewModel model = new CustomerListViewModel
            {
                Customers = _customerService.GetAll().Where(x=>x.IsActive==true).ToList()
            };
            return View(model);
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Customer model)
        {
            Random rastgele = new Random();
            string harfler = "ABCDEFGHIJKLMNOPRSTUVYZ";
            string uret = "";
            for (int i = 0; i < 5; i++)
            {
                uret += harfler[rastgele.Next(harfler.Length)];
            }

            model.CustomerId=uret;
            _customerService.Add(model);
            SuccessNotification("Kayıt Eklendi.");
            return RedirectToAction("Index");
        }

        public ActionResult Update(string id)
        {
            Customer model = _customerService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(Customer model)
        {
            _customerService.Update(model);
            SuccessNotification("Kayıt Güncellendi.");
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
           _customerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}