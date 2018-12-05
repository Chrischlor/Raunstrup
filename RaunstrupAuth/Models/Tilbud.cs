using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public class Tilbud
    {
        [Key]
        public int Tid { get; set; }
        public string Projekttitle { get; set; }
        public int Rid { get; set; }
        public int Kid { get; set; }
        public DateTime Startdato { get; set; }
        public DateTime Deadline { get; set; }

        public Kunde K { get; set; }
        public Rabat R { get; set; }
        public ICollection<Indkøbsliste> Indkøbsliste { get; set; }
        public ICollection<Medarbejderliste> Medarbejderliste { get; set; }
        public ICollection<Projekt> Projekt { get; set; }
    }
}
