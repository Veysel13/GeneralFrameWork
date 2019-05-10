using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.ValidationRules.FluentValidation
{
    //install-package fluentvalidation paketi eklenir
   public class ProductValidatior:AbstractValidator<Product>
   {
       public ProductValidatior()
       {
           RuleFor(p=>p.CategoryId).NotEmpty().WithMessage("Kategory boş bırakılamaz"); 
           RuleFor(p=>p.SupplierId).NotEmpty().WithMessage("Satıcı boş bırakılamaz"); 
           RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş bırakılamaz"); 
           RuleFor(p => p.UnitPrice).GreaterThan(0);
           RuleFor(p => p.QuantityPerUnit).NotEmpty();
           RuleFor(p => p.ProductName).Length(2,20);
           RuleFor(p => p.UnitPrice).GreaterThan(20).When(p=>p.CategoryId==1);
           //RuleFor(p => p.ProductName).Must(StartWithA);

       }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
