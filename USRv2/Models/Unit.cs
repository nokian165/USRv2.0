using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class Unit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле: Единица измерения")]
        [Display(Name = "Единица измерения")]
        [StringLength(10)]
        public string Name { get; set; }
    }
}