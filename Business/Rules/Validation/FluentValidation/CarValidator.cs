using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Validation.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(b => b.DailyPrice > 0).NotEmpty();
            RuleFor(b => b.DailyPrice).GreaterThan(0);

        }
    }
}
