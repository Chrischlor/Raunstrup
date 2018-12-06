using System;
using System.Collections.Generic;

namespace Raunstrup.Models
{
    public partial class Projekt
    {
        public int ProjektId { get; set; }
        public int? Tid { get; set; }

        public Tilbud T { get; set; }
    }
}
