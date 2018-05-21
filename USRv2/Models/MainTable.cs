using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace USRv2.Models
{
    public class MainTable
    {
        public int Id { get; set; }

        public Plc Plc { get; set; }

        [Display(Name = "Отделение")]
        public int PlcId { get; set; }

        public Label Label { get; set; }

        [Display(Name = "Метка")]
        public int LabelId { get; set; }

        public Title Title { get; set; }

        [Display(Name = "Название")]
        public int TitleId { get; set; }

        public Unit Unit { get; set; }

        [Display(Name = "Единица измерения")]
        public int UnitId { get; set; }

        public int IdAsc { get; set; }

        public bool IsContainer { get; set; }

        [Display(Name = "Имя заглушки")]
        [StringLength(50)]
        [MinNameIfIsContainer]
        public string Container { get; set; }

        public MainTablePropertie MainTablePropertie { get; set; }

        public virtual ICollection<NumericSamples> NumericSamples { get; set; }

        public bool IsOutOfView { get; set; }
    }
}