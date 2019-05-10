using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FluentValidation;


namespace MyFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
   public class ValidatorTool
    {
        //burada fluentvalidationu referans verdiğimize dikkat edelim
        public static void FluentValidation(IValidator validator,object entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);
                //HttpContext.Current.Response.Redirect("/Home/Index");
            }
        }
    }
}
