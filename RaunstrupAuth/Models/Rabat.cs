using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public partial class Rabat
    {

        [Key]
        public int Rid { get; set; }
        public string Rabat1 { get; set; }

        public ICollection<Indkøbsliste> Indkøbsliste { get; set; }
        public ICollection<Medarbejderliste> Medarbejderliste { get; set; }
        public ICollection<Tilbud> Tilbud { get; set; }
    }
}
