using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public partial class Kunde
    {
        public Kunde()
        {
            Tilbud = new HashSet<Tilbud>();
        }
        [Key]
        public int Kid { get; set; }
        public string Navn { get; set; }
        public int? Aid { get; set; }
        public int? Tlf { get; set; }
        public string Mail { get; set; }

        public Adresse A { get; set; }
        public ICollection<Tilbud> Tilbud { get; set; }
    }
}
