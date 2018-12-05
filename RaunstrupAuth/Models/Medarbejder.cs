using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaunstrupAuth.Models
{
    public partial class Medarbejder
    {

        [Key]
        public int MID { get; set; }
        public string Navn { get; set; }
        public int Aid { get; set; }
        public int Tlf { get; set; }
        public string Udd { get; set; }
        public bool Fudd { get; set; }
        public int SpecialeID { get; set; }


        public Adresse adresse { get; set; }
        public ICollection<Medarbejderliste> Medarbejderliste { get; set; }
        public Speciale speciale { get; set; }
        
    }
}
