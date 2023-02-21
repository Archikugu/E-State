using Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class NeighbourhoodValidation : AbstractValidator<Neighbourhood>
    {
        public NeighbourhoodValidation()
        {
            RuleFor(x => x.NeighbourhoodName).NotEmpty().WithMessage("Mahalle adı boş bırakılamaz");
            RuleFor(x => x.DistrictId).NotEmpty().WithMessage("Semt adı boş bırakılamaz");
        }
    }
}
