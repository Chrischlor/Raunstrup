using System;
using System.Collections.Generic;

namespace Raunstrup.Models
{
    public partial class Rabat
    {
        public Rabat()
        {
            Indkøbsliste = new HashSet<Indkøbsliste>();
            Medarbejderliste = new HashSet<Medarbejderliste>();
            Tilbud = new HashSet<Tilbud>();
        }

        public int Rid { get; set; }
        public string Rabat1 { get; set; }

        public ICollection<Indkøbsliste> Indkøbsliste { get; set; }
        public ICollection<Medarbejderliste> Medarbejderliste { get; set; }
        public ICollection<Tilbud> Tilbud { get; set; }
    }
}
