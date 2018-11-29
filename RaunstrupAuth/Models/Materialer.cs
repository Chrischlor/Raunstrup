using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public partial class Materialer
    {
        public Materialer()
        {
            Indkøbsliste = new HashSet<Indkøbsliste>();
        }
        [Key]
        public int materialeID { get; set; }
        public string Navn { get; set; }
        public int? Indkøbspris { get; set; }
        public int? Salgspris { get; set; }

        public ICollection<Indkøbsliste> Indkøbsliste { get; set; }
    }
}
