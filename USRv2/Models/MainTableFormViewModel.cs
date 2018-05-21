using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class MainTableFormViewModel
    {
        public IEnumerable<Plc> Plcs { get; set; }
        public IEnumerable<Unit> Units { get; set; }
        public IEnumerable<Label> Labels { get; set; }
        public IEnumerable<Title> Titles { get; set; }

        public MainTable MainTable { get; set; }
    }
}