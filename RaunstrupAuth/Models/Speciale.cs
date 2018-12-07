using System;
using System.Collections.Generic;

namespace Raunstrup.Models
{
    public partial class Speciale
    {
        public Speciale()
        {
            Medarbejder = new HashSet<Medarbejder>();
        }

        public int Spid { get; set; }
        public string Speciale1 { get; set; }

        public ICollection<Medarbejder> Medarbejder { get; set; }
    }
}
