using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USRv2.Models;

namespace USRv2.ViewModels
{
    public class MainTableViewModel
    {
        public List<MainTable> MainTables { get; set; }
        public List<Plc> Plcs { get; set; }

        public List<NumericSampleAverage> NumericSampleAverages { get; set; }
        public List<NumericSampleRandom> NumericSampleRandoms { get; set; }
    }
}