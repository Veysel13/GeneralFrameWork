using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Entities.Concrete
{
    public class Language : IEntity
    {
        public virtual int LanguageId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
    }
}
