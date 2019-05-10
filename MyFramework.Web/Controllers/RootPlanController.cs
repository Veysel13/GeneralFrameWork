using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MyFramework.Business.Abstract;
using MyFramework.Entities.Concrete;
using MyFramework.Web.Infrastructure;
using MyFramework.Web.Models.ViewModel;

namespace MyFramework.Web.Controllers
{
    public class RootPlanController : BaseController
    {
        private IRootPlanService _rootPlanService;
        private ISupplierService _supplierService;
        private IRootPointService _rootPointService;
        public RootPlanController(IRootPlanService rootPlanService, ISupplierService supplierService, IRootPointService rootPointService)
        {
            _rootPlanService = rootPlanService;
            _supplierService = supplierService;
            _rootPointService = rootPointService;
        }
        // GET: RootPlan
        public ActionResult Index()
        {

            RootPlanListViewModel model = new RootPlanListViewModel();
            model.RootPlans = _rootPlanService.GetListRootPlanDetails();
            model.Suppliers = _supplierService.GetAll();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RootPlan model)
        {
            var rootCount = _rootPlanService.GetAll().Where(x => x.Time == model.Time && x.DayOfWeek == model.DayOfWeek && x.IsActive == true).ToList().Count;
            if (rootCount > 0)
            {
                TempData["RootPlanAlreadyExist"] = "EKlemek istediğiniz gün ve saatte plan bulunmaktadır";
            }

            _rootPlanService.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _rootPlanService.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult GeziRehberi()
        {
            RootPlanViewModel model = new RootPlanViewModel();
            model.RootPlans = _rootPlanService.GetListRootPlanDetails().Where(x => x.DayOfWeek == DateTime.Now.DayOfWeek).OrderBy(x => x.Time).ToList();
            model.RootPoints = _rootPointService.GetRootPlan();
            return View(model);
        }
        [HttpPost]
        public JsonResult CheckPlan(int? Id)
        {
            _rootPointService.PlanCheck(Id.Value);
            string json = @"{
                          'status': 'success',
                          'durum': 'Başarılı',
                          'icerik':'Kontrol noktası check edildi'}";

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var m = ser.DeserializeObject(json);
            return Json(m, JsonRequestBehavior.AllowGet);
        }
    }
}