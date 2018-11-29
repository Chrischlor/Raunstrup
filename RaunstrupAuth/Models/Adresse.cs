using System;
using System.Collections.Generic;

namespace RaunstrupAuth.Models
{
    public partial class Adresse
    {
        public Adresse()
        {
            Kunde = new HashSet<Kunde>();
            Medarbejder = new HashSet<Medarbejder>();
        }

        public int Aid { get; set; }
        public int? Byid { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }

        public Bynavn By { get; set; }
        public ICollection<Kunde> Kunde { get; set; }
        public ICollection<Medarbejder> Medarbejder { get; set; }
    }
}
