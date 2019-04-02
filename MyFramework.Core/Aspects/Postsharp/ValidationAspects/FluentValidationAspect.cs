using System;
using System.Linq;
using FluentValidation;
using MyFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using PostSharp.Aspects;

namespace MyFramework.Core.Aspects.Postsharp.ValidationAspects
{
    //nuget paket den postsharp pakitinin 4.2.17 versiyonunu kullanıyoruz
    
    [Serializable]
    public class FluentValidationAspect:OnMethodBoundaryAspect
    {
        Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        //methoda girdiğinde
        public override void OnEntry(MethodExecutionArgs args)
        {
            //depenceny injection ile hangi validatin gönderildiğini bulduk
            //onun instance oluşturduk
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //oluşturulan instance ın hangi entity kullandığını bulduk
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //validate edilecek entitileri buluyoruz.
            //args çalışılacak metodla ilgili bilgilere ulaşmaya yarar
            //metoddaki parametleri geziyorum ve tipi benim validate edeçeğim entitiyi buluyorum
            var entities = args.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidation(validator,entity);
            }
        }
    }
}
