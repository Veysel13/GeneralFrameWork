using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.Entities;

namespace MyFramework.Entities.Concrete
{
    public class LanguageWord : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int LanguageId { get; set; }
        public virtual string Code { get; set; }
        public virtual string Value { get; set; }
    }
}
