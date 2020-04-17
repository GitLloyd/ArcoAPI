using System;
using System.Collections.Generic;

namespace ArcoApi.Models
{
    public partial class Sede
    {
        public double? CodiceSede { get; set; }
        public string DescrizioneSede { get; set; }
        public double? TipologiaSede { get; set; }
        public string Regione { get; set; }
    }
}
