using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Models
{
    public class RisultatoTotaleElementiVista
    {
        public RisultatoRichiesta RisultatoRichiesta { get; set; }

        public string TotaleElementiVista { get; set; } = "0";
    }
}
