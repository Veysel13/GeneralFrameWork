using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Business.Abstract;
using MyFramework.Core.Aspects.Postsharp.CacheAspects;
using MyFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MyFramework.Core.CrossCuttingConcerns.Transaction;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Concrete.Managers
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        // [LogAspect(typeof(DatabaseLogger))]
        [CacheAspect(typeof(MemoryCacheManager))]
        // [PerformanceCounterAspect(1)]      
        public List<Language> GetAll()
        {
            return _languageDal.GetList();
        }

        public Language GetById(int languageId)
        {
            return _languageDal.Get(u => u.LanguageId == languageId);
        }

        //[FluentValidationAspect(typeof(LanguageValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Language Add(Language language)
        {
            return _languageDal.Add(language);
        }
        //[FluentValidationAspect(typeof(LanguageValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Language language)
        {
            _languageDal.Update(language);
        }

        public void Delete(Language language)
        {
            _languageDal.Delete(language);
        }

        public Language Get(string code)
        {
            return GetAll().SingleOrDefault(t => t.Code == code);
        }

        public List<Language> GetByLanguage(int languageId)
        {
            return _languageDal.GetList(filter: t => t.LanguageId == languageId).ToList();
        }
    }
}
