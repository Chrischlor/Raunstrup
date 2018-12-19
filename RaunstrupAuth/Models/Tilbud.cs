using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using RaunstrupAuth.Models;

namespace RaunstrupAuth.Models
{
    public partial class Tilbud
    {
        public Tilbud()
        {
            Indkøbsliste = new HashSet<Indkøbsliste>();
            Medarbejderliste = new HashSet<Medarbejderliste>();
            Projekt = new HashSet<Projekt>();
        }
        [Key]
        public int Tid { get; set; }
        public string Projekttitle { get; set; }
        public int Rid { get; set; }
        public int Kid { get; set; }
        [DataType(DataType.Date)]
        public DateTime Startdato { get; set; }
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        public Kunde K { get; set; }
        public Rabat R { get; set; }
        public ICollection<Indkøbsliste> Indkøbsliste { get; set; }
        public ICollection<Medarbejderliste> Medarbejderliste { get; set; }
        public ICollection<Projekt> Projekt { get; set; }

        //public int totalMat(Tilbud T)
        //{
        //    int totalpis = Indkøbsliste.pris();
        //}

    }
}
