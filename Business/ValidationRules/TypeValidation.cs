using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class TypeValidation : AbstractValidator<Entity.Entities.Type>
    {
        public TypeValidation()
        {
            RuleFor(x => x.TypeName).NotEmpty().WithMessage("Tip adı boş bırakılamaz");
            RuleFor(x => x.SituationId).NotEmpty().WithMessage("Durum adı boş bırakılamaz");
        }
    }
}
