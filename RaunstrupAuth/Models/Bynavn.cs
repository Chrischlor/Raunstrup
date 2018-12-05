using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public class Bynavn
    {
        [Key]
        public int ByID { get; set; }
        public int Postnummer { get; set; }
        [Required]
        public string Navn { get; set; }

        public ICollection<Adresse> Adresse { get; set; }
    }
}
