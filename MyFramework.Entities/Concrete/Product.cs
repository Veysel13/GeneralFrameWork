using MyFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Entities.Concrete
{
   public class Product:IEntity
    {
        //virtual yapmamız nhibernate çalışma olasılığına karşı
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual int SupplierId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string QuantityPerUnit { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual bool Discontinued { get; set; }
    }
}
