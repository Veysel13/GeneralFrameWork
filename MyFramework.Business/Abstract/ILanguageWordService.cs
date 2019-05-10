using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Abstract
{
    public interface ILanguageWordService
    {
        List<LanguageWord> GetAll();
        List<LanguageWord> GetByLanguage(int languageId);
        LanguageWord GetValue(int languageId, string code);
        LanguageWord Add(LanguageWord languageWord);

    }
}
