using System;
using System.Collections.Generic;

namespace Raunstrup.Models
{
    public partial class Indkøbsliste
    {
        public int Iid { get; set; }
        public int? Tid { get; set; }
        public int? Varenummer { get; set; }
        public int? Antal { get; set; }
        public int? Rid { get; set; }

        public Rabat R { get; set; }
        public Tilbud T { get; set; }
        public Materialer VarenummerNavigation { get; set; }
    }
}
