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
    public class BrandBusinessRules
    {
        private readonly BrandValidator _brandValidator;

        public BrandBusinessRules(BrandValidator brandValidator)
        {
            _brandValidator = brandValidator;
        }

        public void ValidateBrand(Brand brand)
        {
            var result = _brandValidator.Validate(brand);
            if (!result.IsValid)
            {
                string errorMessage = "";
                foreach (var error in result.Errors)
                {
                    errorMessage += error.PropertyName + " : " + error.ErrorMessage + "\n";
                }
                throw new ValidationException(errorMessage);
            }
        }
    }
}
