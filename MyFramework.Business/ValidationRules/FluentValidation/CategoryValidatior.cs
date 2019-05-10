using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.ValidationRules.FluentValidation
{
    class CategoryValidatior: AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("Kategori ismi boş bırakılamaz"); 
            RuleFor(p => p.Description).Length(20,500 ).WithMessage("açıklama 20 ile 500 karakter arası olmalıdır."); 
            
        }
    }
}
