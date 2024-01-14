using Business.Rules.Validation.FluentValidation;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Validation
{
    public class CarBusinessRules
    {
        public readonly CarValidator _carValidator;

        public CarBusinessRules(CarValidator carValidator)
        {
            _carValidator = carValidator;
        }

        public void  ValidateCar(Car car)
        {
            var result=_carValidator.Validate(car);
            if (result != null)
            {
                var errors = string.Join(",", result.Errors.Select(e => $"[{e.PropertyName}: {e.PropertyName}]"));

                throw new ValidationException(errors);
            }
        }
    }
}
