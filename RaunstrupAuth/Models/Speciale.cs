using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public class Speciale
    {
        [Key]
        public int Spid { get; set; }
        public string SpecialeNavn { get; set; }
    }
}
