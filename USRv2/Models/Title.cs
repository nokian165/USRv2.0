using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class Title
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле: Название параметра")]
        [Display(Name = "Название параметра")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}