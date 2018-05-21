using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class NumericSampleRandom
    {
        public int? Id { get; set; }
        public float? AverageRandom { get; set; }
        public float? SumRandom { get; set; }
        public float? MinimumRandom { get; set; }
        public float? MaximumRandom { get; set; }
    }
}