using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class LimitationTagPropertiesSclMax : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var mainTablePropertie = (MainTablePropertie)validationContext.ObjectInstance;

            if (mainTablePropertie.SclMin > mainTablePropertie.SclMax)
                return new ValidationResult("Значение максимума не может быть меньше шкалы минимума!");
            if (mainTablePropertie.SclMin == mainTablePropertie.SclMax)
                return new ValidationResult("Значение максимума не может быть равным шкале минимума!");

            return ValidationResult.Success;

        }
    }
}