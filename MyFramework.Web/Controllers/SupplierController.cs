﻿using System;
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
    [AuthorizationFilter]
    public class SupplierController : BaseController
    {
        private ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public ActionResult Index()
        {
            SupplierListViewModel supplierList = new SupplierListViewModel
            {
                Suppliers = _supplierService.GetAll()
            };
            return View(supplierList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                ErrorNotification("Kayıt Eklenemedi!");
                return View("Create");
            }
            _supplierService.Add(supplier);
            SuccessNotification("Kayıt Eklendi.");
            return RedirectToAction("Index");
        }
    }
}