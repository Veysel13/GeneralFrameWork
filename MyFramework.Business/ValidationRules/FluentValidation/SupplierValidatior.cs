using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.ValidationRules.FluentValidation
{
   public class SupplierValidatior:AbstractValidator<Supplier>
    {
        public SupplierValidatior()
        {
            RuleFor(p => p.SupplierId).NotEmpty();
            RuleFor(p => p.CompanyName).NotEmpty().WithMessage("Şirket ismi boş bırakılamaz");

        }
    }
}
