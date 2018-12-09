using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Core.CrossCuttingConcerns.Validator.FluentValidator {
    public static class Validator {

        public static bool Validate(IValidator validator, object entity) {

            var result = validator.Validate(entity);

            if(result.Errors.Count > 0) {
                throw new ValidationException(result.Errors);
            }

            return true;
        }
    }
}
