using DictionaryV2.Entity.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Business.Validation.FluentValidation {
    public class EngDictionaryValidation : AbstractValidator<EngDictionary> {

        public EngDictionaryValidation() {

            RuleFor(x => x.EngStr).NotEmpty();
            RuleFor(x => x.TrStr).NotEmpty();
        }
    }
}
