using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public class Materialer
    {
        [Key]
        public int Varenummer { get; set; }
        public string Navn { get; set; }
        public int? Indkøbspris { get; set; }
        public int? Salgspris { get; set; }

        public ICollection<Indkøbsliste> Indkøbsliste { get; set; }
    }
}
