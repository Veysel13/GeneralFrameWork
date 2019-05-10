using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyFramework.Business.Abstract;
using MyFramework.Core.CrossCuttingConcerns.Security.Web;
using MyFramework.Web.Infrastructure;

namespace MyFramework.Web.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account

        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string userName, string password)
        {
            //string encoded = Crypto.SHA256(password);
            var user = _userService.GetByUserNameAndPassword(userName, password);

            if (user != null && user.IsActive == true)
            {
                Session["FullName"] = Session["FullName"] == null ? user.FirstName + " " + user.LastName : "";
                if (TempData != null)
                {
                    TempData["userName"] = userName;
                    TempData["password"] = password;
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Login");
            }
            TempData["mesaj"] = "Hatalı Kullanıcı Adı veya Parola!!!" + "<br/>ya da<br/>" + "Onaylanmamış Kullanıcı Girişi!!!";
            return View("SignIn");
        }
       
        public ActionResult Login(string userName,string password)
        {
           
            var user = _userService.GetByUserNameAndPassword(TempData["userName"].ToString(),
                TempData["password"].ToString());
            var link = _userService.GetUserRoleItems(user);
            if (user!=null &&user.IsActive==true)
            {
                 AuthenticationHelper.CreateAuthCookie(new Guid(),
                user.UserName,
                user.Email,
                DateTime.Now.AddDays(15),
                _userService.GetUserRoleItems(user).Select(x=>x.RoleName).ToArray(),
                false,
                user.FirstName,
                user.LastName);
                return RedirectToAction("Index", "Anasayfa");
            }
            //return Redirect("NotAuthorization");
            return PartialView("NotAuthorization");
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Session.Abandon();
            return RedirectToAction("SignIn", "Account", null);
        }
    }
}