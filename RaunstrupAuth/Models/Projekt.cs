using System;
using System.Collections.Generic;

namespace RaunstrupAuth.Models
{
    public partial class Projekt
    {
        public int Pid { get; set; }
        public int? Tid { get; set; }

        public Tilbud T { get; set; }
    }
}
