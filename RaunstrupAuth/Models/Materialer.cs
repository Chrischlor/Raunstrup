using System;
using System.Collections.Generic;

namespace Raunstrup.Models
{
    public partial class Materialer
    {
        public Materialer()
        {
            Indkøbsliste = new HashSet<Indkøbsliste>();
        }

        public int Varenummer { get; set; }
        public string Navn { get; set; }
        public int? Indkøbspris { get; set; }
        public int? Salgspris { get; set; }

        public ICollection<Indkøbsliste> Indkøbsliste { get; set; }
    }
}
