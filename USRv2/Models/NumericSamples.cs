using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class NumericSamples
    {
    [Key, ForeignKey("MainTable")]
    [Column(Order = 1)]
    public int TagId { get; set; }

    [Key]
    [Column(Order = 2)]
    public DateTime SampleDateTime { get; set; }

    public float SampleValue { get; set; }


    public Quality Quality { get; set; }
    [ForeignKey("Quality")]
    public int QualityId { get; set; }


    public virtual MainTable MainTable { get; set; }
}
}