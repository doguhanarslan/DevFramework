using System;
using System.Linq;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace DevFramework.Core.Aspects.Postsharp.ValidationAspects
{

    [PSerializable]
    public class FluentValidationAspect:OnMethodBoundaryAspect
    {
         Type _validatorType;
       
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType?.GetGenericArguments().FirstOrDefault();

            var entities = args.Arguments.Where(t => entityType.IsAssignableFrom(t.GetType()));

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }

    }
}
