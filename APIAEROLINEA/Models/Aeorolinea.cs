using System;
using System.Collections.Generic;

namespace APIAEROLINEA.Models
{
    public partial class Aeorolinea
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Destination { get; set; } = null!;
        public string Flight { get; set; } = null!;
        public int Gate { get; set; }
        public string Remarks { get; set; } = null!;
        public int? Count { get; set; }
    }
}
