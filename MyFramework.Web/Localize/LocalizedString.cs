using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using MyFramework.Business.Abstract;
using MyFramework.Business.DependencyResolvers.Ninject;

namespace MyFramework.Web.Localize
{
    public class LocalizedString : MarshalByRefObject
    {
        /// <summary>
        /// {0} Language code: ex: tr-TR,en-EN
        /// {1} The Word Code in the table :  LangaugeWords
        /// </summary>
        private const string CacheNameKey = "Language.{0}.{1}";

        //private ILanguageService _languageService;
        //private ILanguageWordService _languageWordService;

        private readonly string _word;

        public override string ToString()
        {
            return _word;
        }

        public LocalizedString(string code)
        {

            var languageWordService = DependencyResolver<ILanguageWordService>.Resolve();
            var languageService = DependencyResolver<ILanguageService>.Resolve();
            var cookie = "tr-TR";
            if (HttpContext.Current.Session["language"] != null)
            {
                cookie = HttpContext.Current.Session["language"].ToString();
            }
           
            //var culture = Thread.CurrentThread.CurrentUICulture.Name;
            if (cookie.Length < 3)
                cookie = cookie.Replace(cookie, cookie + "-" + cookie.ToUpper());

            var language = languageService.Get(cookie);
            var data = languageWordService.GetValue(language.LanguageId, code);

            _word = data != null ? data.Value : code;
            //_word = "Turkish";
        }
    }
}