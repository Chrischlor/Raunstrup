
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaunstrupAuth.Models
{
    public class materialeIndkøb
    {
        [Key]
        public int ID { get; set; }
        public Materialer Materialer { get; set; }

        public int Antal { get; set; }
    }
}
