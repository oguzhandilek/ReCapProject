﻿using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Validation.FluentValidation
{
    public  class BrandValidator:AbstractValidator<Brand> 
    {
        public BrandValidator()
        {
            RuleFor(b=> b.Name).NotEmpty();
            RuleFor(b=> b.Name).MinimumLength(5).WithMessage("Marka en az iki karakter olmalı");
           

        }
    }
}
