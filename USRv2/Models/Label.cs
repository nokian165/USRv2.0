using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class Label
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле: Метка параметра")]
        [Display(Name = "Метка параметра")]
        [StringLength(20)]
        public string Name { get; set; }
    }
}