using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public class Adresse
    {
        [Key]
        public int AID { get; set; }
        public int Byid { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        [Required]
        public Bynavn By { get; set; }
        public Kunde Kunde { get; set; }
        public ICollection<Medarbejder> Medarbejder { get; set; }
    }
}
