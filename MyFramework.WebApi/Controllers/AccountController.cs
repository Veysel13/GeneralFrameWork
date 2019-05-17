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
using MyFramework.WebApi.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace MyFramework.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public HttpResponseMessage Login(string userName,string password)
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);
            if (user !=null)
            {
                //1-LogonUser
                var logonUser = new LogonUser()
                {
                    UserName = userName,
                    Password = password
                };
                //2-JsonString
                var jsonString = JsonConvert.SerializeObject(logonUser);
                //3-Şifreleme => Token
                var token =FTH.Extension.Encrypter.Encrypt(jsonString,"159357");
               return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Kullanıcı Adı ve Şifresi Geçersizdir.");
            }
        }

    }
}
