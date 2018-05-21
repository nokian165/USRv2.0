using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class MainTablePropertie
    {
        [ForeignKey("MainTable")]
        public int MainTablePropertieId { get; set; }

        [Range(-9999.9, 9999.9, ErrorMessage = "Допустимый предел ввода от -9999.9 до +9999.9")]
        [LimitationTagPropertiesSclMax]
        [Display(Name = "Максимум шкалы")]
        public float SclMax { get; set; }

        [Range(-9999.9, 9999.9, ErrorMessage = "Допустимый предел ввода от -9999.9 до 9999.9")]
        [LimitationTagPropertiesSclMin]
        [Display(Name = "Минимум шкалы")]
        public float SclMin { get; set; }

        [Display(Name = "Включить отсечку максимума")]
        public bool IsCutOffMax { get; set; }

        [Range(-9999.9, 9999.9, ErrorMessage = "Допустимый предел ввода от -9999.9 до 9999.9")]
        [LimitationTagPropertiesCutOffMax]
        [Display(Name = "Значение отсечки максимума")]
        public float CutOffMax { get; set; }

        [Display(Name = "Включить отсечку минимума")]
        public bool IsCutOffMin { get; set; }

        [Range(-9999.9, 9999.9, ErrorMessage = "Допустимый предел ввода от -9999.9 до 9999.9")]
        [LimitationTagPropertiesCutOffMin]
        [Display(Name = "Значение отсечки минимума")]
        public float CutOffMin { get; set; }

        public virtual MainTable MainTable { get; set; }
    }
}