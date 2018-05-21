using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class LimitationTagPropertiesSclMin : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var mainTablePropertie = (MainTablePropertie)validationContext.ObjectInstance;

            if (mainTablePropertie.SclMin > mainTablePropertie.SclMax)
                return new ValidationResult("Значение минимума не может быть больше шкалы максимума!");
            if (mainTablePropertie.SclMin == mainTablePropertie.SclMax)
                return new ValidationResult("Значение минимума не может быть равным шкале максимума!");

            return ValidationResult.Success;

        }
    }
}