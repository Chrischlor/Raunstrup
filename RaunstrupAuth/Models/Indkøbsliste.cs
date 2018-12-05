using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public class Indkøbsliste
    {
        [Key]
        public int IID { get; set; }
        public int indkøbsgruppe { get; set; }
        public int? Tid { get; set; }
        public int? Varenummer { get; set; }
        public int? Antal { get; set; }
        public int? Rid { get; set; }

        public Materialer materialer { get; set; }

        public Rabat R { get; set; }
        public Tilbud T { get; set; }
        public ICollection<materialeIndkøb> materialeIndkøb { get; set; }
    }
}
