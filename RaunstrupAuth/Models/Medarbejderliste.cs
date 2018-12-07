using System;
using System.Collections.Generic;

namespace Raunstrup.Models
{
    public partial class Medarbejderliste
    {
        public int Mlid { get; set; }
        public int? Tid { get; set; }
        public int? Mid { get; set; }
        public int? Timer { get; set; }
        public int? Rid { get; set; }

        public Medarbejder M { get; set; }
        public Rabat R { get; set; }
        public Tilbud T { get; set; }
    }
}
