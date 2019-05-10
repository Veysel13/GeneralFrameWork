using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.ValidationRules.FluentValidation
{
   public class RootPlanValidatior : AbstractValidator<RootPlan>
    {
        public RootPlanValidatior()
        {
            RuleFor(p => p.Time).NotEmpty().WithMessage("Saat boş bırakılamaz");
            RuleFor(p => p.DayOfWeek).NotEmpty().WithMessage("Gün boş bırakılamaz");
            RuleFor(p => p.SupplierId).NotEmpty().WithMessage("Tedarilçi boş bırakılamaz");
            
        }
    }
}
