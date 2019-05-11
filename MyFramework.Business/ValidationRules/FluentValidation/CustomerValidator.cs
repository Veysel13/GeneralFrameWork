using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.ValidationRules.FluentValidation
{
    class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty().WithMessage("Şirket ismi boş bırakılamaz");
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("Id boş bırakılamaz");
            
        }
    }
}
