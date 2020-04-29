using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Models.JSON
{
    public class RisultatoTotaleElementiVista
    {
        public RisultatoRichiesta RisultatoRichiesta { get; set; } = new RisultatoRichiesta();

        public string TotaleElementiVista { get; set; } = "0";
    }
}
