using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DictionaryV2.Core.CrossCuttingConcerns.Validator.FluentValidator;

namespace DictionaryV2.Core.Aspects.PostSharp.ValidationAspects {
    [Serializable]
    public class FluentValidatonAspect : OnMethodBoundaryAspect {

        private Type _validatorType;
        public FluentValidatonAspect(Type validatorType) {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args) {

            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GenericTypeArguments[0];
            var entities = args.Arguments.Where(x => x.GetType() == entityType);

            foreach (var item in entities) {

                Validator.Validate(validator, item);
            }

        }

    }
}
