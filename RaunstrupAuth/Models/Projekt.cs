using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public class Projekt
    {
        [Key]
        public int Pid { get; set; }
        public int? Tid { get; set; }

        public Tilbud T { get; set; }
    }
}
