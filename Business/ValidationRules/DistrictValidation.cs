using Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class DistrictValidation : AbstractValidator<District>
    {
        public DistrictValidation()
        {
            RuleFor(x => x.DistrictName).NotEmpty().WithMessage("Semt adı boş bırakılamaz");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("Şehir alanı boş bırakılamaz");
        }
    }
}
