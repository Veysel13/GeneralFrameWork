using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFramework.Web.Infrastructure;

namespace MyFramework.Web.Controllers
{
    public class AnasayfaController : BaseController
    {

        public AnasayfaController()
        {
            
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}