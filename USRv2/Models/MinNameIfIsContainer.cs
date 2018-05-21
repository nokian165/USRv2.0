using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class MinNameIfIsContainer : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var mainTable = (MainTable)validationContext.ObjectInstance;

            if (mainTable.IsContainer == false)
                return ValidationResult.Success;

            if (mainTable.Container == null)
                return new ValidationResult("Требуется поле Имя заглушки");

            return ValidationResult.Success;

        }
    }
}