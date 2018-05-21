using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USRv2.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Singer Singer { get; set; }
    }
}