using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class LimitationTagPropertiesCutOffMin : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var mainTablePropertie = (MainTablePropertie)validationContext.ObjectInstance;

            if (mainTablePropertie.CutOffMin < mainTablePropertie.SclMin && mainTablePropertie.IsCutOffMin == true)
                return new ValidationResult("Значение отсечки минимума не может быть меньше шкалы минимума!");

            if (mainTablePropertie.CutOffMin > mainTablePropertie.SclMax && mainTablePropertie.IsCutOffMin == true)
                return new ValidationResult("Значение отсечки минимума не может быть больше шкалы максимума!");

            if (mainTablePropertie.CutOffMin == mainTablePropertie.SclMax && mainTablePropertie.IsCutOffMin == true)
                return new ValidationResult("Значение отсечки минимума не может быть равным шкале максимума!");

            return ValidationResult.Success;

        }
    }
}