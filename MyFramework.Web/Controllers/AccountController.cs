using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFramework.Business.Abstract;
using MyFramework.Core.CrossCuttingConcerns.Security.Web;

namespace MyFramework.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public string Login(string userName,string password)
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);
            if (user!=null)
            {
                 AuthenticationHelper.CreateAuthCookie(new Guid(),
                user.UserName,
                user.Email,
                DateTime.Now.AddDays(15),
                _userService.GetUserRoleItems(user).Select(x=>x.RoleName).ToArray(),
                false,
                user.FirstName,
                user.LastName);
                 return "user is authenticated";
            }
            return "user is not authenticated";

        }
    }
}