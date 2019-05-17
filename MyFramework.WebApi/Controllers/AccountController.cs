using MyFramework.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using MyFramework.Core.CrossCuttingConcerns.Security.Web;
using MyFramework.Entities.Concrete;

namespace MyFramework.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        
       
    }
}
