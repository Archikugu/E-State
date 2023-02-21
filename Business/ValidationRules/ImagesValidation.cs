using Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ImagesValidation : AbstractValidator<Images>
    {
        public ImagesValidation()
        {
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("Resim alanı boş bırakılamaz");
            RuleFor(x => x.AdvertId).NotEmpty().WithMessage("İlan alanı boş bırakılamaz");
        }
    }
}
