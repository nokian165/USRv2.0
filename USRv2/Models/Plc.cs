using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class Plc
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле: Отделение")]
        [Display(Name = "Отделение")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле: Метка отделения")]
        [Display(Name = "Метка отделения")]
        [StringLength(10)]
        public string DepName { get; set; }

        public bool IsVisibleInMenu { get; set; }
    }
}