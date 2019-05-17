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
        private const string CacheNameKey = "Language.{0}.{1}";
        private readonly string _word;
        public override string ToString()
        {
            return _word;
        }

        public LocalizedString(string code, params object[] args)
        {
            var languageWordService = InstanceFactory.GetInstance<ILanguageWordService>();
            var languageService = InstanceFactory.GetInstance<ILanguageService>();
            var culture = Thread.CurrentThread.CurrentUICulture.Name;
            if (culture.Length < 3)
                culture = culture.Replace(culture, culture + "-" + culture.ToUpper());

            var language = languageService.Get(culture);
            var data = languageWordService.GetValue(language.LanguageId, code);
            //eğer id li degeer gondermek istersek
            //var roomId = args.Any() ? args[0] : 0;
            //var data = languageWordService.GetValue(language.Id, code, Convert.ToInt32(roomId));
            
            _word = data != null ? data.Value : code;
        }
    }
}