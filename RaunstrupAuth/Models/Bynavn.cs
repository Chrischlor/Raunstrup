using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public partial class Bynavn
    {
        public Bynavn()
        {
            Adresse = new HashSet<Adresse>();
        }
        [Key]
        public int ByID { get; set; }
        public int Postnummer { get; set; }
        public string Navn { get; set; }

        public ICollection<Adresse> Adresse { get; set; }
    }
}
