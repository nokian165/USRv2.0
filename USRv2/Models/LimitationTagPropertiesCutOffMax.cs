using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class LimitationTagPropertiesCutOffMax : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var mainTablePropertie = (MainTablePropertie)validationContext.ObjectInstance;

            if (mainTablePropertie.CutOffMax > mainTablePropertie.SclMax && mainTablePropertie.IsCutOffMax == true)
                return new ValidationResult("Значение отсечки максимума не может быть больше шкалы максимума!");

            if (mainTablePropertie.CutOffMax < mainTablePropertie.SclMin && mainTablePropertie.IsCutOffMax == true)
                return new ValidationResult("Значение отсечки максимума не может быть меньше шкалы минимума!");

            if (mainTablePropertie.CutOffMax == mainTablePropertie.SclMin && mainTablePropertie.IsCutOffMax == true)
                return new ValidationResult("Значение отсечки максимума не может быть равным шкале минимума!");


            return ValidationResult.Success;

        }
    }
}