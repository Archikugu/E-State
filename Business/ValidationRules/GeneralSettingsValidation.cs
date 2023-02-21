﻿using Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class GeneralSettingsValidation : AbstractValidator<GeneralSettings>
    {
        public GeneralSettingsValidation()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres alanı boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası alanı boş bırakılamaz");
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("Resim alanı boş bırakılamaz");
        }
    }
}
