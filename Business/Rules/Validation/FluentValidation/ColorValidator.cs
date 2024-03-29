﻿using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Validation.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator() { 
        
            RuleFor(c=> c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Renk adı en az iki karakter olmalı!");
        }
    }
}
