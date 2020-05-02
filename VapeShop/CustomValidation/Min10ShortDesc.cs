using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VapeShop.Models;

namespace VapeShop.CustomValidation
{
    public class Min10ShortDesc : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vape = (Vape)validationContext.ObjectInstance;

            if (vape.ShortDescription == null)
                return new ValidationResult("Short desc is required.");


            return (vape.ShortDescription.Length >= 10)
                ? ValidationResult.Success
                : new ValidationResult("Short desc must be more than 10 letters.");
        }
    }
}
