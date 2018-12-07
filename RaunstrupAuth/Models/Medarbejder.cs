using System;
using System.Collections.Generic;

namespace Raunstrup.Models
{
    public partial class Medarbejder
    {
        public Medarbejder()
        {
            Medarbejderliste = new HashSet<Medarbejderliste>();
        }

        public int Mid { get; set; }
        public string Navn { get; set; }
        public int? Aid { get; set; }
        public int? Tlf { get; set; }
        public string Udd { get; set; }
        public bool? Fudd { get; set; }
        public int? Spid { get; set; }

        public Adresse A { get; set; }
        public Speciale Sp { get; set; }
        public ICollection<Medarbejderliste> Medarbejderliste { get; set; }
    }
}
