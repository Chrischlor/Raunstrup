using System;
using System.Collections.Generic;

namespace RaunstrupAuth.Models
{
    public partial class Bynavn
    {
        public Bynavn()
        {
            Adresse = new HashSet<Adresse>();
        }

        public int Byid { get; set; }
        public int? Postnummer { get; set; }
        public string Navn { get; set; }

        public ICollection<Adresse> Adresse { get; set; }
    }
}
