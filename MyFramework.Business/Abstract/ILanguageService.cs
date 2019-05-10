using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Abstract
{
    public interface ILanguageService
    {
        List<Language> GetAll();
        Language GetById(int languageId);
        List<Language> GetByLanguage(int languageId);

        Language Add(Language language);
        void Update(Language language);
        void Delete(Language language);

        Language Get(string code);

    }
}
