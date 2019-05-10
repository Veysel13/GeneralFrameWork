﻿using System;
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

            var culture = Thread.CurrentThread.CurrentUICulture.Name;
            if (culture.Length < 3)
                culture = culture.Replace(culture, culture + "-" + culture.ToUpper());

            var language = languageService.Get(culture);
            var data = languageWordService.GetValue(language.LanguageId, code);

            _word = data != null ? data.Value : code;
            //_word = "Turkish";
        }
    }
}