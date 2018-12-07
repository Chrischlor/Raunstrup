using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public partial class Speciale
    {
        [Key]
        public int Spid { get; set; }
        public string Speciale1 { get; set; }
        public ICollection<Medarbejder> Medarbejder { get; set; }
    }
}
